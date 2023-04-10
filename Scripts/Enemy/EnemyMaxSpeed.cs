using UnityEngine;

namespace Enemy
{
    public class EnemyMaxSpeed : MonoBehaviour
    {
        [SerializeField] private EnemyBoss enemyBoss;

        private void OnTriggerEnter(Collider other)
        {
            enemyBoss.SetMaxSpeed();
        }
    }
}