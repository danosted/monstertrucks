namespace UnityDM.GameLogic
{
    using MonoBehaviours.Configuration;
    using Common;
    using Common.DataAccess;
    using IoC;
    using UnityEngine.SceneManagement;

    public class FlowLogic : LogicBase
    {

        protected readonly UserInterfaceLogic _userInterfaceLogic;

        public FlowLogic(IUnityContainer container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
            _userInterfaceLogic = _container.Resolve<UserInterfaceLogic>();
        }

        public void InitializeGame()
        {
            // Initialize UI
            // _userInterfaceLogic.InitializeGameMenuCanvas();

            // Initialize Audio
            _container.Resolve<AudioLogic>().InitializeAudio();

        }

        public void StartGame()
        {
            // Change to game UI
            // _container.Resolve<UserInterfaceLogic>().InitializeGameCanvas();
            // _userInterfaceLogic.HideCurrentCanvas();

            // Create an object
            var obj = _prefabManager.GetPrefab(_configuration.prefab_moveable_object);
            obj.Activate(_container);
        }

        public void GameOver()
        {
            _container.Resolve<UserInterfaceLogic>().InitializeGameOverCanvas();
            _prefabManager.Shutdown();
        }

        public void RestartGame()
        {
            // TODO 2 (DRO): this could be done more efficiently
            SceneManager.LoadScene(0);
        }
    }
}
