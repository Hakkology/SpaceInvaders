// using System.Collections.Generic;
// using UnityEngine;

// public class ProjectilePool : MonoBehaviour
// {
//     public static ProjectilePool Instance { get; private set; } // Singleton instance
//     public Projectile laserPrefab;
//     public int poolSize = 3;
//     private Queue<Projectile> _pool; // Queue kullanımı

//     void Awake()
//     {
//         if (Instance == null)
//             Instance = this;
//         else
//             Destroy(gameObject);

//         InitializePool();
//     }

//     public void InitializePool()
//     {
//         _pool = new Queue<Projectile>();

//         for (int i = 0; i < poolSize; i++)
//         {
//             Projectile projectile = Instantiate(laserPrefab, this.transform);
//             projectile.gameObject.SetActive(false);
//             projectile.OnDestroyed += ReturnToPool;
//             _pool.Enqueue(projectile); // Kuyruğa ekle
//         }
//     }

//     public Projectile GetFromPool()
//     {
//         if (_pool.Count > 0)
//         {
//             Projectile projectile = _pool.Dequeue();
//             projectile.gameObject.SetActive(true);
//             return projectile;
//         }
//         return null; // Havuzda aktif olmayan bir proje bulunamadı
//     }

//     private void ReturnToPool(Projectile projectile)
//     {
//         projectile.gameObject.SetActive(false);
//         _pool.Enqueue(projectile); // Kuyruğa geri ekle
//     }
// }
