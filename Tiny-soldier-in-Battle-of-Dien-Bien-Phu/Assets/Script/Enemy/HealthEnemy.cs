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
        
    }
    public void TakeDamge(int dame)
    {
        curentHealth -= dame;
        healthBar.SetHealth(curentHealth);
        
        if (curentHealth <= 0 && isDied == false)
        {
            this.Die();
            Instantiate(medKit, transform.position, Quaternion.identity);
        }
    }
    public void Die()
    {
        isDied = true;
        EnemyAI ene = GetComponent<EnemyAI>();
        ene.onMove = false;
        if (this.animator && this.collider)
        {
            
            this.animator.SetTrigger("die");
            this.collider.enabled = false;
            
            
        }
        StartCoroutine(DestroyEnemyDie());
        



    }
    IEnumerator DestroyEnemyDie()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
   

}
