using UnityEngine;

namespace Bullet
{
    public class BulletLocator : MonoBehaviour
    {
        [SerializeField] private BulletBase bulletBase;

        public BulletBase BulletBase => bulletBase;
    }
}