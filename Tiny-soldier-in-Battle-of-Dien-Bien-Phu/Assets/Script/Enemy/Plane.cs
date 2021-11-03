using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float speed=3f;
    public Rigidbody2D rb;
    public SpriteRenderer rd;
    public GameObject explosive;
    HealthEnemy he;
    public AudioSource aus;
   
    // Start is called before the first frame update
    void Start()
    {
        rd.flipX = true;
        he = GetComponent<HealthEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector2(speed *Time.deltaTime*10, rb.velocity.y);
        if (he && he.isDied == true)
        {
            
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlaneLimitLeft"))
        {
            speed = Mathf.Abs(speed);
            rd.flipX = true;
        }
        if (collision.CompareTag("PlaneLimitRight"))
        {
            speed = speed * -1;
            rd.flipX = false;
        }
        if (collision.CompareTag("Ground"))
        {
            
            if (explosive)
            {
                aus.PlayOneShot(aus.clip);
                GameObject e = Instantiate(explosive, transform.position, Quaternion.identity);
                Destroy(e, 1); 
                

            }
            Destroy(gameObject,1);
        }

    }
   
}
