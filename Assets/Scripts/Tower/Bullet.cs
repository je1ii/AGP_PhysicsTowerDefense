using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float aliveTime = 3f;
    [SerializeField] private int damage = 1;
    
    void Start()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(speed * transform.forward, ForceMode.VelocityChange);
        }

        Destroy(this.gameObject, aliveTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth hp = collision.gameObject.GetComponent<EnemyHealth>();
            if(hp!=null) hp.Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
