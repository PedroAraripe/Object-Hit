using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float movementVelocity = 10;
    Vector3 oldMousePos;
    float movementAcceleration;
    [SerializeField] float accelerationRotation = 3;

    private void Start() {
        oldMousePos = new Vector3(0, Input.mousePosition.y, 0);
    }

    void Update()
    {
        movementAcceleration = Time.deltaTime * movementVelocity;

        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer() {
        float xValue = Input.GetAxis("Horizontal") * movementAcceleration;
        float yValue = 0;
        float zValue = Input.GetAxis("Vertical") * movementAcceleration;
        transform.Translate(xValue, yValue, zValue);
    }
    

    void RotatePlayer()
    {
        Vector3 currentMousePos = new Vector3(0, Input.mousePosition.y, 0);
        Vector3 playerRotation = new Vector3(
            currentMousePos.x - oldMousePos.x,
            currentMousePos.y - oldMousePos.y,
            currentMousePos.z - oldMousePos.z
        );

        float accelerationVelocity = accelerationRotation * Time.deltaTime;

        transform.Rotate(playerRotation * accelerationVelocity);

        oldMousePos = currentMousePos;
    }
}
