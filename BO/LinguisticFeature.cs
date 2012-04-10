using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using NHibernate.Criterion;

namespace BO
{
    [ActiveRecord("basicwordspecifics", Lazy = true)]
    public class LinguisticFeature : ActiveRecordBase<LinguisticFeature>
    {
        private Baseword _baseword;
        private int _id;
        private Specialty _specialty;

        [PrimaryKey("id")]
        public virtual int Id { get { return _id; } set { _id = value; } }

        [BelongsTo("basicwordid")]
        public virtual Baseword Baseword { get { return _baseword; } set { _baseword = value; } }

        [BelongsTo("specificsid")]
        public virtual Specialty Specialty { get { return _specialty; } set { _specialty = value; } }

        public static LinguisticFeature GetOrCreate(Baseword bw, Specialty specialty)
        {
            if (Exists(typeof(LinguisticFeature), Expression.Eq("Baseword", bw), Expression.Eq("Specialty", specialty)))
            {
                return
                    (LinguisticFeature)
                    FindFirst(typeof(LinguisticFeature), Expression.Eq("Baseword", bw),
                              Expression.Eq("Specialty", specialty));
            }
            else
            {
                var linguisticFeature = new LinguisticFeature();
                linguisticFeature.Baseword = bw;
                linguisticFeature.Specialty = specialty;
                linguisticFeature.Create();
                return linguisticFeature;
            }
        }
    }
}
