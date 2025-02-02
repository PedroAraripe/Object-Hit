using UnityEngine;

public class ObjectSpinHorizontal : MonoBehaviour
{
    float accelerationRotation = 200;

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * accelerationRotation, 0);        
    }
}
