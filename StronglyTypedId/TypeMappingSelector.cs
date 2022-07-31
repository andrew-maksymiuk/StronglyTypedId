using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StronglyTypedId
{
    public class TypeMappingSelector : ValueConverterSelector
    {
        public TypeMappingSelector(ValueConverterSelectorDependencies dependencies)
            : base(dependencies) { }


        public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type providerClrType = null)
        {
            foreach (ValueConverterInfo _converter in base.Select(modelClrType, providerClrType))
                yield return _converter;

            Type _model = _UnwrapNullableType(modelClrType);
            Type _provider = _UnwrapNullableType(providerClrType);

            if (_provider is null)
                foreach (ITypeMappingInfo _mapping in SchemaManager.Mappings[_model].Values)
                    yield return _mapping.ToValueConverterInfo();

            else if (SchemaManager.HasMapping(_model, _provider, out ITypeMappingInfo _mapping))
                yield return _mapping.ToValueConverterInfo();
        }

        private static Type _UnwrapNullableType(Type type)
        {
            if (type is null)
                return null;
            return Nullable.GetUnderlyingType(type) ?? type;
        }
    }
}
