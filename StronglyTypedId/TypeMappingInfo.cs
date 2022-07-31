using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace StronglyTypedId
{
    public class TypeMappingInfo : ITypeMappingInfo
    {
        private readonly ITypeMapping _mapping;
        private readonly Type _model;
        private readonly Type _provider;

        internal ITypeMapping Mapping => _mapping;
        public Type Model => _model;
        public Type Provider => _provider;

        internal TypeMappingInfo(in ITypeMapping mapping)
        {
            _mapping = mapping;
            Type[] _generics = GetMappingGenerics(mapping);
            _model = _generics[0];
            _provider = _generics[1];
        }

        internal static Type[] GetMappingGenerics(in ITypeMapping mapping)
        {
            Type _mapping = mapping.GetType();
            Type _obj = typeof(object);
            while (_mapping.BaseType != _obj)
                _mapping = _mapping.BaseType;
            return _mapping.GenericTypeArguments;
        }

        public ValueConverter GetValueConverter() => Mapping.GetValueConverter();
    }
}
