using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Genial
{
    public struct ConsumedNoteInfo
    {
        public float PositionDelta;
        public bool IsTypeMismatch;
    }

    public class NoteConsumer : MonoBehaviour
    {
        public UnityEvent<ConsumedNoteInfo> Consumed;

        [SerializeField] private Transform NoteEnd;
        [SerializeField] NoteSpawner Spawner;
        [SerializeField] InputActionReference CAction, TAction, GAction, AAction;

        private void Start()
        {
            CAction.action.started += (_) => TryConsume(NoteType.C, Spawner.Last);
            TAction.action.started += (_) => TryConsume(NoteType.T, Spawner.Last);
            GAction.action.started += (_) => TryConsume(NoteType.G, Spawner.Last);
            AAction.action.started += (_) => TryConsume(NoteType.A, Spawner.Last);
        }

        public void TryConsume(NoteType targetType, Note note)
        {
            if(note == null) return;

            ConsumedNoteInfo info = default;

            if(targetType != note.Type)
            {
                info.IsTypeMismatch = true;
            }

            info.PositionDelta = Vector3.Distance(NoteEnd.position, note.transform.position);

            Consumed.Invoke(info);
            Destroy(note.gameObject);
            return;
        }
    }
}