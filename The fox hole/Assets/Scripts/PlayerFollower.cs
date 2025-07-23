using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _maxCameraLength = 23;

    private void LateUpdate()
    {
        Vector3 direction = new Vector3(_player.position.x, _player.position.y, -1f);

        if (direction.x < 0)
        {
            direction.x = 0;
        }
        else if (direction.x > _maxCameraLength)
        {
            direction.x = _maxCameraLength;
        }

        transform.position = direction;
    }
}