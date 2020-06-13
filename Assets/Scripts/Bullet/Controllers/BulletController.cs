using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController 
{
    private readonly BulletView _bulletView;
    private readonly Pool<BulletView> _bulletPool;
    public BulletController(Pool<BulletView> bulletPool)
    {
        _bulletPool = bulletPool;
    }
    void Start()
    {
        
    }

   
    public void Shoot()
    {
        _bulletPool.GetObject();
    }

}
