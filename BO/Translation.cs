using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace BO
{
    [ActiveRecord("translations")]
    public class Translation : ActiveRecordBase<Translation>
    {
        private int _id;
        private Baseword _basewordFrom;
        private Baseword _basewordTo;
        private int _pos;

        [PrimaryKey("id")]
        public virtual int Id { get { return _id; } set { _id = value; } }

        [BelongsTo("id1")]
        public virtual Baseword BasewordFrom
        {
            get { return _basewordFrom; }
            set { _basewordFrom = value; }
        }

        [BelongsTo("id2")]
        public virtual Baseword BasewordTo
        {
            get { return _basewordTo; }
            set { _basewordTo = value; }
        }

        [Property("pos")]
        public virtual int Position { get { return _pos; } set { _pos = value; } }

        public static void InsertIfNotExists(Baseword fBaseword, Baseword tBaseword, int position = 0, bool withBothDirection = false)
        {
            if (!Exists(typeof(Translation), Expression.Eq("BasewordFrom", fBaseword), Expression.Eq("BasewordTo", tBaseword)))
            {
                var translation = new Translation();
                translation.BasewordFrom = fBaseword;
                translation.BasewordTo = tBaseword;
                if (position != 0) translation.Position = position;
                translation.Save();

                if (withBothDirection)
                {
                    InsertIfNotExists(tBaseword,fBaseword,position,false);
                }
            }
        }
    }
}
