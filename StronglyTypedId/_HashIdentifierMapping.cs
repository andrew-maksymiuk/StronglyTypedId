namespace StronglyTypedId
{
    internal class _HashIdentifierMapping : TypeMapping<HashIdentifier, int>
    {
        public override HashIdentifier ToModel(int provider)
        {
            return new(provider);
        }

        public override int ToProvider(HashIdentifier model)
        {
            return model.Value;
        }
    }
}
