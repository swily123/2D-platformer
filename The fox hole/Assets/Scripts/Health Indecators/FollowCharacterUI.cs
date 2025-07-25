using UnityEngine;

public class FollowCharacterUI : MonoBehaviour
{
    [SerializeField] private Transform _character;

    private Vector3 _offset = new Vector3(0, 1, 0);

    private void LateUpdate()
    {
        if (_character != null)
        {
            transform.position = _character.position + _offset;
            transform.rotation = Quaternion.identity;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}