using UnityEngine;

namespace Scripts
{
    public class Cherry : MonoBehaviour
    {
        private float _healValue = 15;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                player.Heal(_healValue);
                Destroy(gameObject);
            }
        }
    }
}