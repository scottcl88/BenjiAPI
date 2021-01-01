using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class HealthMap : ClassMap<Health>
    {
        public HealthMap()
        {
            Table("Health");
            Id(x => x.HealthId);
            Map(x => x.Waist).Nullable();
            Map(x => x.Length).Nullable();
            Map(x => x.Height).Nullable();
            Map(x => x.Weight).Nullable();
            Map(x => x.TailLength).Nullable();
            Map(x => x.MouthCircumference).Nullable();
            Map(x => x.NoseEyeLength).Nullable();
            Map(x => x.FromVet);
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted);
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}