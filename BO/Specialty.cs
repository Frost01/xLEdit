using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace BO
{
    [ActiveRecord("specifics")]
    public class Specialty : ActiveRecordBase<Specialty>
    {
        private int _id;
        private string _text;

        [PrimaryKey("id")]
        public virtual int Id { get { return _id; } set { _id = value; } }

        [Property("specialty")]
        public virtual string Text { get { return _text; } set { _text = value; } }
    }
}
