using FluentNHibernate.Mapping;
using Repository.Models;

namespace Repository.Mappings
{
    public class FolderMap : ClassMap<Folder>
    {
        public FolderMap()
        {
            Table("Folder");
            Id(x => x.FolderId).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Nullable();
            Map(x => x.LastViewed).Not.Nullable();
            Map(x => x.Created).Not.Nullable();
            Map(x => x.Modified).Not.Nullable();
            Map(x => x.Deleted).Nullable();
        }
    }
}