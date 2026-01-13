using System.Collections;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float aliveTime = 3f;
    [SerializeField] private float attackInterval = 1f;
    [SerializeField] private float damage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackInterval);

        GameObject bulletInstance = Instantiate(bullet, spawnPoint);
        Rigidbody rb = bulletInstance.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.angularVelocity = spawnPoint.forward * speed;
        }

        Destroy(bulletInstance, aliveTime);
    }
}
