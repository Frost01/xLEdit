using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Models;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using NHibernate;
using NHibernate.Criterion;

namespace xLEdit
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.InitializeCasteActiveRecordFramework();

            using (var sessionScope = new SessionScope())
            {
                var loader = new CsvLoader("EnDeTranslations.txt", '\t');
                var import = new TranslationImport(loader.DataTable, Language.Find(3), Language.Find(1));
                import.DoImport(true);

                Console.Out.WriteLine("Finished import...");
                Console.ReadKey();
            }

        }
    }
}
