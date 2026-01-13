using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 2;

    void Update()
    {
        if (health <= 0) 
            Destroy(this.gameObject);
    }
    
    public void Damage(int damage)
    {
        health -= damage;
    }
}
