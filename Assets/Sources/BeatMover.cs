using UnityEngine;

namespace Genial
{
    /// <summary>
    /// Moves the object on song beats
    /// </summary>
    public class BeatMover : MonoBehaviour
    {
        [SerializeField] private Vector3 MovementDirection;

        private void Start()
        {
            RhythmConductor.Instance.AddOnBeat(Move);
        }

        private void OnDestroy()
        {
            RhythmConductor.Instance.RemoveOnBeat(Move);
        }

        private void Move()
        {
            transform.position += MovementDirection;
        }
    }
}