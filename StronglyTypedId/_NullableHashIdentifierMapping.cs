namespace StronglyTypedId
{
    internal class _NullableHashIdentifierMapping : TypeMapping<HashIdentifier?, int?>
    {
        public override HashIdentifier? ToModel(int? provider)
        {
            if (provider.HasValue)
                return new(provider.Value);
            return null;
        }

        public override int? ToProvider(HashIdentifier? model)
        {
            return model?.Value;
        }
    }
}
