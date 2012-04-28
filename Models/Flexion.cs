using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace Models
{
    [ActiveRecord("words", Lazy = true)]
    public class Flexion : ActiveRecordBase<Flexion>
    {
        private int _id;
        private string _text;
        private IList<Connection> _connections;

        public Flexion()
        {
            
        }

        public Flexion(string text) : this()
        {
            _text = text;
        }

        [PrimaryKey("id")]
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Property("word", Unique = true)]
        public virtual string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        [HasMany(typeof(Connection), ColumnKey = "wordid", Lazy = true, Table = "connections", Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public virtual IList<Connection> Connections
        {
            get { return _connections;}
            set { _connections = value; }
        }

        public static Flexion GetOrCreateWith(string text)
        {
            if (Exists(typeof(Flexion), Expression.Eq("Text", text)))
            {
                return (Flexion)FindFirst(typeof(Flexion), Expression.Eq("Text", text));
            }
            else
            {
                var flexion = new Flexion(text);
                flexion.Create();
                return flexion;
            }
        }
    }
}
