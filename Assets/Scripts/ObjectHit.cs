using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    int counter = 0;
    private void OnCollisionEnter(Collision other) {
        bool isHittedByPlayer = other.gameObject.CompareTag("Player");
        bool isAlreadyHitted = gameObject.CompareTag("Hitted");
        bool isProjectile = gameObject.CompareTag("Projectile");
        bool isProjectileGroupping = isProjectile && other.gameObject.CompareTag("Projectile");

        if(!isAlreadyHitted && isHittedByPlayer) {
            gameObject.tag = "Hitted";
            
            GetComponent<MeshRenderer>().material.color = Color.black;
            counter = GameObject.FindGameObjectsWithTag("Hitted").Length;
            
            Debug.Log("Vezes acertadas: " + counter);
        }
        
        Debug.Log("Acertou algo " + isProjectile);

        if(isProjectile && !isProjectileGroupping) {
            Destroy(gameObject);
        }
    }
}
