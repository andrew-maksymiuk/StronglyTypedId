using System.ComponentModel.DataAnnotations;

namespace StronglyTypedId
{
    public abstract class Entity
    {

        private HashIdentifier _id;

        [Key]
        public virtual HashIdentifier Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
