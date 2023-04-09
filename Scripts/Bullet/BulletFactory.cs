using Pool;
using UnityEngine;

namespace Bullet
{
    //public class BulletFactory
    //{
    //    private readonly PoolInstantiateObject<BulletBase> _poolBullet;
    //    private readonly Transform _content;

    //    public BulletFactory(PoolInstantiateObject<BulletBase> poolBullet, Transform content)
    //    {
    //        _content = content;
    //        _poolBullet = poolBullet;
    //    }

    //    public BulletBase Spawn(Vector3 position, Quaternion rotation)
    //    {
    //        var obj = _poolBullet.GetInstantiate();
    //        var transform = obj.transform;
    //        transform.parent = _content;
    //        transform.position = position;
    //        transform.rotation = rotation;
    //        return obj;
    //    }
    //}
}