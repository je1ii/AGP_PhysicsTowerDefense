using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> pathPoints;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float threshold = 0.1f;
    
    private int currentPathPointIndex = 0;
    
    void Update()
    {
        if(pathPoints == null) return;
        
        // assigning path point and enemy movement:
        Transform target = pathPoints[currentPathPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        
        // check if enemy reached the path point and switches next path point:
        if (Vector3.Distance(transform.position, target.position) < threshold)
        {
            currentPathPointIndex = (currentPathPointIndex + 1) % pathPoints.Count;
        }
    }
}
