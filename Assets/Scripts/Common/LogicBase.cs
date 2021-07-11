using Assets.Code.Common.DataAccess;
using Assets.Code.IoC;
using Assets.Code.MonoBehaviours.Configuration;

namespace Assets.Code.Common
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
