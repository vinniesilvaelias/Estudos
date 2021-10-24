using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System;

using Environment = NHibernate.Cfg.Environment;

namespace Estudos.LG.NHibernate.Services
{
    public class Session
    {
        private static ISessionFactory _sessionFactory;
        public static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = GetConfiguration().BuildSessionFactory();

            }
            var sessao = _sessionFactory.OpenSession();
            sessao.FlushMode = FlushMode.Commit;
            return sessao;
        }
        public static FluentConfiguration GetConfiguration()
        {
            var configuracaoNHibernate = new Configuration();
            configuracaoNHibernate.SetProperty(Environment.ConnectionString,
            @"Data Source=DESKTOP-4H004PB\SQL2019;Initial Catalog=estudo;User Id=sa;Password=754vini!@#");
            configuracaoNHibernate.SetProperty(Environment.Dialect, "NHibernate.Dialect.MsSql2012Dialect");
            configuracaoNHibernate.SetProperty(Environment.ConnectionProvider,
                "NHibernate.Connection.DriverConnectionProvider");

            var configuracaoFluent = Fluently.Configure(configuracaoNHibernate)
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(Session).Assembly));

            return configuracaoFluent;

        }
    }
}
