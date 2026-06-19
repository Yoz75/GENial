
using UnityEngine;

namespace Genial
{
    public class NoteSpawner : MonoBehaviour
    {
        [SerializeField] private int BeatsPerSpawn = 1;
        [SerializeField] private GameObject[] NotePrefabs;

        private long PassedBeatsCount;

        public Note Last
        {
            get;
            private set;
        }

        private void Start()
        {
            RhythmConductor.Instance.AddOnBeat(TrySpawn);
        }

        private void OnDestroy()
        {
            RhythmConductor.Instance.RemoveOnBeat(TrySpawn);
        }

        private void TrySpawn()
        {
            PassedBeatsCount++;
            if(PassedBeatsCount % BeatsPerSpawn != 0) return;

            var noteObject = Instantiate(NotePrefab, transform);

            var note = noteObject.GetComponent<Note>();
            if(Last == null) Last = noteObject.GetComponent<Note>();
            else Last.Next = noteObject.GetComponent<Note>();
        }
    }
}