namespace StronglyTypedId
{
    public class TypeMappingDictionary : Dictionary<Type, ITypeMappingInfo>
    {
        private readonly Type _model;

        public virtual Type Model => _model;

        public TypeMappingDictionary(in Type model)
        {
            _model = model;
        }
    }
}
