using UnityEngine;

public class Example : MonoBehaviour
{
    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor()
    {
        renderer.color = new Color(Random.value, Random.value, Random.value);
    }
}
