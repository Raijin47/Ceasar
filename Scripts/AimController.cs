using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float rotationX;
    [SerializeField] private float smooth;
    [SerializeField] private float lookXLimitDown;
    [SerializeField] private float lookXLimitUp;

    void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * speed;
        rotationX = Mathf.Clamp(rotationX, lookXLimitDown, lookXLimitUp);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationX, 0, 0), Time.deltaTime * smooth);
    }
}
