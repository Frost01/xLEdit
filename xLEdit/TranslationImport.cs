using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Models;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace xLEdit
{
    public class TranslationImport
    {
        private DataTable _dt;
        private Language _langFrom;
        private Language _langTo;
        private Wordtype _wordtype;
        private string _karlId;

        public TranslationImport(DataTable dt, Language langFrom, Language langTo, Wordtype wordtype)
        {
            _dt = dt;
            _langFrom = langFrom;
            _langTo = langTo;
            _wordtype = wordtype;
        }

        public void DoImport()
        {
            var sb = new StringBuilder();
            foreach (DataRow row in _dt.Rows)
            {
                try
                {
                    StringBuilder logString = new StringBuilder();
                    var isFromNew = false;
                    _karlId = row[0].ToString();
                    logString.Append(_karlId + ";");
                    var bwFrom = Baseword.FindByTextLanguageType(row[1].ToString().Trim(), _langFrom, _wordtype);
                    if (bwFrom == null)
                    {
                        isFromNew = true;
                        bwFrom = new Baseword();
                        bwFrom.Lang = _langFrom;
                        bwFrom.WordType = _wordtype;
                        bwFrom.Text = row[1].ToString().Trim();
                        bwFrom.Save();
                    }
                    logString.Append(isFromNew + ";" +bwFrom.Id + ";" + bwFrom.Text + ";");

                    // hole varierende wortart wenn angegeben
                    var newWordType = _wordtype;
                    if (_dt.Columns.Count > 3)
                    {
                        int wordtypeId;
                        if (Int32.TryParse(row[3].ToString(), out wordtypeId))
                        {
                            newWordType = Wordtype.Find(wordtypeId);
                        }
                    }

                    var isToNew = false;
                    var bwTo = Baseword.FindByTextLanguageType(row[2].ToString().Trim(), _langTo, newWordType);
                    if (bwTo == null)
                    {
                        isToNew = true;
                        bwTo = new Baseword();
                        bwTo.Lang = _langTo;
                        bwTo.WordType = newWordType;
                        bwTo.Text = row[2].ToString().Trim();
                        bwTo.Save();
                    }
                    logString.Append(isToNew+ ";" + bwTo.Id+";"+bwTo.Text);

                    Console.Out.WriteLine("Inserting Translation: {0}", logString.ToString());
                    Translation.InsertIfNotExists(bwFrom, bwTo);
                    sb.AppendLine(logString.ToString());
                }
                catch (Exception ex)
                {
                    Logger.Write(string.Format("Translation Import Failed with Error : {0}",  ex.Message));
                    using (var writer = new StreamWriter(string.Format("ImportLog.csv")))
                    {
                        writer.Write(sb.ToString());
                    }
                }
            }
            using (var writer = new StreamWriter(string.Format("ImportLog.csv")))
            {
                writer.Write(sb.ToString());
            }
        }



    }
}
