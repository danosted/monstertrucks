using UnityDM.MonoBehaviours.Configuration;
using UnityDM.Common;
using UnityDM.Common.DataAccess;
using UnityDM.IoC;

namespace UnityDM.GameLogic
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
