using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace BO
{
    [ActiveRecord("functions", Lazy = true)]
    public class GramFunction : ActiveRecordBase<GramFunction>
    {
        private int _id;
        private string _text;
        private Language _language;
        private Wordtype _wordtype;

        [PrimaryKey("id")]
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Property("function", NotNull = true)]
        public virtual string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        [BelongsTo("langid")]
        public virtual Language Language
        {
            get { return _language; }
            set { _language = value; }
        }

        [BelongsTo("typeid")]
        public virtual Wordtype Wordtype
        {
            get { return _wordtype; }
            set { _wordtype = value; }
        }

        public static int NumberOfFunctionsForWordTypeAndLanguage(Wordtype wordtype, Language language)
        {
            return
                FindAll(typeof (GramFunction), Expression.Eq("Wordtype", wordtype),
                        Expression.Eq("Language", language)).Length;
        }

        public static IList<GramFunction> FindByWordTypeAndLanguage(Wordtype wordtype, Language language)
        {
            var functionArray = FindAll(typeof (GramFunction), Expression.Eq("Wordtype", wordtype),
                           Expression.Eq("Language", language));
            return functionArray.Cast<GramFunction>().ToList();
        } 
    }
}
