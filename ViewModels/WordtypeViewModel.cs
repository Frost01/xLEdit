using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace ViewModels
{
    public class WordtypeViewModel : BaseViewModel
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { SetPropertyValue(ref _id, value, () => Id); }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { SetPropertyValue(ref _text, value, () => Text); }
        }

        public WordtypeViewModel(Wordtype wordtype)
        {
            Id = wordtype.Id;
            Text = wordtype.Text;
        }
    }
}
