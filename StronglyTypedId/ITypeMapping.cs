using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StronglyTypedId
{
    internal interface ITypeMapping
    {
        object ToModel(object provider);
        object ToProvider(object model);
        ValueConverter GetValueConverter();
    }
}
