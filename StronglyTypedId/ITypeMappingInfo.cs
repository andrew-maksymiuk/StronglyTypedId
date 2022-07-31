using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StronglyTypedId
{
    public interface ITypeMappingInfo
    {
        Type Model { get; }
        Type Provider { get; }
        ValueConverter GetValueConverter();
    }
}
