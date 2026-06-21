using UnityEngine;

namespace Genial
{
    [RequireComponent(typeof(AudioSource))]
    public class OnConsumeSoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip MissSound, HitSound;

        private AudioSource Source;

        private void Start()
        {
            Source = GetComponent<AudioSource>();
        }

        public void Play(ConsumedNoteInfo info)
        {
            var grade = Delta2GradeConverter.Convert(info.PositionDelta);

            if(info.IsMiss || grade == Grade.Miss)
            {
                Source.clip = MissSound;
            }
            else
            {
                Source.clip = HitSound;
            }

            Source.Play();
        }
    }
}