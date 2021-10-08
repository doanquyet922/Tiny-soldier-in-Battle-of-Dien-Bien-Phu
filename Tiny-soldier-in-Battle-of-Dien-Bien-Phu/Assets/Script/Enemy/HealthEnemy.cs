using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    
    public int health = 100;
     Animator animator;
    Collider2D collider;
    public bool isDied = false;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = this.GetComponent<Animator>();
        collider = this.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(int dame)
    {
        health -= dame;

        Debug.Log(health);
        if (health <= 0)
        {
            this.Die();
        }
    }
    public void Die()
    {
        if (this.animator && this.collider)
        {
            isDied = true;
            this.animator.SetTrigger("die");
            this.collider.enabled = false;
            
            StartCoroutine(DestroyEnemyDie());
        }
        
        
        
        
    }
    IEnumerator DestroyEnemyDie()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
   

}
