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
        private string _karlId;

        public TranslationImport(DataTable dt, Language langFrom, Language langTo)
        {
            _dt = dt;
            _langFrom = langFrom;
            _langTo = langTo;
        }

        public void DoImport(bool bothDirections)
        {
            var sb = new StringBuilder();
            foreach (DataRow row in _dt.Rows)
            {
                var logString = new StringBuilder();
                _karlId = row[0].ToString();
                if (String.IsNullOrWhiteSpace(row[1].ToString()) || String.IsNullOrWhiteSpace(row[3].ToString())) continue;
                var bwFrom = GetOrCreateBaseword(row[2].ToString(), Wordtype.Find(Int32.Parse(row[1].ToString())), _langFrom);

                var wordtypesRow = 1;
                if (_dt.Columns.Count > 4)
                    wordtypesRow = 4;
                var bwTo = GetOrCreateBaseword(row[3].ToString(), Wordtype.Find(Int32.Parse(row[wordtypesRow].ToString())),_langTo);
                logString.Append(_karlId + ";" + bwFrom.Id + ";" + bwFrom.Text + ";" + 
                                    ";" + bwTo.Id + ";" + bwTo.Text);
                Console.Out.WriteLine("Inserting Translation: {0}", logString);
                Translation.InsertIfNotExists(bwFrom, bwTo, 0, bothDirections);
                sb.AppendLine(logString.ToString());
            }
            using (var writer = new StreamWriter(string.Format("Import_{0}{1}.csv", _langFrom.Text, _langTo.Text)))
            {
                writer.Write(sb.ToString());
            }
        }

        private Baseword GetOrCreateBaseword(string text, Wordtype wordtype, Language language)
        {
            var bwFrom = Baseword.FindByTextLanguageType(text.Trim(), language, wordtype);
            if (bwFrom == null)
            {
                bwFrom = new Baseword { Lang = language, WordType = wordtype, Text = text };
                bwFrom.Save();
            }
            return bwFrom;
        }
    }
}
