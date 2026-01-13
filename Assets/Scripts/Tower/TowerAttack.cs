using System.Collections;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float attackInterval = 1f;

        private bool canAttack = false;
        private Coroutine attackRoutine;

        private IEnumerator Attack()
        {
            while (canAttack)
            {
                Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(attackInterval);
            }
        }

        public void StartAttacking()
        {
            if(!canAttack)
            {
                canAttack = true;
                attackRoutine = StartCoroutine(Attack());
            }
        }

        public void StopAttacking()
        {
            if (canAttack)
            {
                canAttack = false;
                if (attackRoutine != null)
                {
                    StopCoroutine(attackRoutine);
                    attackRoutine = null;
                }
            }
        }
}
