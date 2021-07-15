﻿namespace UnityDM.MonoBehaviours.Audio
{
    using Common;
    using IoC;
    using UnityEngine;

    public class AudioSystem : PrefabBase
    {
        private AudioSource AudioSource { get; set; }

        public override void Activate(IUnityContainer container)
        {
            base.Activate(container);
            AudioSource = GetComponent<AudioSource>();
        }

        public void SetupAudio(AudioClipConfiguration clipConfig)
        {
            //AudioSource.clip = ;
            AudioSource.PlayOneShot(clipConfig.AudioClips[0]);
            
        }
    }
}
