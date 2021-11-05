using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBaduka : MonoBehaviour
{
    public int damage = 20;
    public GameObject explosive;
    public AudioClip explosiveSound;
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
        if (collision.CompareTag("LimitBullet") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            if (explosive && explosiveSound)
            {
                AudioSource.PlayClipAtPoint(explosiveSound, transform.position);
                GameObject e = Instantiate(explosive, transform.position, Quaternion.identity);
                Destroy(e, 1);
            }
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (explosiveSound)
                AudioSource.PlayClipAtPoint(explosiveSound, transform.position);
            GameObject player = collision.gameObject;
            HealthPlayer hd = player.GetComponent<HealthPlayer>();
            hd.TakeDamge(damage);
            if (explosive)
            {
                GameObject e = Instantiate(explosive, transform.position, Quaternion.identity);
                Destroy(e, 1);
            }

        }
    }
}
