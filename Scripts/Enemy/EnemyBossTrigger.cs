using UnityEngine;

public class EnemyBossTrigger : MonoBehaviour
{
    [SerializeField] private float distanceToBoss;
    [SerializeField] private Transform spawnPos;

    private void Start()
    {
        transform.position = new Vector3(distanceToBoss, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position += new Vector3(distanceToBoss, 0, 0);

    }
}