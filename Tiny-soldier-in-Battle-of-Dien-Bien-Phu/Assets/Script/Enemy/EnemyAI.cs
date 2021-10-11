using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

     Animator animator;
    public GameObject player;
    public float agroRange = 0f;
    public float moveSpeed = 0f;
    public float maxMove = 0f;
    public float minMove = 0f;
    //public WeaponController shooting;
    public Collider2D topCollider;
    Rigidbody2D rb;
    HealthEnemy he;
    public bool faceRight = true;

    
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    float timeUnitFire;
    float timeCouch = 1f;
    float timeUnitCouch;
    bool m_CheckShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        he = GetComponent<HealthEnemy>();
        

    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (timeUnitCouch < Time.time)
        {
           
            Crouch();
        }
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer < agroRange &&  he.isDied==false)
        {
            //if (animator.GetBool("isWakeup") == false)
            //{
            //    animator.SetBool("isWakeup", true);
            //}
            ChasePlayer();
            animator.SetBool("shoot", true);
            if(timeUnitFire < Time.time && m_CheckShoot==true)
            {
                this.StartCoroutine(Shoot());
            }
            
            //shooting.SetShooting(true);
        }
        else
        {
            animator.SetBool("shoot", false);
            m_CheckShoot = false;
            StopChasingPlayer();
            StopAllCoroutines();
            //if (distToPlayer > agroRange)
            //{
            //    StartCoroutine(SetSleep());
            //    //shooting.SetShooting(false);
            //}



        }
    }
    
    private void StopChasingPlayer()
    {rb.velocity = new Vector2(0, 0);
    }

    private void ChasePlayer()
    {
        if (transform.position.x < player.transform.position.x)
        {
            //transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMove, maxMove), transform.position.y);
            //rb.velocity = new Vector2(moveSpeed, 0);
            faceRight = true;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            

        }
        else
        {
            //transform.position = new Vector2(Mathf.Clamp(transform.position.x, minMove, maxMove), transform.position.y);
            //rb.velocity = new Vector2(-moveSpeed, 0);
            if (transform.localScale.x > 0)
            {
                faceRight = false;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
               
        }
    }
    //IEnumerator SetSleep()
    //{
    //    yield return new WaitForSeconds(3);
    //    if (animator.GetBool("isWakeup") == true)
    //    {
    //        animator.SetBool("isWakeup", false);
    //    }
    //}
    public void SetPlayer(GameObject player1)
    {
        player = player1;
    }
    void Crouch()
    {

         timeUnitCouch = Time.time + timeCouch;
        CharacterController2D ct = player.GetComponent<CharacterController2D>();
            if (ct.m_wasCrouching == true && he.isDied == false)
            {

                animator.SetBool("crouch", true);
                topCollider.enabled = false;

            }
            else
            {
                animator.SetBool("crouch", false);
                topCollider.enabled = true;
            }
          
        
        //StartCoroutine(Crouch());

    }
    private IEnumerator Shoot()
    {
        timeUnitFire = Time.time + fireRate;
        float angle = faceRight ? 0f : 180f;
        Instantiate(bulletPrefab, this.FirePoint.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        yield return new WaitForSeconds(fireRate);
        //StartCoroutine(Shoot());
    }
    public void SetCheckShootTrue()
    {
        m_CheckShoot = true;
    }
}
