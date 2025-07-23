using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Fliper _fliper;
    [SerializeField, Min(1)] private float _speed;

    public void Move(Vector2 direction)
    {
        _fliper.Flip(direction.x);
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}