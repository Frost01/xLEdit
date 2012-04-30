
namespace xLEditSilverApp.Web.ServiceDomain
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
    public class LanguageContext : DomainService
    {
        public LanguageContext()
        {
            Utils.InitializeCasteActiveRecordFramework();
        }

        public IEnumerable<Language> GetLanguages()
        {
            return Languages.GetAll();
        }
    }
}


