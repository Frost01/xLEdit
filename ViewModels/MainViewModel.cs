using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Models;

namespace ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<LanguageViewModel> _languages;

        public ObservableCollection<LanguageViewModel> Languages
        {
            get { return _languages; }
            set
            {
                this.SetPropertyValue(ref _languages, value, () => Languages);
            }
        }

        public MainViewModel()
        {
            _languages = new ObservableCollection<LanguageViewModel>();
            var languages = Models.Languages.GetAll();
            foreach (Models.Language languageModel in languages){
                Languages.Add(new LanguageViewModel(languageModel));
            }
        }
    }
}
