using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Business.Layer.Interfaces.Processing.Triangle;
using Business.Layer.Processing.Triangle;
using Connection.Layer;
using Connection.Layer.Interfaces;
using Infrastructure;
using Infrastructure.log;
using log4net.Config;
using Ninject;
using Ninject.Web.Common;
using WebMvc.AutoMapperConfiguration;

namespace WebMvc.App_Start
{
    public class NinjectConfigurator
    {
        /// <summary>
        ///     Entry method used by caller to configure the given
        ///     container with all of this application's
        ///     dependencies.
        /// </summary>
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }

        private void AddBindings(IKernel container)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            // IMPORTANT NOTE! *Never* configure a type as singleton if it depends upon ISession!!! This is because
            // ISession is disposed of at the end of every request. For the same reason, make sure that types
            // dependent upon such types aren't configured as singleton.
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////

            ConfigureLog4net(container);

            ConfigureRepository(container);
            ConfigureUserSession(container);
            //ConfigureNHibernate(container);
            ConfigureDependenciesOnlyUsedForLegacyProcessing(container);
            ConfigureAutoMapper(container);
            ConfigureServices(container);

            //container.Bind<IBasicSecurityService>().To<BasicSecurityService>().InSingletonScope();


            //container.Bind<ICommonLinkService>().To<CommonLinkService>().InRequestScope();
            //container.Bind<IPagedDataRequestFactory>().To<PagedDataRequestFactory>().InSingletonScope();

            //container.Bind<IAllStatusesInquiryProcessor>().To<AllStatusesInquiryProcessor>().InRequestScope();
            //container.Bind<IAllStatusesQueryProcessor>().To<AllStatusesQueryProcessor>().InRequestScope();
            //container.Bind<IStatusLinkService>().To<StatusLinkService>().InRequestScope();

            //container.Bind<IAllUsersInquiryProcessor>().To<AllUsersInquiryProcessor>().InRequestScope();
            //container.Bind<IAllUsersQueryProcessor>().To<AllUsersQueryProcessor>().InRequestScope();
            //container.Bind<IUserByIdInquiryProcessor>().To<UserByIdInquiryProcessor>().InRequestScope();
            //container.Bind<IUserByIdQueryProcessor>().To<UserByIdQueryProcessor>().InRequestScope();
            //container.Bind<IUserLinkService>().To<UserLinkService>().InRequestScope();

            //container.Bind<ITasksControllerDependencyBlock>().To<TasksControllerDependencyBlock>().InRequestScope();
            //container.Bind<IAddTaskMaintenanceProcessor>().To<AddTaskMaintenanceProcessor>().InRequestScope();
            //container.Bind<IAddTaskQueryProcessor>().To<AddTaskQueryProcessor>().InRequestScope();
            //container.Bind<IUpdateTaskMaintenanceProcessor>().To<UpdateTaskMaintenanceProcessor>().InRequestScope();
            //container.Bind<IUpdateablePropertyDetector>().To<JObjectUpdateablePropertyDetector>().InSingletonScope();
            //container.Bind<IUpdateTaskQueryProcessor>().To<UpdateTaskQueryProcessor>().InRequestScope();
            //container.Bind<IDeleteTaskQueryProcessor>().To<DeleteTaskQueryProcessor>().InRequestScope();
            //container.Bind<IStartTaskWorkflowProcessor>().To<StartTaskWorkflowProcessor>().InRequestScope();
            //container.Bind<ICompleteTaskWorkflowProcessor>().To<CompleteTaskWorkflowProcessor>().InRequestScope();
            //container.Bind<IReactivateTaskWorkflowProcessor>().To<ReactivateTaskWorkflowProcessor>().InRequestScope();
            //container.Bind<IUpdateTaskStatusQueryProcessor>().To<UpdateTaskStatusQueryProcessor>().InRequestScope();
            //container.Bind<IAllTasksInquiryProcessor>().To<AllTasksInquiryProcessor>().InRequestScope();
            //container.Bind<IAllTasksQueryProcessor>().To<AllTasksQueryProcessor>().InRequestScope();
            //container.Bind<ITaskByIdInquiryProcessor>().To<TaskByIdInquiryProcessor>().InRequestScope();
            //container.Bind<ITaskByIdQueryProcessor>().To<TaskByIdQueryProcessor>().InRequestScope();
            //container.Bind<ITaskLinkService>().To<TaskLinkService>().InRequestScope();

            //container.Bind<ITaskUsersInquiryProcessor>().To<TaskUsersInquiryProcessor>().InRequestScope();
            //container.Bind<ITaskUsersMaintenanceProcessor>().To<TaskUsersMaintenanceProcessor>().InRequestScope();
            //container.Bind<ITaskUsersLinkService>().To<TaskUsersLinkService>().InRequestScope();

            //container.Bind<IAddTaskMaintenanceProcessorV2>().To<AddTaskMaintenanceProcessorV2>().InRequestScope();
        }

        private void ConfigureRepository(IKernel container)
        {
            /*
          kernel.Load(Assembly.GetExecutingAssembly());


                 kernel.Bind<ApplicationSignInManager>().ToSelf();
                 kernel.Bind<IAuthenticationManager>().ToMethod(x => HttpContext.Current.GetOwinContext().Authentication);
                 kernel.Bind<IDataProtectionProvider>().ToMethod(x => _app.GetDataProtectionProvider());

                      * 
                      * */


        }
        private void ConfigureServices(IKernel container)
        {
            container.Bind<IBLTriangleProcessing>().To<BLTriangleProcessing>().InRequestScope();
           container.Bind<ICLClientConnection>().To<CLClientConnection>().InRequestScope();
            ////container.Bind<IDLTriangle>().To<DLTriangle>().InRequestScope(); ;



            //  container.Bind<IWebApiValidation>().To<WebApiValidation>().InRequestScope();

            //  container.Bind<ICertificate2X509>().To<Certificate2X509>().InRequestScope();

            //  container.Bind<IBLAspNetSecurity>().To<BLAspNetSecurity>().InRequestScope();

            //  container.Bind<ISLAspNetSecurity>().To<SLAspNetSecurity>().InRequestScope();
            //  container.Bind<IBasicSecurityService>().To<BasicSecurityService>().InRequestScope();
            //  container.Bind<IBasicAuthenticationService>().To<BasicAuthenticationService>().InRequestScope();


            //  container.Bind<IConversions>().To<Conversions>().InRequestScope();
            // container.Bind<IDLValidation>().To<DLValidation>().InRequestScope();
            ////container.Bind<IDataAnnotationsValidator>().To<DataAnnotationsValidator>().InRequestScope(); ;

            //  container.Bind<ISpaceRadarValidationRule>().To<SpaceRadarStringValidationRule>().InRequestScope().Named("StringValidationRule"); ;
            //container.Bind<ISpaceRadarValidationRule>().To<SpaceRadarNullValidationRule>().InRequestScope().Named("NullValidationRule");
            //  container.Bind<ISpaceRadarValidationRule>().To<SpaceRadarCollectionValidationRule>().InRequestScope().Named("CollectionValidationRule");



            // container.Bind<IBLConnection>().To<BLConnection>().InRequestScope();
            //  container.Bind<ISLConnection>().To<SLConnection>().InRequestScope();

            //  container.Bind<IConnectionMaintenanceProcessor>().To<ConnectionMaintenanceProcessor>().InRequestScope();
        }
        private void ConfigureAutoMapper(IKernel container)
        {
            container.Bind<IMapper>()
                .ToMethod(context =>
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile<ConnBLTriangleStartUpInfoModelProfile>();
                        cfg.AddProfile<BLTriangleStartupModelProfile>();
                        cfg.AddProfile<ConnectionBLTriangleVerticeModelProfile>();

                        // tell automapper to use ninject when creating value converters and resolvers
                        cfg.ConstructServicesUsing(t => container.Get(t));
                    });
                    return config.CreateMapper();
                }).InSingletonScope();

            /////////////////////////////////////////////////////
            //var mapperConfig = new MapperConfiguration(config => config.AddProfile<BLDLConnectionProfile>());
            //mapperConfig.AssertConfigurationIsValid();
            ////container.Bind<IAutoMapper>().To<AutoMapperAdapter>().InSingletonScope();
            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<StatusEntityToStatusAutoMapperTypeConfigurator>()
            //    .InSingletonScope();
            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<StatusToStatusEntityAutoMapperTypeConfigurator>()
            //    .InSingletonScope();
            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<UserEntityToUserAutoMapperTypeConfigurator>()
            //    .InSingletonScope();
            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<UserToUserEntityAutoMapperTypeConfigurator>()
            //    .InSingletonScope();
            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<NewTaskToTaskEntityAutoMapperTypeConfigurator>()
            //    .InSingletonScope();
            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<TaskEntityToTaskAutoMapperTypeConfigurator>()
            //    .InSingletonScope();
            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<TaskToTaskEntityAutoMapperTypeConfigurator>()
            //    .InSingletonScope();

            //container.Bind<IAutoMapperTypeConfigurator>()
            //    .To<NewTaskV2ToTaskEntityAutoMapperTypeConfigurator>()
            //    .InRequestScope();
        }

        private void ConfigureUserSession(IKernel container)
        {
            //var userSession = new UserSession();
            //container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            //container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }

        //    private void ConfigureNHibernate(IKernel container)
        //    {
        //        //var sessionFactory = Fluently.Configure()
        //        //    .Database(
        //        //        MsSqlConfiguration.MsSql2008.ConnectionString(
        //        //            c => c.FromConnectionStringWithKey("WebApi2BookDb")))
        //        //    .CurrentSessionContext("web")
        //        //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>())
        //        //    .BuildSessionFactory();

        //        container.Bind<ISessionFactory>().ToConstant(sessionFactory);
        //        container.Bind<ISession>().ToMethod(CreateSession);
        ////        container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();
        //    }

        //private ISession CreateSession(IContext context)
        //{
        //    var sessionFactory = context.Kernel.Get<ISessionFactory>();
        //    if (!CurrentSessionContext.HasBind(sessionFactory))
        //    {
        //        var session = sessionFactory.OpenSession();
        //        CurrentSessionContext.Bind(session);
        //    }

        //    return sessionFactory.GetCurrentSession();
        //}

        private void ConfigureDependenciesOnlyUsedForLegacyProcessing(IKernel container)
        {
            //container.Bind<ILegacyMessageProcessor>().To<LegacyMessageProcessor>().InRequestScope();
            //container.Bind<ILegacyMessageParser>().To<LegacyMessageParser>().InSingletonScope();
            //container.Bind<ILegacyMessageTypeFormatter>().To<LegacyMessageTypeFormatter>().InSingletonScope();

            //container.Bind<ILegacyMessageProcessingStrategy>()
            //    .To<GetTasksMessageProcessingStrategy>()
            //    .InRequestScope();
            //container.Bind<ILegacyMessageProcessingStrategy>()
            //    .To<GetTaskByIdMessageProcessingStrategy>()
            // .InRequestScope();
        }

        private void ConfigureLog4net(IKernel container)
        {
            XmlConfigurator.Configure();

            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }
    }

}