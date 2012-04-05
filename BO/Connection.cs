using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace BO
{
    [ActiveRecord("connections", Lazy = true)]
    public class Connection : ActiveRecordBase<Connection>
    {
        private Baseword _baseword;
        private int _id;
        private GramFunction _gramFunction;
        private Flexion _flexion;

        [PrimaryKey("id")]
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [BelongsTo("basicwordid")]
        public virtual Baseword Baseword
        {
            get { return _baseword; }
            set { _baseword = value; }
        }

        [BelongsTo("functionid")]
        public virtual GramFunction GramFunction
        {
            get { return _gramFunction; }
            set { _gramFunction = value; }
        }
          
        [BelongsTo("wordid")]
        public virtual Flexion Flexion
        {
            get { return _flexion; }
            set { _flexion = value; }
        }
        
        public static bool Exists(Baseword bw, Flexion flexion, GramFunction gramFunction)
        {
            return Exists(typeof (Connection), Expression.Eq("Baseword", bw), Expression.Eq("Flexion", flexion),
                          Expression.Eq("GramFunction", gramFunction));
        }

        public static Connection FindByBasewordAndFunction(Baseword bw, GramFunction gramFunction)
        {
            if (Exists(typeof(Connection), Expression.Eq("Baseword", bw),
                             Expression.Eq("GramFunction", gramFunction)))
                return (Connection)FindFirst(typeof(Connection), Expression.Eq("Baseword", bw),
                                 Expression.Eq("GramFunction", gramFunction));
            else return null;
        }
    }
}
