using UnityEngine;

namespace Genial
{
    [RequireComponent (typeof(Rigidbody2D))]
    public class OnStartForceApplier : MonoBehaviour
    {
        [SerializeField] private Vector2 Force;

        private void Start()
        {
            GetComponent<Rigidbody2D>().AddForce(Force);    
        }
    }
}