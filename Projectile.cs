using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    
    public int numProjectile;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    
    void Update()
    {
        if(numProjectile > 0)
        {
            numProjectile--;
        }
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cog"))
        {
            numProjectile++;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy") 
        {   
            EnemyController e = other.collider.GetComponent<EnemyController>();
              if (e != null)

            {
                e.Fix();
            }
        }

        else if (other.gameObject.tag == "HardEnemy") 
        {    
            HardEnemyController e = other.collider.GetComponent<HardEnemyController>(); 
              if (e != null)

            {
                e.Fix();
            }
        }
        Destroy(gameObject);
    }
}