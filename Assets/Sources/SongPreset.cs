using UnityEngine;

namespace Genial
{
    public class SongPreset : MonoBehaviour
    {
        [SerializeField] private int BPM;
        [SerializeField] private float Delay;
        [SerializeField] private AudioClip Song;

        public void SetPreset()
        {
            SongConfiguration.BeatsPerMinute = BPM;
            SongConfiguration.StartDelay = Delay;
            SongConfiguration.Track = Song;
        }
    }
}