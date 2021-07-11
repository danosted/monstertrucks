using Assets.Code.MonoBehaviours.UserInterface;
using Assets.Code.MonoBehaviours.Configuration;
using Assets.Code.IoC;
using Assets.Code.Common;
using Assets.Code.Common.DataAccess;

namespace Assets.Code.GameLogic
{
    public class UserInterfaceLogic : LogicBase
    {
        public CanvasManager CurrentCanvas { get; private set; }

        public UserInterfaceLogic(IUnityContainer container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
        }

        internal void InitializeGameCanvas()
        {
            InitializeCanvas(_configuration.ui_game_canvas_manager);
        }

        internal void InitializeGameOverCanvas()
        {
            InitializeCanvas(_configuration.ui_game_over_canvas_manager);
        }

        internal void InitializeGameMenuCanvas()
        {
            InitializeCanvas(_configuration.ui_game_menu_canvas_manager);
        }

        internal void HideCurrentCanvas()
        {
            if (CurrentCanvas != null)
            {
                _prefabManager.ReturnPrefab(CurrentCanvas);
            }
        }

        private void InitializeCanvas(CanvasManager canvas)
        {
            HideCurrentCanvas();
            CurrentCanvas = _prefabManager.GetPrefab(canvas);
            CurrentCanvas.Activate(_container);
        }
    }
}