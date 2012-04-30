//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    
    
    /// <summary>
    /// The 'Language' entity class.
    /// </summary>
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/Models")]
    public sealed partial class Language : Entity
    {
        
        private int _id;
        
        private string _text;
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        partial void OnTextChanging(string value);
        partial void OnTextChanged();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Language"/> class.
        /// </summary>
        public Language()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets or sets the 'Id' value.
        /// </summary>
        [DataMember()]
        [Editable(false, AllowInitialValue=true)]
        [Key()]
        [RoundtripOriginal()]
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if ((this._id != value))
                {
                    this.OnIdChanging(value);
                    this.ValidateProperty("Id", value);
                    this._id = value;
                    this.RaisePropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }
        
        /// <summary>
        /// Gets or sets the 'Text' value.
        /// </summary>
        [DataMember()]
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                if ((this._text != value))
                {
                    this.OnTextChanging(value);
                    this.RaiseDataMemberChanging("Text");
                    this.ValidateProperty("Text", value);
                    this._text = value;
                    this.RaiseDataMemberChanged("Text");
                    this.OnTextChanged();
                }
            }
        }
        
        /// <summary>
        /// Computes a value from the key fields that uniquely identifies this entity instance.
        /// </summary>
        /// <returns>An object instance that uniquely identifies this entity instance.</returns>
        public override object GetIdentity()
        {
            return this._id;
        }
    }
}
namespace xLEditSilverApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    
    
    /// <summary>
    /// Context for the RIA application.
    /// </summary>
    /// <remarks>
    /// This context extends the base to make application services and types available
    /// for consumption from code and xaml.
    /// </remarks>
    public sealed partial class WebContext : WebContextBase
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the WebContext class.
        /// </summary>
        public WebContext()
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the context that is registered as a lifetime object with the current application.
        /// </summary>
        /// <exception cref="InvalidOperationException"> is thrown if there is no current application,
        /// no contexts have been added, or more than one context has been added.
        /// </exception>
        /// <seealso cref="System.Windows.Application.ApplicationLifetimeObjects"/>
        public new static WebContext Current
        {
            get
            {
                return ((WebContext)(WebContextBase.Current));
            }
        }
    }
}
namespace xLEditSilverApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.DomainServices;
    using System.ServiceModel.DomainServices.Client;
    using System.ServiceModel.DomainServices.Client.ApplicationServices;
    using System.ServiceModel.Web;
    using Models;
    
    
    /// <summary>
    /// The DomainContext corresponding to the 'LanguagesServiceDomain' DomainService.
    /// </summary>
    public sealed partial class LanguagesServiceDomain : DomainContext
    {
        
        #region Extensibility Method Definitions

        /// <summary>
        /// This method is invoked from the constructor once initialization is complete and
        /// can be used for further object setup.
        /// </summary>
        partial void OnCreated();

        #endregion
        
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguagesServiceDomain"/> class.
        /// </summary>
        public LanguagesServiceDomain() : 
                this(new WebDomainClient<ILanguagesServiceDomainContract>(new Uri("xLEditSilverApp-Web-LanguagesServiceDomain.svc", UriKind.Relative)))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguagesServiceDomain"/> class with the specified service URI.
        /// </summary>
        /// <param name="serviceUri">The LanguagesServiceDomain service URI.</param>
        public LanguagesServiceDomain(Uri serviceUri) : 
                this(new WebDomainClient<ILanguagesServiceDomainContract>(serviceUri))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LanguagesServiceDomain"/> class with the specified <paramref name="domainClient"/>.
        /// </summary>
        /// <param name="domainClient">The DomainClient instance to use for this DomainContext.</param>
        public LanguagesServiceDomain(DomainClient domainClient) : 
                base(domainClient)
        {
            this.OnCreated();
        }
        
        /// <summary>
        /// Gets the set of <see cref="Language"/> entity instances that have been loaded into this <see cref="LanguagesServiceDomain"/> instance.
        /// </summary>
        public EntitySet<Language> Languages
        {
            get
            {
                return base.EntityContainer.GetEntitySet<Language>();
            }
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="Language"/> entity instances using the 'GetAll' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="Language"/> entity instances.</returns>
        public EntityQuery<Language> GetAllQuery()
        {
            this.ValidateMethod("GetAllQuery", null);
            return base.CreateQuery<Language>("GetAll", null, false, true);
        }
        
        /// <summary>
        /// Gets an EntityQuery instance that can be used to load <see cref="Language"/> entity instances using the 'GetLanguages' query.
        /// </summary>
        /// <returns>An EntityQuery that can be loaded to retrieve <see cref="Language"/> entity instances.</returns>
        public EntityQuery<Language> GetLanguagesQuery()
        {
            this.ValidateMethod("GetLanguagesQuery", null);
            return base.CreateQuery<Language>("GetLanguages", null, false, true);
        }
        
        /// <summary>
        /// Creates a new EntityContainer for this DomainContext's EntitySets.
        /// </summary>
        /// <returns>A new container instance.</returns>
        protected override EntityContainer CreateEntityContainer()
        {
            return new LanguagesServiceDomainEntityContainer();
        }
        
        /// <summary>
        /// Service contract for the 'LanguagesServiceDomain' DomainService.
        /// </summary>
        [ServiceContract()]
        public interface ILanguagesServiceDomainContract
        {
            
            /// <summary>
            /// Asynchronously invokes the 'GetAll' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/LanguagesServiceDomain/GetAllDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/LanguagesServiceDomain/GetAll", ReplyAction="http://tempuri.org/LanguagesServiceDomain/GetAllResponse")]
            [WebGet()]
            IAsyncResult BeginGetAll(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetAll'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetAll'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetAll' operation.</returns>
            QueryResult<Language> EndGetAll(IAsyncResult result);
            
            /// <summary>
            /// Asynchronously invokes the 'GetLanguages' operation.
            /// </summary>
            /// <param name="callback">Callback to invoke on completion.</param>
            /// <param name="asyncState">Optional state object.</param>
            /// <returns>An IAsyncResult that can be used to monitor the request.</returns>
            [FaultContract(typeof(DomainServiceFault), Action="http://tempuri.org/LanguagesServiceDomain/GetLanguagesDomainServiceFault", Name="DomainServiceFault", Namespace="DomainServices")]
            [OperationContract(AsyncPattern=true, Action="http://tempuri.org/LanguagesServiceDomain/GetLanguages", ReplyAction="http://tempuri.org/LanguagesServiceDomain/GetLanguagesResponse")]
            [WebGet()]
            IAsyncResult BeginGetLanguages(AsyncCallback callback, object asyncState);
            
            /// <summary>
            /// Completes the asynchronous operation begun by 'BeginGetLanguages'.
            /// </summary>
            /// <param name="result">The IAsyncResult returned from 'BeginGetLanguages'.</param>
            /// <returns>The 'QueryResult' returned from the 'GetLanguages' operation.</returns>
            QueryResult<Language> EndGetLanguages(IAsyncResult result);
        }
        
        internal sealed class LanguagesServiceDomainEntityContainer : EntityContainer
        {
            
            public LanguagesServiceDomainEntityContainer()
            {
                this.CreateEntitySet<Language>(EntitySetOperations.None);
            }
        }
    }
}