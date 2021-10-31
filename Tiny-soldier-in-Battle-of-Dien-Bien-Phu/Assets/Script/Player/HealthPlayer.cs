using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int  maxHealth = 100;
    public int curentHealth;
    Animator animator;
    Collider2D collider;
    public HealthBar healthBar;
    //public bool isDied = false;
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
        
        if (curentHealth <= 0)
        {
            this.Die();
        }
    }
    public void Die()
    {
        if (this.animator && this.collider)
        {
            //isDied = true;
            this.animator.SetTrigger("die");
            StartCoroutine(ShowGameOver());
        }




    }
    IEnumerator DestroyEnemyDie()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    IEnumerator ShowGameOver()
    {

        yield return new WaitForSeconds(2);
        GameManager.ins.ShowGameOver();
    }
}
