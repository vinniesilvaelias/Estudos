using Estudos.LG.NHibernate.Models;
using FluentNHibernate.Mapping;

namespace Estudos.LG.NHibernate.Mapping
{
    public class CostumerMap : ClassMap<Costumer>
    {
        public CostumerMap()
        {
            Table("Costumer");
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.FirstName, "FirstName").Length(50).Not.Nullable();
            Map(x => x.LastName, "LastName").Length(50).Not.Nullable();
        }
    }
}
