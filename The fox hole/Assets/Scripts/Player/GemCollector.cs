using UnityEngine;

public class GemCollector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Gem gem))
        {
            gem.Collect();
        }
    }
}
