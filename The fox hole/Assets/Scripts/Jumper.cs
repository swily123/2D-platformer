using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jumper : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump(float jumpForce)
    {
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
