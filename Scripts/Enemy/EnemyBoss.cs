using UnityEngine;
using System.Collections;

namespace Enemy
{
    public class EnemyBoss : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particleForObstacle;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Obstacle"))
            {
                if(!particleForObstacle.isPlaying)
                    particleForObstacle.Play();
                Debug.Log("ddd");
            }
        }



    }
}