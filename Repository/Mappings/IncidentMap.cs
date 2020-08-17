using FluentNHibernate.Mapping;
using Repository.Models;
using NHibernate;

namespace Repository.Mappings
{
    public class IncidentMap : ClassMap<Incident>
    {
        public IncidentMap()
        {
            Table("Incident");
            Id(x => x.IncidentId).Not.Nullable();
            Map(x => x.Title).Nullable();
            Map(x => x.Description).Nullable();
            Map(x => x.IncidentType).CustomType<IncidentType>().Not.Nullable();
            Map(x => x.IncidentDate).Not.Nullable();
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted).Nullable();
            References(x => x.Dog, "DogId").Not.Nullable();
        }
    }
}