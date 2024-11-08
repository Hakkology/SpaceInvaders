using System;
using UnityEngine;

public class Player : MonoBehaviour 
{
    public float speed = 5.0f;
    public Projectile laserPrefab;
    private bool _laserActive;

    void Update() 
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!_laserActive)
        {
            Projectile laser =  Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            laser.destroyed += LaserReset;
            _laserActive = true;
        }

    }

    private void LaserReset()
    {
        _laserActive = false;
    }
}