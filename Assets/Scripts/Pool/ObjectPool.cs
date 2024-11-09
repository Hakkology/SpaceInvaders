using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    public Projectile prefab; // Prefab referansı
    public int poolSize = 3;
    protected Queue<Projectile> _pool; // Queue kullanımı

    protected virtual void Awake()
    {
        InitializePool();
    }

    public void InitializePool()
    {
        _pool = new Queue<Projectile>();

        for (int i = 0; i < poolSize; i++)
        {
            Projectile projectile = Instantiate(prefab, this.transform);
            projectile.gameObject.SetActive(false);
            projectile.OnDestroyed += ReturnToPool;
            _pool.Enqueue(projectile);
        }
    }

    public Projectile GetFromPool()
    {
        if (_pool.Count > 0)
        {
            Projectile projectile = _pool.Dequeue();
            projectile.gameObject.SetActive(true);
            return projectile;
        }
        return null;
    }

    private void ReturnToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        _pool.Enqueue(projectile);
    }
}