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

    // Start is called before the first frame update
    void Start()
    {
        pm = gameObject.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && timeUnitFire < Time.time)
        {
            animator.SetBool("shoot", true);
            StartCoroutine(Shoot());
            timeUnitFire = Time.time + fireRate;
        }
        if (Input.GetButtonUp("Fire1") )
        {
            animator.SetBool("shoot", false);
            StopAllCoroutines();
        }
    }

    private IEnumerator Shoot()
    {
        
        float angle = pm.m_FacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, FirePoint.position,Quaternion.Euler(new Vector3(0, 0, angle)));
        yield return new WaitForSeconds(fireRate);
        StartCoroutine(Shoot());
    }
}
