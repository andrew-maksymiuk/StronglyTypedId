using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StronglyTypedId
{
    public static class SchemaExtensions
    {
        public static PropertyBuilder UseIdentityColumn(this PropertyBuilder propertyBuilder)
        {
            propertyBuilder.ValueGeneratedOnAdd();
            propertyBuilder.Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            return propertyBuilder;
        }

        public static ValueConverterInfo ToValueConverterInfo(this ITypeMappingInfo mapping)
        {
            return new(mapping.Model, mapping.Provider, i => mapping.GetValueConverter());
        }
    }
}
