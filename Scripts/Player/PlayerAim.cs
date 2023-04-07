using UnityEngine;

namespace Player
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float smooth;
        [SerializeField] private float limitMin;
        [SerializeField] private float limitMax;
        private float rotationX;

        void Update()
        {
            rotationX -= Input.GetAxis("Mouse Y") * speed;
            rotationX = Mathf.Clamp(rotationX, limitMin, limitMax);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationX, 0, 11.248f), Time.deltaTime * smooth);
        }
    }
}