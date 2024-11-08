using System;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    public Action destroyed;
    public Vector3 direction;
    public float speed;

    void Update() 
    {
        transform.position += this.direction * this.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        this.destroyed.Invoke();
        Destroy(this.gameObject);
    }

}

