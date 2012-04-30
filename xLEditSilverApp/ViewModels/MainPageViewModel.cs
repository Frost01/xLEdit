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
using System.Collections.ObjectModel;
using xLEditSilverApp.Web;
using System.ServiceModel.DomainServices.Client;
using Models;
using System.Collections.Generic;
using xLEditSilverApp.Web.ServiceDomain;

namespace xLEditSilverApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<LanguageViewModel> _languages;

        public ObservableCollection<LanguageViewModel> Languages
        {
            get { return _languages; }
            set { SetPropertyValue(ref _languages, value, () => Languages); }
        }

        private ObservableCollection<WordtypeViewModel> _wordtypes;

        public ObservableCollection<WordtypeViewModel> Wordtypes
        {
            get { return _wordtypes; }
            set { SetPropertyValue(ref _wordtypes, value, () => Wordtypes); }
        }

        public MainPageViewModel()
        {
            var languageContext = new LanguageContext();
            languageContext.Load(languageContext.GetLanguagesQuery(), LanguageLoadop_Completed, null);
            var wordtypeContext = new WordTypeContext();
            wordtypeContext.Load(wordtypeContext.GetWordtypesQuery(), WordtypeLoadop_Completed, null);
        }

        private void LanguageLoadop_Completed(LoadOperation<Language> loadop)
        {
            Languages = new ObservableCollection<LanguageViewModel>();
            foreach (var languageModel in loadop.Entities)
                Languages.Add(new LanguageViewModel(languageModel));
        }

        private void WordtypeLoadop_Completed(LoadOperation<Wordtype> loadop)
        {
            Wordtypes = new ObservableCollection<WordtypeViewModel>();
            foreach (var wordtypeModel in loadop.Entities)
                Wordtypes.Add(new WordtypeViewModel(wordtypeModel));
        }
    }
}
