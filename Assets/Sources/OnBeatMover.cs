using UnityEngine;

namespace Genial
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent (typeof(Destroyable))]
    public class OnBeatMover : MonoBehaviour
    {
        [SerializeField] private Vector3 MovementDirection;

        [SerializeField]
        private AnimationCurve MovementCurve =
            AnimationCurve.EaseInOut(0, 0, 1, 1);

        private Rigidbody2D Rigidbody;
        private Destroyable Destroyable;
        private Vector3 TargetPosition;
        private Vector3 PreviousBeatPosition;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Destroyable = GetComponent<Destroyable>();

            PreviousBeatPosition = transform.position;
            TargetPosition = transform.position;

            RhythmConductor.Instance.AddOnBeat(UpdatedTargetPosition);
            SongEndedEvent.Instance.AddOnSongEnded(Destroyable.Destroy);
        }

        private void OnDestroy()
        {
            RhythmConductor.Instance.RemoveOnBeat(UpdatedTargetPosition);
            SongEndedEvent.Instance.RemoveOnSongEnded(Destroyable.Destroy);
        }

        private void UpdatedTargetPosition()
        {
            PreviousBeatPosition = TargetPosition;
            TargetPosition += MovementDirection;
        }

        private void FixedUpdate()
        {
            float coordinate = 1f - (float)RhythmConductor.Instance.RemainingBeforeBeatPerCent;

            float curvedT = MovementCurve.Evaluate(coordinate);

            Vector3 position = Vector3.Lerp(
                PreviousBeatPosition,
                TargetPosition,
                curvedT);

            Rigidbody.MovePosition(position);
        }
    }
}