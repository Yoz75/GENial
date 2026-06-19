using UnityEngine;

namespace Genial
{
    public class Destroyable : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}