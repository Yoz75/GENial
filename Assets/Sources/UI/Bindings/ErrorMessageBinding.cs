using UnityEngine;

namespace Genial
{
    [CreateAssetMenu(fileName = "ErrorMessageBinding", menuName = "GENial/ErrorMessageBinding")]
    public class ErrorMessageBinding : ScriptableObject
    {
        public string Message;
    }
}