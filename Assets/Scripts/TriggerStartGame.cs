using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerStartGame : MonoBehaviour
{
    // ^ inactive
    // v started 
    GameObject[] FindDroppables(string tag) {
        GameObject[] droppables = GameObject.FindGameObjectsWithTag(tag);
        return droppables;
    }

    void UpdateDroppablesTag(string initialTag, string endTag) {
        foreach(GameObject droppable in FindDroppables(initialTag)) {
            droppable.tag = endTag;
        }
    }

    void RestartDroppables() {
        UpdateDroppablesTag("DroppableFinished", "DroppableInactive");
    }

    void StartDroppables() {
        UpdateDroppablesTag("DroppableInactive", "DroppableFinished");
    }

    private void OnTriggerEnter(Collider other) {
        RestartDroppables();
    }

    private void OnTriggerExit(Collider other) {
        StartDroppables();
    }
}
