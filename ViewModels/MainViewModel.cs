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

        private ObservableCollection<WordtypeViewModel> _wordtypes;

        public ObservableCollection<WordtypeViewModel> Wordtypes
        {
            get { return _wordtypes; }
            set { SetPropertyValue(ref _wordtypes, value, () => Wordtypes); }
        }

        public MainViewModel()
        {
            _languages = new ObservableCollection<LanguageViewModel>();
            foreach (Models.Language languageModel in Models.Languages.GetAll())
            {
                Languages.Add(new LanguageViewModel(languageModel));
            }
            _wordtypes = new ObservableCollection<WordtypeViewModel>();
            foreach (var wordtypeModel in Models.Wordtype.FetchAll())
            {
                Wordtypes.Add(new WordtypeViewModel(wordtypeModel));
            }
        }
    }
}
