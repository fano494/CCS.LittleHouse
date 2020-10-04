using FluentNHibernate.Cfg;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace CCS.LittleHouse.Data.Infraestructure
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString, bool schemaExport, bool logSqlInConsole)
        {
            FluentConfiguration configuration = Fluently.Configure(
               new Configuration().DataBaseIntegration(cfg =>
               {
                   cfg.Dialect<NHibernate.Dialect.SQLiteDialect>();
                   cfg.Driver<NHibernate.Driver.SQLite20Driver>();
                   cfg.ConnectionString = connectionString;
                   cfg.LogFormattedSql = true;
                   cfg.LogSqlInConsole = logSqlInConsole;
               }));
            configuration.Mappings(m =>
            {
                m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
            });

            if (schemaExport)
            {
                configuration.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(false, true, false));
            }

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped<IMapperSession, MapperSession>();

            return services;
        }
    }
}
