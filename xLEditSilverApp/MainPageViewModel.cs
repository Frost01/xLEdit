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

namespace xLEditSilverApp
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<LanguageViewModel> _languages;

        public ObservableCollection<LanguageViewModel> Languages
        {
            get { return _languages; }
            set { SetPropertyValue(ref _languages, value, () => Languages); }
        }

        public MainPageViewModel()
        {
            var domainService = new LanguagesServiceDomain();
            LoadOperation<Language> loadop = domainService.Load(domainService.GetLanguagesQuery(), loadop_Completed, null);
        }

        private void loadop_Completed(LoadOperation<Language> loadop)
        {
            Languages = new ObservableCollection<LanguageViewModel>();
            var languages = loadop.Entities;
            foreach (var languageModel in languages)
            {
                Languages.Add(new LanguageViewModel(languageModel));
            }
        }
    }
}
