using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smooth;
    [SerializeField] private float offset;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x + offset, transform.position.y, transform.position.z), smooth * Time.deltaTime);
    }
}