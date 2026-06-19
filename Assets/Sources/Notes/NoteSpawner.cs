
using UnityEngine;
using CSC;
using System.Collections.Generic;
using System;

namespace Genial
{
    [Serializable]
    public struct WeightedPrefab : IWeighted
    {
        public GameObject Prefab;
        public int Weight_;

        public int Weight => Weight_;
    }
    public class NoteSpawner : MonoBehaviour
    {
        [SerializeField] private int BeatsPerSpawn = 1;
        [SerializeField] private GameObject DymmyPrefab;
        [SerializeField] private List<WeightedPrefab> NotePrefabs;

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
            if(PassedBeatsCount % BeatsPerSpawn != 0)
            {
                Instantiate(DymmyPrefab, transform);
                return;
            }

            var prefab = WeightedSelect<List<WeightedPrefab>, WeightedPrefab>.SelectRandom(NotePrefabs);

            var noteObject = Instantiate(prefab.Prefab, transform);

            var note = noteObject.GetComponent<Note>();
            if(Last == null) Last = noteObject.GetComponent<Note>();
            else Last.Next = noteObject.GetComponent<Note>();
        }
    }
}