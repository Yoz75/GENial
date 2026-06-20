using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Genial
{
    public struct ConsumedNoteInfo
    {
        public float PositionDelta;
        public bool IsMiss;
    }

    public class NoteConsumer : MonoBehaviour
    {
        public UnityEvent<ConsumedNoteInfo> Consumed;

        [SerializeField] private float ConsumeRadius;
        [SerializeField] private float ComboInputWindow = 0.1f;
        [SerializeField] private Transform NoteEnd;
        [SerializeField] private NoteSpawner Spawner;
        [SerializeField] private InputActionReference CAction, TAction, GAction, AAction;

        readonly Collider2D[] NearestColliders = new Collider2D[255];

        private float cPressedTime = float.NegativeInfinity;
        private float tPressedTime = float.NegativeInfinity;
        private float gPressedTime = float.NegativeInfinity;
        private float aPressedTime = float.NegativeInfinity;

        private void Update()
        {
            if(CAction.action.WasPressedThisFrame())
                cPressedTime = Time.time;

            if(TAction.action.WasPressedThisFrame())
                tPressedTime = Time.time;

            if(GAction.action.WasPressedThisFrame())
                gPressedTime = Time.time;

            if(AAction.action.WasPressedThisFrame())
                aPressedTime = Time.time;

            Note note = GetNearest();
            if(note == null)
                return;

            NoteType pressedTypes = NoteType.None;

            if(Time.time - cPressedTime <= ComboInputWindow)
                pressedTypes |= NoteType.C;

            if(Time.time - tPressedTime <= ComboInputWindow)
                pressedTypes |= NoteType.T;

            if(Time.time - gPressedTime <= ComboInputWindow)
                pressedTypes |= NoteType.G;

            if(Time.time - aPressedTime <= ComboInputWindow)
                pressedTypes |= NoteType.A;

            bool anyNewPress =
                CAction.action.WasPressedThisFrame() ||
                TAction.action.WasPressedThisFrame() ||
                GAction.action.WasPressedThisFrame() ||
                AAction.action.WasPressedThisFrame();

            if(anyNewPress && pressedTypes != NoteType.None)
            {
                TryConsume(pressedTypes, note);
            }
        }

        public void TryConsume(NoteType targetType, Note note)
        {
            if(note == null)
                return;

            if(targetType != note.Type)
                return;

            cPressedTime = float.NegativeInfinity;
            tPressedTime = float.NegativeInfinity;
            gPressedTime = float.NegativeInfinity;
            aPressedTime = float.NegativeInfinity;

            ConsumedNoteInfo info = default;
            info.PositionDelta =
                Vector3.Distance(NoteEnd.position, note.transform.position);

            Consumed.Invoke(info);
            note.Deactivate();
        }

        public void ConsumeMiss(Note note)
        {
            ConsumedNoteInfo info = default;
            info.IsMiss = true;

            Consumed.Invoke(info);
            note.Deactivate();
        }

        private Note GetNearest()
        {
            int hitsCount = Physics2D.OverlapCircle(
                NoteEnd.position,
                ConsumeRadius,
                ContactFilter2D.noFilter,
                NearestColliders);

            Note nearest = null;
            float minDistance = float.MaxValue;

            Span<Collider2D> hits = NearestColliders.AsSpan(0, hitsCount);

            foreach(var hit in hits)
            {
                if(hit.TryGetComponent(out Note component))
                {
                    float distance =
                        (hit.transform.position - NoteEnd.position).sqrMagnitude;

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