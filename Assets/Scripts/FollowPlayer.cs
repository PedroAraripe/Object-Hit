using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    float projectileSpeed = 7;

    void Update()
    {
       Vector3 playerPos = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
       Vector3 currentPos = gameObject.transform.position;

       Vector3 direction = (playerPos - currentPos).normalized;

       transform.Translate(direction * Time.deltaTime * projectileSpeed);
    }
}
