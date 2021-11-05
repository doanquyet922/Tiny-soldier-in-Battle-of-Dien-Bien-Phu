using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{

    public GameObject medKit;
    public int maxHealth = 100;
    public int curentHealth;
    Animator animator;
    Collider2D collider;
    public HealthBar healthBar;
    public bool isDied = false;
    public GameObject explosiveBig;

    public AudioSource audio;
    public AudioClip audio_death;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = this.GetComponent<Animator>();
        collider = this.GetComponent<Collider2D>();
        curentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(curentHealth);
    }
    public void TakeDamge(int dame)
    {
        
        curentHealth -= dame;
        
        
        if (curentHealth <= 0 && isDied == false)
        {
            
            this.Die();
            if(medKit)
            Instantiate(medKit, transform.position, Quaternion.identity);
        }
    }
    public void Die()
    {
        if (audio && audio_death)
        {

            //audio.PlayOneShot(audio_death);
            AudioSource.PlayClipAtPoint(audio_death, transform.position);
        }
            
        isDied = true;
        if (explosiveBig)
        {
            explosiveBig.transform.localScale = new Vector3(5, 5, 0);
            GameObject a = Instantiate(explosiveBig, transform.position, Quaternion.identity);
            Destroy(a,1);
            Destroy(gameObject);
            return;
        }
        EnemyAI ene = GetComponent<EnemyAI>();
        if(ene)
        ene.onMove = false;
        if (this.animator && this.collider)
        {
            
            this.animator.SetTrigger("die");
            this.collider.enabled = false;
            
            
        }
        
        Destroy(this.gameObject,3);



    }
  
   

}
