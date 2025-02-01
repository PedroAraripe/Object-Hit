using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float movementVelocity = 10;

    void Update()
    {
        float movementAcceleration = Time.deltaTime * movementVelocity;

        float xValue = Input.GetAxis("Horizontal") * movementAcceleration;
        float yValue = 0;
        float zValue = Input.GetAxis("Vertical") * movementAcceleration;
        transform.Translate(xValue, yValue, zValue);
    }
}
