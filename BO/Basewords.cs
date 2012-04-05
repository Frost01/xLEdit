using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using NHibernate;
using NHibernate.Criterion;

namespace BO
{
    public class Basewords
    {
        public static void DeleteByIds(DataTable dt)
        {
            ISession session = Utils.GetSession();
            foreach (DataRow row in dt.Rows)
            {
                int id;
                if (Int32.TryParse(row[0].ToString(), out id))
                {
                    var hql = string.Format("delete from Baseword where Id = {0}", id);
                    var query = session.CreateQuery(hql);
                    query.ExecuteUpdate();
                }
                else
                {
                    Logger.Write(string.Format("Deleting Basewords failed in row: {0}", dt.Rows.IndexOf(row)));
                }
            }
        }

        public static void UpdateConnections(DataTable dt)
        {
            using (var transaction = new TransactionScope(TransactionMode.New))
            {
                foreach (DataRow row in dt.Rows)
                {
                    int id;
                    if (Int32.TryParse(row[0].ToString(), out id))
                    {
                        var bw = Baseword.Find(id);
                        for (int i = 1; i < row.ItemArray.Count(); i++)
                        {
                            var flexion = Flexion.GetOrCreateWith(row.ItemArray[i].ToString());
                            var connection = Connection.FindByBasewordAndFunction(bw, bw.GramFunctions[i - 1]);
                            if (connection == null)
                            {
                                connection = new Connection();
                                connection.Flexion = flexion;
                                connection.Baseword = bw;
                                connection.GramFunction = bw.GramFunctions[i - 1];
                                bw.Connections.Add(connection);
                                //bw.Update();
                            }
                            if (!connection.Flexion.Equals(flexion))
                            {
                                connection.Flexion = flexion;
                                //connection.Update();
                            }
                            bw.Save();
                        }
                        Console.Out.WriteLine(string.Format("{3}: Updated Baseword {0}/{1} with id:{2}",
                                                            dt.Rows.IndexOf(row), dt.Rows.Count, bw.Id,
                                                            DateTime.Now.ToString(CultureInfo.InvariantCulture)));
                    }
                }
                transaction.Flush();
                transaction.VoteCommit();
            }
        }
    }
}
