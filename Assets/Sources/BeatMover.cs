using UnityEngine;

namespace Genial
{
    /// <summary>
    /// Moves the object on song beats
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class BeatMover : MonoBehaviour
    {
        [SerializeField] private Vector3 MovementDirection;

        private Rigidbody2D Rigidbody;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            RhythmConductor.Instance.AddOnBeat(Move);
        }

        private void OnDestroy()
        {
            RhythmConductor.Instance.RemoveOnBeat(Move);
        }

        private void Move()
        {
            Rigidbody.MovePosition(transform.position + MovementDirection);
        }
    }
}