using UnityDM.Common.DataAccess;
using UnityDM.IoC;
using UnityDM.MonoBehaviours.Configuration;

namespace UnityDM.Common
{

    public class LogicBase
    {
        #region Properties
        protected readonly IUnityContainer _container;
        protected readonly PrefabManager _prefabManager;
        protected readonly GlobalConfiguration _configuration;
        #endregion

        #region Constructors
        public LogicBase(IUnityContainer container, PrefabManager prefabManager, GlobalConfiguration config)
        {
            _container = container;
            _prefabManager = prefabManager;
            _configuration = config;
        }
        #endregion
    }
}
