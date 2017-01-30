using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioGame
{
    public class MicrophoneController : MonoBehaviour
    {
        public AudioClip LastClip { get; private set; }
        [SerializeField] int recordingLengthSec = 1;        // seconds

        private Device device;

        private class Device
        {
            public String Name { get; private set; }
            public int MinFreq { get; private set; }
            public int MaxFreq { get; private set; }

            public Device(String name)
            {
                Name = name;
                int minFreq, maxFreq;
                Microphone.GetDeviceCaps(Name, out minFreq, out maxFreq);
                MinFreq = minFreq;
                MaxFreq = maxFreq;
            }
        }

        private void Start()
        {
            device = new Device(Microphone.devices[0]); // select default device
        }

        private void OnEnable()
        {
            ButtonController.OnStopRecordingClicked += StopRecording;
            ButtonController.OnStartRecordingClicked += StartRecording;
        }

        private void OnDisable()
        {
            ButtonController.OnStopRecordingClicked -= StopRecording;
            ButtonController.OnStartRecordingClicked -= StartRecording;
        }

        private void StartRecording()
        {
            Debug.Log("starting to record ...");
            LastClip = Microphone.Start(device.Name, false, recordingLengthSec, device.MaxFreq);
        }

        private void StopRecording()
        {
            if (Microphone.IsRecording(device.Name))
            {
                Debug.Log("ending recording ...");
                Microphone.End(device.Name);
            }
        }
    }
}
