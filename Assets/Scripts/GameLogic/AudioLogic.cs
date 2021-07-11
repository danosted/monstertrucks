using Assets.Code.MonoBehaviours.Configuration;
using Assets.Code.Common;
using Assets.Code.Common.DataAccess;
using Assets.Code.IoC;

namespace Assets.Code.GameLogic
{
    public class AudioLogic : LogicBase
    {

        public AudioLogic(IUnityContainer container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
        }

        public void InitializeAudio()
        {
            var audioSystem = _prefabManager.GetPrefab(_configuration.audio_system);
            audioSystem.Activate(_container);
            audioSystem.SetupAudio(_prefabManager.GetPrefab(_configuration.audio_background_01));
        }

    }
}
