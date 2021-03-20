using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Repository.Mappings;
using System.Data;

namespace Repository
{
    public class NHibernateSession
    {
        protected NHibernateSession()
        {
        }

        public static ISession OpenSession()
        {
            var configuration = new Configuration();

            configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=localhost\\SQLEXPRESS;Database=BenjiDB;Trusted_Connection=True;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
                x.IsolationLevel = IsolationLevel.RepeatableRead;
                x.Timeout = 10;
                x.BatchSize = 10;
            });

            var dbConn = MsSqlConfiguration.MsSql2008
              .ConnectionString("Server=localhost\\SQLEXPRESS;Database=BenjiDB;Trusted_Connection=True;").ShowSql();
            var sessionFactory = Fluently.Configure()
                .Database(dbConn)
                .Mappings(m =>
                {
                    m.FluentMappings
                        .AddFromAssemblyOf<DogMap>();
                })
                    .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}