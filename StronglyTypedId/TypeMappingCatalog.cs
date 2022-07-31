namespace StronglyTypedId
{
    public class TypeMappingCatalog : Dictionary<Type, TypeMappingDictionary>
    {
        public TypeMappingCatalog()
        {

        }

        internal TypeMappingCatalog(in IEnumerable<ITypeMapping> mappings)
        {
            foreach (ITypeMapping _item in mappings)
            {
                TypeMappingInfo _info = new(_item);
                TryAdd(_info.Model, _info.Provider, _info);
            }
        }

        public bool TryAdd(Type model, Type provider, ITypeMappingInfo value)
        {
            if (!TryGetValue(model, out TypeMappingDictionary _dict))
            {
                _dict = new TypeMappingDictionary(model);
                TryAdd(model, _dict);
            }
            return _dict.TryAdd(provider, value);
        }

        public bool TryGetValue(Type model, Type provider, out ITypeMappingInfo value)
        {
            if (TryGetValue(model, out TypeMappingDictionary _dict)
                && _dict.TryGetValue(provider, out value))
                return true;

            value = default;
            return false;
        }
    }
}
