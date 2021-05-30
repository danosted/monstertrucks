namespace Assets.Code.GameLogic
{
    using MonoBehaviours.Configuration;
    using Common;
    using DataAccess;
    using IoC;
    using UnityEngine.SceneManagement;

    public class FlowLogic : LogicBase
    {

        protected readonly UserInterfaceLogic _userInterfaceLogic;

        public FlowLogic(IoC container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
            _userInterfaceLogic = _container.Resolve<UserInterfaceLogic>();
        }

        public void InitializeGame()
        {
            // Initialize UI
            _userInterfaceLogic.InitializeGameMenuCanvas();

            // Initialize Audio
            _container.Resolve<AudioLogic>().InitializeAudio();

        }

        public void StartGame()
        {
            // Change to game UI
            // Container.Resolve<UserInterfaceLogic>().InitializeGameCanvas();
            _userInterfaceLogic.HideCurrentCanvas();

            // Create an object
            var obj = PrefabManager.GetPrefab(Configuration.prefab_moveable_object);
            obj.Activate(_container);
        }

        public void GameOver()
        {
            _container.Resolve<UserInterfaceLogic>().InitializeGameOverCanvas();
            PrefabManager.Shutdown();
        }

        public void RestartGame()
        {
            // TODO 2 (DRO): this could be done more efficiently
            SceneManager.LoadScene(0);
        }
    }
}
