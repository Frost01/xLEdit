using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using BO;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace xLEdit
{
    public class Importer
    {
        private DataTable _dt;
        private Language _language;
        private Language _targetLanguage;
        private Wordtype _wordtype;

        public Importer(DataTable dt, Language language, Wordtype wordtype, Language targetLanguage)
        {
            _dt = dt;
            _language = language;
            _wordtype = wordtype;
            _targetLanguage = targetLanguage;
        }

        public void DoSimpleImport()
        {
            var sb = new StringBuilder();
            foreach (DataRow row in _dt.Rows)
            {
                var baseword = Baseword.GetOrCreateBy(row[0].ToString(), _language, _wordtype);
                baseword.Save();
                var targetBaseword = Baseword.GetOrCreateBy(row[1].ToString(), _targetLanguage, _wordtype);
                targetBaseword.Save();
                Translation.InsertIfNotExists(baseword, targetBaseword, withBothDirection: true);
                sb.AppendLine(baseword.Id + ";" + baseword.Text + ";" + targetBaseword.Id + ";" + targetBaseword.Text);
                Console.Out.WriteLine(string.Format("Added Baseword {0} with Id: {1} and Translation {2}", baseword.Text, baseword.Id, targetBaseword.Text));
            }
            WriteImportLog("SimpleImport.csv",sb.ToString());
        }

        public void DoImport(bool withSpecifics, int specCol = 0)
        {
            var sb = new StringBuilder();
            foreach (DataRow row in _dt.Rows)
            {
                try
                {
                    var karlId = row[0].ToString();
                    // Baseword
                    var bwFrom = Baseword.GetOrCreateBy(row[0].ToString(), _language, _wordtype);
                    // Flexions
                    int numberOfFunctions = GramFunction.NumberOfFunctionsForWordTypeAndLanguage(_wordtype, _language);
                    var flexions = new string[numberOfFunctions];
                    for (int i = 0; i < numberOfFunctions; i++)
                    {
                        flexions[i] = row.ItemArray[2 + i].ToString().Trim();
                    }
                    bwFrom.UpdateFlexions(flexions);
                    // Specialties
                    if (withSpecifics && specCol != 0)
                    {
                        int specId;
                        if (Int32.TryParse(row.ItemArray[specCol].ToString(), out specId))
                        {
                            var specialty = Specialty.Find(specId);
                            var linguisticFeature = LinguisticFeature.GetOrCreate(bwFrom, specialty);
                            if (!bwFrom.LinguisticFeatures.Contains(linguisticFeature))
                                bwFrom.LinguisticFeatures.Add(linguisticFeature);
                        }
                    }
                    bwFrom.Save();
                    // Translation
                    var bwTo = Baseword.FindByTextLanguageType(row.ItemArray.Last().ToString(), _targetLanguage,
                                                               _wordtype);
                    if (bwTo == null)
                    {
                        bwTo = new Baseword();
                        bwTo.Lang = _targetLanguage;
                        bwTo.WordType = _wordtype;
                        bwTo.Text = row.ItemArray.Last().ToString().Trim();
                        bwTo.Save();
                    }
                    int position = 0;
                    Int32.TryParse(row.ItemArray[row.ItemArray.Count() - 2].ToString(), out position);
                    Translation.InsertIfNotExists(bwFrom, bwTo, position);
                    Translation.InsertIfNotExists(bwTo,bwFrom);
                    sb.AppendLine(karlId + ";" + bwFrom.Id + ";" + bwFrom.Text + ";" + bwTo.Id + ";" + bwTo.Text);
                    Console.Out.WriteLine("Imported Baseword: {0} as Item Nr {1} of {2}",bwFrom.Text,_dt.Rows.IndexOf(row), _dt.Rows.Count);
                }
                catch (Exception ex)
                {
                    Logger.Write(string.Format("Import Failed with Error : {0}",ex));
                }
            }
            Importer.WriteImportLog("FullImportLog.csv",sb.ToString());
        }

        public static void WriteImportLog(string fName, string content)
        {
            using (var writer = new StreamWriter(fName))
            {
                writer.Write(content);
            }
        }
    }
}
