using AuroraProject.Aplicacao;
using AuroraProject.Dominio;
using AuroraProject.Infra;
using AutoMapper;
using FluentNHibernate.Cfg;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;

namespace AuroraProject.IoC;

public class InjectorBoostrapper
{
    public static void RegistrarServicos(IServiceCollection servicos, IConfiguration configuracao)
    {
        servicos.AddSingleton<ISessionFactory>(factory =>
        {
            try
            {
                return Fluently.Configure().Database(() =>
                {
                    string connectionString = configuracao.GetSection("Database:Postgresql").Value;

                    return FluentNHibernate.Cfg.Db.PostgreSQLConfiguration.PostgreSQL83
                        .FormatSql()
                        .ShowSql()
                        .ConnectionString(connectionString);
                })
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProdutoMap>())
                .CurrentSessionContext("call")
                .BuildSessionFactory();
            }
            catch (Exception exception)
            {
                throw new Exception("Falha ao configurar Fluently", exception);
            }
        });

        servicos.AddScoped(factory =>
        {
            return factory.GetService<ISessionFactory>().OpenSession();
        });

        MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.AddProfile<ProdutoProfile>();
        });

        IMapper mapper = mapperConfiguration.CreateMapper();

        servicos.AddSingleton(mapper);

        servicos.Scan(scan => scan
            .FromAssemblyOf<ProdutosAppServico>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        servicos.Scan(scan => scan
            .FromAssemblyOf<ProdutosRepositorio>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        servicos.Scan(scan => scan
            .FromAssemblyOf<ProdutosServico>()
            .AddClasses(x => x.Where(y => y.Name.EndsWith("Servico")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}
