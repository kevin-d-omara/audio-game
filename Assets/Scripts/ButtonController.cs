using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AudioGame
{
    public class ButtonController : MonoBehaviour
    {
        public delegate void PlayClicked();
        public delegate void StopRecording();
        public delegate void StartRecording();
        public static event PlayClicked OnPlayClicked;
        public static event StopRecording OnStopRecordingClicked;
        public static event StartRecording OnStartRecordingClicked;
        
        [SerializeField] private Text recordText;

        private void Start()
        {
            recordText.text = "Start Recording";
        }

        public void ToggleRecording()
        {
            if (recordText.text == "Start Recording")
            {
                recordText.text = "Stop Recording";
                if (OnStartRecordingClicked != null)
                {
                    OnStartRecordingClicked();
                }
            }
            else
            {
                recordText.text = "Start Recording";
                if (OnStopRecordingClicked != null)
                {
                    OnStopRecordingClicked();
                }
            }
        }

        public void Play()
        {
            if (OnPlayClicked != null)
            {
                OnPlayClicked();
            }
        }
    }
}
