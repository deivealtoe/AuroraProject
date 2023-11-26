using AuroraProject.Dominio;
using FluentNHibernate.Mapping;

namespace AuroraProject.Infra;

public class ProdutoMap : ClassMap<Produto>
{
    public ProdutoMap()
    {
        Schema("aurora_project_schema");

        Table("produto");

        Id(x => x.Id).Column("id");

        Map(x => x.Titulo).Column("titulo");
    }
}
