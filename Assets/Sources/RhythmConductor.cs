using UnityEngine;
using UnityEngine.Events;

namespace Genial
{
    public class RhythmConductor : MonoBehaviour
    {
        [SerializeField] private UnityEvent Beat;

        public static RhythmConductor Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Time remaining before next beat in diapazone 0..1
        /// </summary>
        public double RemainingBeforeBeatPerCent => RemainingBeforeBeat / (60f / SongConfiguration.BeatsPerMinute);

        /// <summary>
        /// Time remaining before next beat
        /// </summary>
        public double RemainingBeforeBeat
        {
            get;
            private set;
        }

        private double StartTime;
        private double PlayedTime;
        private double RoughBeatsCount;

        private double PreviousDsp;

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

            RemainingBeforeBeat -= AudioSettings.dspTime - PreviousDsp;
            PreviousDsp = AudioSettings.dspTime;
                        
            var newBeatsCount = PlayedTime / timePerBeat;

            if(newBeatsCount - RoughBeatsCount >= 1f)
            {
                RoughBeatsCount = newBeatsCount;
                RemainingBeforeBeat = timePerBeat;

                Beat.Invoke();
            }
        }

        private bool IsStartedAlready()
        {
            return AudioSettings.dspTime >= StartTime;
        }
    }
}