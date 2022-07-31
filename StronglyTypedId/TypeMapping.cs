using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StronglyTypedId
{
    public abstract class TypeMapping<TModel, TProvider> : ITypeMapping
    {
        public virtual ValueConverter<TModel, TProvider> GetValueConverter()
        {
            return new ValueConverter<TModel, TProvider>(i => ToProvider(i), i => ToModel(i));
        }

        public abstract TModel ToModel(TProvider provider);

        public abstract TProvider ToProvider(TModel model);

        ValueConverter ITypeMapping.GetValueConverter()
        {
            return GetValueConverter();
        }

        object ITypeMapping.ToModel(object provider)
        {
            return ToModel((TProvider)provider);
        }

        object ITypeMapping.ToProvider(object model)
        {
            return ToProvider((TModel)model);
        }
    }
}
