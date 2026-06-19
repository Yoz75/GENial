using System.Collections;
using UnityEngine;

namespace Genial
{
    public class DelayedDestroyer : MonoBehaviour
    {
        /// <summary>
        /// After this time on <see cref="Note.IsTimerStarted"/> note will be destroyed
        /// </summary>
        [SerializeField] private float DestroyTime = 0.5f;
        [SerializeField] private string TargetTag;

        public void Destroy()
        {
            StartCoroutine(DestroyCoroutine());
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return new WaitForSeconds(DestroyTime);
            Destroy(gameObject);
        }
    }
}