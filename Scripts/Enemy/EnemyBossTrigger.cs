using UnityEngine;
using Enemy;

public class EnemyBossTrigger : MonoBehaviour
{
    [SerializeField] private EnemyBoss boss;
    [SerializeField] private float distanceToBoss;

    private bool isBossFight = false;

    private void Start()
    {
        transform.position = new Vector3(distanceToBoss, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position += new Vector3(distanceToBoss, 0, 0);

        if(!isBossFight)
        {
            boss.gameObject.SetActive(true);
            boss.Init();
            isBossFight = true;
        }   
    }

    public void BossKilled()
    {
        isBossFight = false;
        boss.gameObject.SetActive(false);
    }
}