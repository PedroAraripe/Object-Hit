using UnityEngine;

public class DroppableTagChange : MonoBehaviour
{
    private string lastTag;
    float HeightInative = 25;
    Rigidbody rb;

    void Start()
    {
        lastTag = gameObject.tag;
        rb = GetComponent<Rigidbody>();
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
        ChangeHeight(HeightInative);
    }

    void ChangedTagToFinished() {
       rb.useGravity = true;
    }
}
