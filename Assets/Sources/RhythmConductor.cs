using UnityEngine;
using UnityEngine.Events;

namespace Genial
{
    [RequireComponent (typeof(AudioSource))]
    public class RhythmConductor : MonoBehaviour
    {
        [SerializeField] private UnityEvent Beat;

        public static RhythmConductor Instance
        {
            get;
            private set;
        }

        private double StartTime;
        private double PlayedTime;
        private double RoughBeatsCount;

        public void AddOnBeat(UnityAction action) => Beat.AddListener(action);
        public void RemoveOnBeat(UnityAction action) => Beat.RemoveListener(action);

        private void Awake()
        {
            Instance = this;
            StartTime = AudioSettings.dspTime + SongConfiguration.StartDelay;
        }

        private void Update()
        {
            if(!IsStartedAlready()) return;
            float timePerBeat = 60f / SongConfiguration.BeatsPerMinute;

            PlayedTime = AudioSettings.dspTime - StartTime;
                        
            var newBeatsCount = PlayedTime / timePerBeat;

            if(newBeatsCount - RoughBeatsCount >= 1f)
            {
                RoughBeatsCount = newBeatsCount;

                Beat.Invoke();
            }
        }

        private bool IsStartedAlready()
        {
            return AudioSettings.dspTime >= StartTime;
        }
    }
}