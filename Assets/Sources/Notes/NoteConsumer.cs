using System;
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

        [SerializeField] private float ConsumeRadius;
        [SerializeField] private Transform NoteEnd;
        [SerializeField] NoteSpawner Spawner;
        [SerializeField] InputActionReference CAction, TAction, GAction, AAction;

        readonly Collider2D[] NearestColliders = new Collider2D[255];

        private void Start()
        {
            CAction.action.started += (_) => TryConsume(NoteType.C, GetNearest());
            TAction.action.started += (_) => TryConsume(NoteType.T, GetNearest());
            GAction.action.started += (_) => TryConsume(NoteType.G, GetNearest());
            AAction.action.started += (_) => TryConsume(NoteType.A, GetNearest());
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
            note.Deactivate();
            return;
        }

        private Note GetNearest()
        {
            int hitsCount = Physics2D.OverlapCircle(NoteEnd.position, ConsumeRadius, ContactFilter2D.noFilter, NearestColliders);
            Debug.Log(hitsCount);
            Note nearest = null;
            float minDistance = float.MaxValue;
            Span<Collider2D> hits = NearestColliders.AsSpan(0, hitsCount);

            foreach(var hit in hits)
            {
                if(hit.TryGetComponent(out Note component))
                {
                    float distance = (hit.transform.position - NoteEnd.position).sqrMagnitude;
                    if(distance < minDistance)
                    {
                        minDistance = distance;
                        nearest = component;
                    }
                }
            }

            return nearest;
        }
    }
}