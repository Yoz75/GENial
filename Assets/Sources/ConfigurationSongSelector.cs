using UnityEngine;

namespace Genial
{
    [RequireComponent(typeof(AudioSource))]
    public class ConfigurationSongSelector : MonoBehaviour
    {
        [SerializeField] private AudioClip DefaultClip;

        private void Start()
        {
            var source = GetComponent<AudioSource>();
            source.clip = SongConfiguration.Track == null ? DefaultClip : SongConfiguration.Track;
            source.Play();
        }
    }
}