using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform Barrel;
    public GameObject e_panel;
    public GameObject exitCanvas;
    public GameObject bulletCannon;
    public Transform shootPoint;
    public Animator animator;
    public AudioSource aus;
    Vector2 direction;
    GameObject player;
    bool m_shoot = false;
    bool clickE = false;
    bool showE=false;

    public float fireRate;
    float ReadyForNextShoot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && m_shoot==false && showE==true)
        {
            m_shoot = true;
            if(player)
            {
                
                PlayerMovement pm = player.GetComponent<PlayerMovement>();
                WeaponController weapon = player.GetComponent<WeaponController>();

                pm.enable = false;
                weapon.enabled = false;
            }    
           

            e_panel.SetActive(false);
            exitCanvas.SetActive(true);
            

        }
        if (Input.GetKeyDown(KeyCode.R) )
        {
            m_shoot = false;
            if(player)
            {
                PlayerMovement pm = player.GetComponent<PlayerMovement>();
                WeaponController weapon = player.GetComponent<WeaponController>();

                pm.enable = true;
                weapon.enabled = true;
            }


            e_panel.SetActive(true);
            exitCanvas.SetActive(false);
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Barrel.position;
        if (m_shoot)
        {
            FaceMouse();
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > ReadyForNextShoot)
                {
                    ReadyForNextShoot = Time.time + 1 / fireRate;
                    Shoot();
                }
                
            }
        }

       
    }
  
    private void FaceMouse()
    {
        //pháo đang nhìn sang hướng bên phải thì nhân vật ở bên trái và nhìn hướng phải
        if (direction.x >0)
        {
            player.transform.position = new Vector3(transform.position.x - 1.5f, player.transform.position.y, player.transform.position.z);
            if (player.transform.localScale.x < 0)
            {

                player.transform.localScale = new Vector3(Mathf.Abs(player.transform.localScale.x), player.transform.localScale.y, player.transform.localScale.z);
                CharacterController2D ct = player.GetComponent<CharacterController2D>();
                ct.m_FacingRight = true;
            }
        }
        else
        {
            player.transform.position = new Vector3(transform.position.x + 1.5f, player.transform.position.y, player.transform.position.z);
            
            if (player.transform.localScale.x > 0)
            {
                player.transform.localScale = new Vector3(player.transform.localScale.x * -1, player.transform.localScale.y, player.transform.localScale.z);
                CharacterController2D ct = player.GetComponent<CharacterController2D>();
                ct.m_FacingRight = false;
            }
        }
        Barrel.transform.right = direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            showE = true;
            player = collision.gameObject;
            e_panel.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            showE = false;
            
            e_panel.SetActive(false);
            
        }
    }
    void Shoot()
    {
       GameObject bullet= Instantiate(bulletCannon, shootPoint.position, shootPoint.rotation);
        animator.SetTrigger("shoot");
        aus.PlayOneShot(aus.clip);
        Destroy(bullet, 3);
    }
}
