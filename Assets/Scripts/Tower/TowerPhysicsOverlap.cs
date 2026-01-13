using UnityEngine;

public class TowerPhysicsOverlap : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private GameObject target;

    private GameObject closestEnemy;
    private bool enemyFound = false;

    void Update()
    {
        UpdateTarget();

        if (target != null)
        {
            MeshRenderer mesh = target.GetComponent<MeshRenderer>();
            mesh.material.color = Color.red;
            transform.LookAt(target.transform.position);
        }
        
        SetAttackingState();
    }

    private void UpdateTarget()
    {
        float minDistance = Mathf.Infinity;
        enemyFound = false;
        
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                enemyFound = true;
                
                MeshRenderer mesh = hit.GetComponent<MeshRenderer>();
                mesh.material.color = Color.orange;
                
                float distance = Vector3.Distance(hit.gameObject.transform.position, this.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = hit.gameObject;
                }
            }
        }
    }

    private void SetAttackingState()
    {
        TowerAttack ta = this.gameObject.GetComponent<TowerAttack>();
        if (enemyFound)
        {
            target = closestEnemy;
            if(ta != null) ta.StartAttacking();
        }
        else
        {
            target = null;
            if (ta != null) ta.StopAttacking();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
