using UnityEngine;
using UnityEngine.Events;

namespace Genial
{
    /// <summary>
    /// Invokes event when song ended playing. Assumes song starts at the start of the scene
    /// </summary>
    [RequireComponent (typeof(AudioSource))]
    public class SongEndedEvent : MonoBehaviour
    {
        private enum SongState
        {
            NotStarted = 0,
            Playing,
            Ended
        }

        public static SongEndedEvent Instance
        {
            get;
            private set;
        }

        [SerializeField] private UnityEvent SongEnded;
        private AudioSource Source;
        private SongState State;

        public void AddOnSongEnded(UnityAction action) => SongEnded.AddListener(action);
        public void RemoveOnSongEnded(UnityAction action) => SongEnded.RemoveListener(action);

        private void Start()
        {
            Instance = this;
            Source = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if(State == SongState.NotStarted && Source.isPlaying)
            {
                State = SongState.Playing;
            }
            else if(State == SongState.Playing && !Source.isPlaying)
            { 
                State = SongState.Ended;
                SongEnded.Invoke();
            }
        }
    }
}