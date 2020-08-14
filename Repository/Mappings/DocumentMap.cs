using FluentNHibernate.Mapping;
using Repository.Models;
using NHibernate;

namespace Repository.Mappings
{
    public class DocumentMap : ClassMap<Document>
    {
        public DocumentMap()
        {
            Table("Document");
            Id(x => x.DocumentId).Not.Nullable();
            Map(x => x.FileName).Not.Nullable();
            Map(x => x.Description).Nullable();
            Map(x => x.Type).Not.Nullable();
            Map(x => x.ByteSize).Not.Nullable();
            References(x => x.Folder, "FolderId").Not.Nullable();
            Map(x => x.DocumentKey).Not.Nullable();
            Map(x => x.LastViewed).Not.Nullable();
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted).Nullable();
        }
    }
}
