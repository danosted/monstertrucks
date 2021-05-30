namespace Assets.Code.Common
{
    using DataAccess;
    using IoC;
    using MonoBehaviours.Configuration;

    public class LogicBase
    {
        #region Properties
        protected readonly IoC _container;
        protected readonly PrefabManager _prefabManager;
        protected readonly GlobalConfiguration _configuration;
        #endregion
        
        #region Constructors
        public LogicBase(IoC container, PrefabManager prefabManager, GlobalConfiguration config)
        {
            _container = container;
            _prefabManager = prefabManager;
            _configuration = config;
        }
        #endregion
    }
}
