using UnityEngine;
using System;

public class Projectile : MonoBehaviour 
{
    public Action<Projectile> OnDestroyed; // Action tanımlama

    public Vector3 direction;
    public float speed;

    void Update() 
    {
        transform.position += this.direction * this.speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        OnDestroyed?.Invoke(this); // Action tetikleniyor
    }
}
