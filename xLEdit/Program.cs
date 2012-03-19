using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using BO;
using Castle.ActiveRecord;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using NHibernate.Criterion;

namespace xLEdit
{
    class Program
    {
        static void Main(string[] args)
        {
            Utils.InitializeCasteActiveRecordFramework();

            using (new SessionScope())
            {
                var loader = new CsvLoader();
                loader.Load("import_prep.txt", '\t');
                var import = new TranslationImport(loader.DataTable, Language.Find(1), Language.Find(4),
                                                   Wordtype.Find(12));
                import.DoImport();
                Console.Out.WriteLine("Finished import...");
                Console.ReadKey();
            }




            //Logger.Write("Program started...","Import");
            //using (new SessionScope())
            //{
            //    var bw = Baseword.Find(2343);

            //    Console.WriteLine(bw.Text + " - " + bw.Comment);

            //    foreach (Flexion flexion in bw.Flexions)
            //    {
            //        Console.WriteLine(flexion.Id + " - " +flexion.Text);
            //    }

            //    foreach (GramFunction gramFunction in bw.GramFunctions)
            //    {
            //        var propertyDic = new Dictionary<string, object>();
            //        propertyDic.Add("Baseword",bw);
            //        propertyDic.Add("GramFunction",gramFunction);

            //        var connection = Connection.FindFirst(Expression.AllEq(propertyDic));

            //        Console.WriteLine(connection.GramFunction.Id + " - "+ connection.Flexion.Text);
            //    }
            //    //bw.Comment = "Test";
            //    //bw.Update();
            //}
            //Console.ReadKey();
        }
    }
}
