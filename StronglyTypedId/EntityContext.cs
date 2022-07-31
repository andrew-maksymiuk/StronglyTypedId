using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StronglyTypedId
{
    public abstract class EntityContext : DbContext
    {
        private readonly string _connection;

        public EntityContext(in string connection)
        {
            _connection = connection;
            ChangeTracker.Tracked += _Tracked;
        }

        private void _Tracked(object sender, EntityTrackedEventArgs args)
        {
            if (args.Entry.Entity is Entity _entity)
            {
                if (args.Entry.State == EntityState.Added
                    && _entity.Id > 0)
                {
                    args.Entry.State = EntityState.Unchanged;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder _entityBuilder = modelBuilder.Entity(typeof(TestTable));
            PropertyBuilder _prop = _entityBuilder.Property(nameof(Entity.Id));
            _prop.UseIdentityColumn();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connection, i => i.UseNetTopologySuite())
                .ReplaceService<IValueConverterSelector, TypeMappingSelector>();
        }
    }
}
