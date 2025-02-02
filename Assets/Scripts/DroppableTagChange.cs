using UnityEngine;

public class DroppableTagChange : MonoBehaviour
{
    private string lastTag;
    float HeightInative = 25;
    Rigidbody rb;
    MeshRenderer meshR;

    void Start()
    {
        lastTag = gameObject.tag;
        rb = GetComponent<Rigidbody>();
        meshR = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        string currentTag = gameObject.tag;

        if (currentTag != lastTag) {
            if(currentTag == "DroppableInactive") {
                ChangedTagToInactive();

            } else if(currentTag == "DroppableFinished") {
                ChangedTagToFinished();

            }

            lastTag = currentTag;
        }

    }

    void ChangeHeight(float height) {
        Vector3 pos = transform.position;
        pos.y = height;

        transform.position = pos;
    }

    void ChangedTagToInactive() {
        rb.useGravity = false;
        meshR.enabled = false;
        
        ChangeHeight(HeightInative);
    }

    void ChangedTagToFinished() {
       rb.useGravity = true;
       meshR.enabled = true;
    }
}
