using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 20;
    public GameObject explosive;

    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity = transform.right * speed;
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LimitBullet") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            
           
            GameObject enemy = collision.gameObject;
            HealthEnemy hd = enemy.GetComponent<HealthEnemy>();
            hd.TakeDamge(damage);
            if (explosive)
            {
                GameObject e= Instantiate(explosive, transform.position, Quaternion.identity);
                Destroy(e,1);
            }
            Destroy(gameObject);
        }
        
    }
}
