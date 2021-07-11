// using Assets.Code.DataAccess;
// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace Assets.Code.IoC
// {


//     public interface IContainer
//     {
//         TService GetScoped<TService>();
//         void AddScoped<TService, TImplentation>() where TImplentation : TService;
//     }

//     public class Container : IContainer
//     {
//         private PrefabManager PrefabManager { get; set; }
//         private GlobalConfiguration Configuration { get; set; }

//         private readonly IList<KeyValuePair<object, object>> Container;
//         private readonly IList<KeyValuePair<Type, Type>> Scoped;

//         private static readonly object _lock = new object();

//         /// <summary>
//         /// Constructor to be called from CRM plugins and workflows
//         /// </summary>
//         /// <param name="factory"></param>
//         /// <param name="tracing"></param>
//         public Container(INCOrganizationService service, ITracingServiceLogger tracing, IContextFactory contextFactory)
//         {
//             // Prepare container
//             Container = new List<KeyValuePair<object, object>>();
//             Scoped = new List<KeyValuePair<Type, Type>>();

//             // Initialize PrefabManager
//             PrefabManager = Resolve<PrefabManager>();

//             // Initialize GlobalConfiguration
//             Configuration = PrefabManager.GetPrefab(config);

//             // Add CRM instances to container
//             AddToContainer<PrefabManager>(PrefabManager);
//             AddToContainer<ITracingServiceLogger>(tracing);
//             AddToContainer<IContextFactory>(contextFactory);

//             SetupIoc();
//         }

//         private void SetupIoc()
//         {
            
//         }

//         public void AddScoped<TService, TImplentation>() where TImplentation : TService
//         {
//             var kvpToAdd = new KeyValuePair<Type, Type>(typeof(TService), typeof(TImplentation));
//             if (Scoped.Any(kvp => kvp.Key == kvpToAdd.Key && kvp.Value == kvpToAdd.Value))
//             {
//                 _tracingService.Trace($"Container transient with key '{kvpToAdd.Key}' and value '{kvpToAdd.Value}' is already added.");
//                 return;
//             }
//             Scoped.Add(kvpToAdd);
//         }

//         public TService GetScoped<TService>()
//         {
//             lock (_lock)
//             {
//                 try
//                 {
//                     var serviceType = typeof(TService);
//                     var exists = Container.Count(t => (Type)t.Key == serviceType) == 1;
//                     if (!exists)
//                     {
//                         var scoped = Scoped.Single(tra => tra.Key == serviceType);
//                         var instance = Activator.CreateInstance(scoped.Value, this);
//                         AddToContainer<TService>(instance);
//                         return (TService)instance;
//                     }
//                     else
//                     {
//                         var instance = Container.Single(kvp => (Type)kvp.Key == serviceType);
//                         return (TService)instance.Value;
//                     }
//                 }
//                 catch (Exception e)
//                 {
//                     var errMsg = $"Error occurred while trying to find interface '{typeof(TService)}' in CrmIocContainer. Message: {e.Message}";
//                     _tracingService.Trace(errMsg);
//                     throw new ArgumentNullException(errMsg, e);
//                 }
//             }
//         }

//         protected void AddToContainer<TService>(object instance)
//         {
//             Container.Add(new KeyValuePair<object, object>(typeof(TService), instance));
//         }
//     }
// }
