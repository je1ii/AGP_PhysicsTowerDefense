using UnityEngine;

public class TowerPhysicsOverlap : MonoBehaviour
{
    public float radius = 5f;

    [SerializeField] private GameObject target;

    void Update()
    {
        UpdateTarget();

        if (target != null)
            transform.LookAt(target.transform.position);
    }

    private void UpdateTarget()
    {
        float minDistance = Mathf.Infinity;
        
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Debug.Log("Damaged enemy: " + hit.name);
                MeshRenderer mesh = hit.GetComponent<MeshRenderer>();
                mesh.material.color = Color.red;

                float distance = Vector3.Distance(hit.gameObject.transform.position, this.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    if(hit != null)
                        target = hit.gameObject;
                }

                Debug.Log($"Distance enemy {hit.name} to {this.name} is {distance}");
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
