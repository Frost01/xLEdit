using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Models;

namespace xLEditSilverApp
{
    public class LanguageViewModel
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public LanguageViewModel(Language language)
        {
            Id = language.Id;
            Text = language.Text;
        }
    }
}
