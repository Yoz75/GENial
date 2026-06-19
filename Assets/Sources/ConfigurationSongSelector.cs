using UnityEngine;

namespace Genial
{
    [RequireComponent(typeof(AudioSource))]
    public class ConfigurationSongSelector : MonoBehaviour
    {
        [SerializeField] private AudioClip DefaultClip;

        private void Start()
        {
            GetComponent<AudioSource>().clip = SongConfiguration.Track == null ? DefaultClip : SongConfiguration.Track;
        }
    }
}