using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerStartGame : MonoBehaviour
{
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

    void RestartProjectiles() {
        foreach(GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile")) {
            projectile.GetComponent<FollowPlayer>().enabled = false;
            projectile.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    
    void StartProjectiles() {
        foreach(GameObject projectile in GameObject.FindGameObjectsWithTag("Projectile")) {
            projectile.GetComponent<FollowPlayer>().enabled = true;
            projectile.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            RestartDroppables();
            RestartProjectiles();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            StartDroppables();
            StartProjectiles();
        }
    }
}
