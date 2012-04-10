using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using NHibernate;

namespace BO
{
    public static class Utils
    {
        private static SessionScope _sessionScope;
        public static void InitializeCasteActiveRecordFramework()
        {
            var config = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(config, typeof(Baseword), typeof(Language), typeof(Wordtype), typeof(Flexion), typeof(GramFunction), typeof(Connection), typeof(Translation), typeof(Specialty), typeof(LinguisticFeature));
            _sessionScope = new SessionScope();
        }

        public static ISession GetSession()
        {
            ISessionFactoryHolder holder = ActiveRecordMediator.GetSessionFactoryHolder();
            ISessionScope activeScope = holder.ThreadScopeInfo.GetRegisteredScope();
            ISession session = null;
            var key = holder.GetSessionFactory(typeof (ActiveRecordBase));
            if (activeScope == null)
            {
                session = holder.CreateSession(typeof (ActiveRecordBase));
            }
            else
            {
                if (activeScope.IsKeyKnown(key))
                    session = activeScope.GetSession(key);
                else
                {
                    session = holder.GetSessionFactory(typeof (ActiveRecordBase)).OpenSession();
                }
            }
            return session;
        }

        public static SessionScope Scope { get { return _sessionScope; } }
    }
}
