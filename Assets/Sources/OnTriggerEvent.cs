using UnityEngine;
using UnityEngine.Events;

namespace Genial
{
    public class OnTriggerEvent : MonoBehaviour
    {
        public UnityEvent Event;
        [SerializeField] private string TriggerTag;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag(TriggerTag))
            {
                Event.Invoke();
            }
        }
    }
}