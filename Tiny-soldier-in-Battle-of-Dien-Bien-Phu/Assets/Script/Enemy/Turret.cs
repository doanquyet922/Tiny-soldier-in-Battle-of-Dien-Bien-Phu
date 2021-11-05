using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float Range;

     Transform target;

    bool Dectected = false;

    Vector2 Direction;

    public GameObject AlarmLight;
    public GameObject Gun;
    public GameObject Bullet;
    public GameObject ShootPoint;

    public float Force;
    public float fireRate;
    float nextTimeToFire;
    public AudioSource aus;
    public AudioClip auc;
    Vector2 mousePos;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
        HealthPlayer pm = FindObjectOfType<HealthPlayer>();
        target = pm.gameObject.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (target)
        {
             targetPos = target.position;
            Direction = targetPos - (Vector2)transform.position;
        }
        
        

        
        float distance = Vector2.Distance((Vector2)transform.position,targetPos);

        if (distance<Range)
        {
            if (Dectected == false)
            {
                Dectected = true;
                AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else
        {
            if (Dectected == true)
            {
                Dectected = false;
                AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
        
        if (Dectected == true)
        {
            Gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + (2 / fireRate);
                Shoot();
            }
        }
        if (target)
        {
            Tank_Shoot ts = target.GetComponent<Tank_Shoot>();
            if (ts.GetShooted() == true && DistanceObjAndMouse()<3f)
            {
                HealthEnemy he = GetComponent<HealthEnemy>();
                he.TakeDamge(ts.damge_Tank);
            }
        }
        

    }

    private void Shoot()
    {
        aus.PlayOneShot(auc); 
        GameObject bulletIns = Instantiate(Bullet,ShootPoint.transform.position,ShootPoint.transform.rotation);
        bulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);

    }
    public float DistanceObjAndMouse()
    {
        return Vector2.Distance((Vector2)transform.position,mousePos);
    }
}
