using UnityEngine;

public class SimpleOnTrigger : MonoBehaviour
{
    public float damage = 50f;

    public MeshRenderer enemyMesh;

    void Start()
    {
        SphereCollider sc = gameObject.GetComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = 5f;

        //Destroy(gameObject,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyMesh = other.GetComponent<MeshRenderer>();
            enemyMesh.material.color = Color.red;
            Debug.Log($"Damage enemy: " + other.name);
        }
    }
}
