namespace Assets.Code.IoC
{
    using Common.DataAccess;
    using MonoBehaviours.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UnityContainer : IUnityContainer
    {
        private ICollection<object> _container { get; set; }
        private PrefabManager PrefabManager { get; set; }
        private GlobalConfiguration Configuration { get; set; }

        public UnityContainer(GlobalConfiguration config)
        {
            // Initialize Container
            _container = new HashSet<object>();

            // Initialize PrefabManager
            PrefabManager = Resolve<PrefabManager>();

            // Initialize GlobalConfiguration
            Configuration = PrefabManager.GetPrefab(config);
        }

        public T Resolve<T>()
        {
            var entity = (T)_container.FirstOrDefault(e => e.GetType() == typeof(T));

            if (entity != null)
            {
                return entity;
            }

            if (typeof(T).GetConstructor(Type.EmptyTypes) != null)
            {
                entity = (T)Activator.CreateInstance(typeof(T), new object[] { });
            }
            else if (typeof(T).GetConstructor(new[] { typeof(UnityContainer) }) != null)
            {
                entity = (T)Activator.CreateInstance(typeof(T), new object[] { this });
            }
            else
            {
                entity = (T)Activator.CreateInstance(typeof(T), new object[] { this, PrefabManager, Configuration });
            }

            _container.Add(entity);

            return entity;
        }

        private T CreateInstance<T>() where T : new()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
