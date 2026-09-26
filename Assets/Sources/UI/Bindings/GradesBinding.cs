using UnityEngine;

namespace Genial
{
    [CreateAssetMenu(fileName = "GradesBinding", menuName = "GENial/GradesBinding")]
    public class GradesBinding : ScriptableObject
    {
        public string MissSerializedCount;
        public string MehSerializedCount;
        public string GoodSerializedCount;
        public string GreatSerializedCount;
        public string GenialSerializedCount;
    }
}