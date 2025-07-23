using UnityEngine;

public class Fliper : MonoBehaviour
{
    private float _flipAmount = 180;

    public void Flip(float direction)
    {
        if (direction > 0)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, _flipAmount, 0);
        }
    }
}