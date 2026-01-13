using Unity.VisualScripting;
using UnityEngine;

public class SimplePhysicsOverlap : MonoBehaviour
{
    public float radius = 5f;
    public float damage = 50f;

    public GameObject player;

    void Start()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Debug.Log("Damaged enemy: " + hit.name);
                MeshRenderer mesh = hit.GetComponent<MeshRenderer>();
                mesh.material.color = Color.red;

                float distance = Vector3.Distance(hit.gameObject.transform.position, player.transform.position);
                Debug.Log($"Distance enemy {hit.name} to {player.name} is {distance}");
            }
        }
        //Destroy(gameObject, 0.1f);
    }

    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
