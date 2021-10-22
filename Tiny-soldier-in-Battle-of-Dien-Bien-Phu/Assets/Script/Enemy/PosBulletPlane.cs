using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosBulletPlane : MonoBehaviour
{
    public GameObject planeBullet;
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
       
        if (collision.CompareTag("PlaneCheck"))
        {
           
            Shoot();
        }
    }
    void Shoot()
    {
        SpriteRenderer rd = transform.GetComponentInParent<SpriteRenderer>();
        float angle = rd.flipX ? 180f : 0f;
        Instantiate(planeBullet, this.transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
    }
}
