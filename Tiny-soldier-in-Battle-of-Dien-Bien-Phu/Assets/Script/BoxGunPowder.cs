using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGunPowder : MonoBehaviour
{
    public GameObject explosive;
    public AudioSource aus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            if (explosive)
            {
                if (aus)
                {

                    AudioSource.PlayClipAtPoint(aus.clip, transform.position); 
                }
                GameObject metdkit =(GameObject) Resources.Load("Prefabs/MedKit");
                GameObject boom =(GameObject) Resources.Load("Prefabs/Boom");
                int random = Random.Range(0,2);
                if (random==0)
                {
                    Instantiate(boom, transform.position, Quaternion.identity);
                }else
                {
                    Instantiate(metdkit, transform.position, Quaternion.identity);
                }
                
                GameObject e = Instantiate(explosive, transform.position, Quaternion.identity);
                Destroy(e, 1);
            }
            
            Destroy(collision.gameObject);
        }
    }
}
