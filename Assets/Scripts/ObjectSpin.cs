using UnityEngine;

public class ObjectSpinHorizontal : MonoBehaviour
{
    float angularSpeed = 300;
    Rigidbody rb;
    Vector3 angularVelocity;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        InitAcellerationRotation();
    }

    private void Update() {
        InitAcellerationRotation();
    }

    private void InitAcellerationRotation() {
        float angVelocityAxis = Time.deltaTime * angularSpeed;
        
        if(gameObject.CompareTag("Horizontal")) {
            angularVelocity = new Vector3(0, angVelocityAxis, 0);
        } else if(gameObject.CompareTag("Vertical")) {
            angularVelocity = new Vector3(0, 0, angVelocityAxis);
        }
    
        rb.angularVelocity = angularVelocity;
    }
}
