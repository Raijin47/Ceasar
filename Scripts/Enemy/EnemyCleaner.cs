using UnityEngine;

namespace Enemy
{
    public class EnemyCleaner : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<EnemyBase>().Cleaner();
        }
    }
}