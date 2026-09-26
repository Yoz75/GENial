using UnityEngine;

namespace Genial
{
    [CreateAssetMenu(fileName = "TotalResultsBingind", menuName = "GENial/TotalResultsBingind")]
    public class TotalResultsBinding : ScriptableObject
    {
        public string TotalScore;
        public string MaxCombo;
        public string Grade;
    }
}