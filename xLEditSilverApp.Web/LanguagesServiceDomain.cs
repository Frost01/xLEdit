
namespace xLEditSilverApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
using Models;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class LanguagesServiceDomain : DomainService
    {
        public LanguagesServiceDomain()
        {
            Utils.InitializeCasteActiveRecordFramework();
        }

        public IEnumerable<Language> GetAll()
        {
            return Languages.GetAll();
        }

        public IEnumerable<Language> GetLanguages()
        {
            Language language = new Language();
            return language.FetchLanguages();
        }
    }
}


