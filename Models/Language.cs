using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [ActiveRecord("languages")]
    public class Language : ActiveRecordBase<Language>
    {

        private int _id;
        private string _text;

        [Key]
        [PrimaryKey("id")]
        public virtual int Id { get { return _id; } set { _id = value; } }

        [Property("englishName")]
        public virtual string Text { get { return _text; } set { _text = value; } }

        public List<Language> FetchLanguages()
        {
            var languages = Language.FindAll().ToList();
            return languages;
        }

    }
}
