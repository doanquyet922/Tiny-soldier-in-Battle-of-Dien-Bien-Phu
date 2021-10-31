using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Animator animator;
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    float timeUnitFire;
    CharacterController2D pm;

    public AudioSource aus;
    public AudioClip auc_shoot;
    bool m_CheckShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        pm = gameObject.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")  )
        {
            animator.SetBool("shoot", true);
                        
        }
        if (m_CheckShoot == true && timeUnitFire < Time.time)
        {
            StartCoroutine(Shoot());
            timeUnitFire = Time.time + fireRate;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("shoot", false);
        }
        if (animator.GetBool("shoot") == false)
        {
            m_CheckShoot = false;
            StopAllCoroutines();
        }
        
       
    }

    private IEnumerator Shoot()
    {

        float angle = pm.m_FacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        aus.PlayOneShot(auc_shoot);
        yield return new WaitForSeconds(fireRate);
        StartCoroutine(Shoot());
    }
    public void SetCheckShootTrue()
    {
        m_CheckShoot = true;
    }
}
