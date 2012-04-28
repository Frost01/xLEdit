using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace Models
{
    [ActiveRecord("types")]
    public class Wordtype : ActiveRecordBase<Wordtype>
    {
        private int _id;
        private string _text;
        private IList<GramFunction> _gramFunctions;

        [PrimaryKey("id")]
        public virtual int Id { get { return _id; } set { _id = value; } }

        [Property("type")]
        public virtual string Text { get { return _text; } set { _text = value; } }
    }
}
