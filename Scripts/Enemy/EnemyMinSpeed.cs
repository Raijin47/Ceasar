using UnityEngine;

namespace Enemy
{
    public class EnemyMinSpeed : MonoBehaviour
    {
        [SerializeField] private EnemyBoss enemyBoss;

        private void OnTriggerEnter(Collider other)
        {
            enemyBoss.SetMinSpeed();
        }
    }
}