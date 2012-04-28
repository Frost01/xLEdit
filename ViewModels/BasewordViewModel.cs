using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.ComponentModel;

namespace ViewModels
{
    public class BasewordViewModel : BaseViewModel
    {
        public BasewordViewModel(Baseword baseword)
        {
            _id = baseword.Id;
            _text = baseword.Text;
        }

        #region Properties
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

        #endregion
    }
}
