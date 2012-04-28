using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace ViewModels
{
    public class LanguageViewModel : BaseViewModel
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                this.SetPropertyValue(ref _id, value, () => Id);
            }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                this.SetPropertyValue(ref _text, value, () => Text);
            }
        }

        public LanguageViewModel(Language language)
        {
            Id = language.Id;
            Text = language.Text;
        }
    }
}
