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
                // import swahili nouns
                //var loader = new CsvLoader("swNouns.txt", '\t');
                //var importer = new Importer(loader.DataTable, Language.Find(7), Wordtype.Find(15), Language.Find(1));
                //importer.DoImport(true,5);

                // import yoruba
                var loader = new CsvLoader("yoAdj.txt", '\t');
                var importer = new Importer(loader.DataTable, Language.Find(9), Wordtype.Find(1), Language.Find(1));
                importer.DoSimpleImport();

                //var loader = new CsvLoader();
                //loader.Load("import_prep.txt", '\t');
                //var import = new TranslationImport(loader.DataTable, Language.Find(1), Language.Find(4),
                //                                   Wordtype.Find(12));
                //import.DoImport();


                //var loader = new CsvLoader("deleteBasewords.txt", '\t');
                //Basewords.DeleteByIds(loader.DataTable);

                //var loader = new CsvLoader("updateFlexions.txt",'\t');
                //Basewords.UpdateConnections(loader.DataTable);


                Console.Out.WriteLine("Finished import...");
                Console.ReadKey();
            }

        }
    }
}
