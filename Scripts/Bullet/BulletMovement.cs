using UnityEngine;

namespace Bullet
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        void Update() => transform.Translate(0, 0, _speed * Time.deltaTime);
    }
}