using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace BO
{
    [ActiveRecord("basewords")]
    public class Baseword : ActiveRecordBase<Baseword>
    {
        private int _id;
        private string _text;
        private Language _language;
        private Wordtype _wordType;
        private IList<GramFunction> _gramFunctions;
        private IList _connections;
        private IList _flexions;
        private string _comment;
        private bool _isLocked;

        [PrimaryKey("id")]
        public virtual int Id { get { return _id; } set { _id = value; } }

        [Property("word")]
        public virtual string Text { get { return _text; } set { _text = value; } }

        [BelongsTo("langid")]
        public virtual Language Lang
        {
            get { return _language; }
            set { _language = value; }
        }

        [BelongsTo("typeid")]
        public virtual Wordtype WordType
        {
            get { return _wordType; }
            set { _wordType = value; }
        }

        [HasMany(typeof(Connection), ColumnKey = "basicwordid", Table = "connections", Cascade = ManyRelationCascadeEnum.SaveUpdate, Lazy = true)]
        public virtual IList Connections
        {
            get { return _connections; }
            set { _connections = value; }
        }

        [HasAndBelongsToMany(typeof(GramFunction), Table = "connections", ColumnKey = "basicwordid", ColumnRef = "functionid", Inverse = true, Lazy = true)]
        public virtual IList<GramFunction> GramFunctions
        {
            get { return _gramFunctions; }
            set { _gramFunctions = value; }
        }

        [HasAndBelongsToMany(typeof(Flexion), Table = "connections", ColumnKey = "basicwordid", ColumnRef = "wordid", Lazy = true, Inverse = true)]
        public virtual IList Flexions
        {
            get { return _flexions; }
            set { _flexions = value; }
        }

        [Property("comment")]
        public virtual string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        [Property("islocked")]
        public virtual bool IsLocked
        {
            get { return _isLocked; }
            set { _isLocked = value; }
        }

        public static Baseword FindByTextLanguageType(string text, Language lang, Wordtype type)
        {
            return
                (Baseword)
                FindFirst(typeof (Baseword), Expression.Eq("Text", text), Expression.Eq("Lang", lang),
                          Expression.Eq("WordType", type));
        }
    }
}
