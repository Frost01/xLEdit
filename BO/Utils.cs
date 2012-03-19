using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;

namespace BO
{
    public static class Utils
    {
        private static SessionScope _sessionScope;
        public static void InitializeCasteActiveRecordFramework()
        {
            var config = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(config, typeof(Baseword), typeof(Language), typeof(Wordtype), typeof(Flexion), typeof(GramFunction), typeof(Connection), typeof(Translation));
            _sessionScope = new SessionScope();
        }

        public static SessionScope Scope { get { return _sessionScope; } }
    }
}
