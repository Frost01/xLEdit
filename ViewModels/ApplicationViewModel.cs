using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace ViewModels
{
    public class ApplicationViewModel : BaseViewModel
    {
        private BaseViewModel _mainViewModel;

        public BaseViewModel MainViewModel
        {
            get { return _mainViewModel; }
            private set { _mainViewModel = value; }
        }

        public ApplicationViewModel()
        {
            Utils.InitializeCasteActiveRecordFramework();
            _mainViewModel = new MainViewModel();
        }
    }
}
