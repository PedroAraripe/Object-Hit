using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        bool isHittedByPlayer = other.gameObject.CompareTag("Player");
        bool isAlreadyHitted = gameObject.CompareTag("Hitted");
        bool isProjectile = gameObject.CompareTag("Projectile");
        bool isFloor = other.gameObject.CompareTag("Ground");
        bool isProjectileGroupping = isProjectile && other.gameObject.CompareTag("Projectile");

        if(!isAlreadyHitted && isHittedByPlayer) {
            gameObject.tag = "Hitted";
            
            MeshRenderer myMeshRenderer = GetComponent<MeshRenderer>();
            
            if(myMeshRenderer) {
                myMeshRenderer.material.color = Color.black;
            } else {
                foreach( MeshRenderer childMeshRenderer in GetComponentsInChildren<MeshRenderer>()) {
                    childMeshRenderer.material.color = Color.black;
                }
            }
            
            PlayerScoreCounter playerScoreCounter = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerScoreCounter>();
            playerScoreCounter.AddCount();
            
            Debug.Log("Vezes acertadas: " + playerScoreCounter.SeeCount());
        }
        
        if(isProjectile && !isProjectileGroupping && !isFloor) {
            Destroy(gameObject);
        }
    }
}
