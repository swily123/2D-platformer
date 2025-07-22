using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Fliper : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Flip(float direction)
    {
        if (direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}