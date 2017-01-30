using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioGame
{
    [RequireComponent (typeof (AudioSource))]
    public class SpeakerController : MonoBehaviour
    {
        [SerializeField] private MicrophoneController microphone;
        [SerializeField] private AudioSource audioSource;

        private AudioClip lastClip;

        private void OnEnable()
        {
            ButtonController.OnPlayClicked += PlayLastAudioClip;
        }

        private void OnDisable()
        {
            ButtonController.OnPlayClicked -= PlayLastAudioClip;
        }

        private void PlayLastAudioClip()
        {
            lastClip = microphone.LastClip;
            audioSource.clip = lastClip;
            audioSource.Play();
        }
    }
}
