
using UnityEngine;
namespace Genial
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Note : MonoBehaviour
    {
        [SerializeField] private Sprite DeactivatedSprite;
        public NoteType Type;

        private SpriteRenderer Renderer;

        private void Start()
        {
            Renderer = GetComponent<SpriteRenderer>();
        }

        public void Deactivate()
        { 
            Renderer.sprite = DeactivatedSprite;
            Destroy(this);
        }
    }
}