using UnityEngine;

namespace Genial
{
    /// <summary>
    /// misses the node when it enters the attacked trigger
    /// </summary>
    public class MissOnTriggerEnter : MonoBehaviour
    {
        private const string NoteTag = "Note";
        [SerializeField] private NoteConsumer Consumer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag(NoteTag))
            { 
                var note = collision.GetComponent<Note>();
                // A little hack: notes are never None type so it alwasy will miss!
                Consumer.TryConsume(NoteType.None, note);
                Destroy(collision.gameObject);
            }
        }
    }
}