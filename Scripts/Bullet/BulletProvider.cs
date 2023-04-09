using System.Collections.Generic;
using Pool;
using UnityEngine;

namespace Bullet
{
    //public class BulletProvider
    //{
    //    private List<BulletBase> _bulletBases = new List<BulletBase>();
    //    private readonly PoolInstantiateObject<BulletBase> _poolInstantiateObject;
    //    private readonly BulletFactory _bulletFactory;

    //    public BulletProvider(PoolInstantiateObject<BulletBase> poolInstantiateObject, Transform _content)
    //    {
    //        _bulletFactory = new BulletFactory(poolInstantiateObject, _content);
    //        _poolInstantiateObject = poolInstantiateObject;
    //    }

    //    private void InitEnemy(BulletBase bulletBase)
    //    {
    //        bulletBase.gameObject.SetActive(true);
    //        bulletBase.Clean += OnDie;
    //        bulletBase.Init();
    //    }

    //    private void OnDie(BulletBase bulletBase)
    //    {
    //        bulletBase.Clean -= OnDie;
    //        Remove(bulletBase);
    //    }

    //    public void CreateBullet(Vector3 position, Quaternion rotation)
    //    {
    //        var bulletBase = _bulletFactory.Spawn(position, rotation);
    //        if (IsHave(bulletBase))
    //            return;
    //        Add(bulletBase);
    //    }

    //    public void Add(BulletBase bulletBase)
    //    {
    //        _bulletBases.Add(bulletBase);
    //        InitEnemy(bulletBase);
    //    }

    //    public void Remove(BulletBase bulletBase)
    //    {
    //        bulletBase.gameObject.SetActive(false);
    //        _bulletBases.Remove(bulletBase);
    //        bulletBase.Release();
    //        _poolInstantiateObject.Release(bulletBase);
    //    }

    //    private bool IsHave(BulletBase bulletBase)
    //    {
    //        foreach (var Enemy in _bulletBases)
    //        {
    //            if (Enemy.GetInstanceID() == bulletBase.GetInstanceID()) return true;
    //        }
    //        return false;
    //    }
    //}
}