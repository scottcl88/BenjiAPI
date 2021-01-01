using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class DocumentTagMap : ClassMap<DocumentTag>
    {
        public DocumentTagMap()
        {
            Table("DocumentTag");
            Id(x => x.DocumentTagId).Not.Nullable();
            Map(x => x.TagName).Not.Nullable();
            Map(x => x.Description).Nullable();
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted).Nullable();
        }
    }
}