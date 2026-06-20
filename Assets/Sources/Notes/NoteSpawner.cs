
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
        [SerializeField] private GameObject DummyPrefab;
        [SerializeField] private List<WeightedPrefab> NotePrefabs;

        private long PassedBeatsCount;

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
                var @object = Instantiate(DummyPrefab, transform);
                @object.transform.localPosition = Vector3.zero;
                return;
            }

            var prefab = WeightedSelect<List<WeightedPrefab>, WeightedPrefab>.SelectRandom(NotePrefabs);
            var noteObject = Instantiate(prefab.Prefab, transform);
            noteObject.transform.localPosition = Vector3.zero;
        }
    }
}