using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthPlayer : MonoBehaviour
{
    public GameObject addHeath;
    public int  maxHealth = 200;
    public int curentHealth;
    Animator animator;
    Collider2D collider;
    public HealthBar healthBar;

    public AudioSource audio;
    public AudioClip audio_death;
    public GameObject explosiveBig;
    //public bool isDied = false;
    // Start is called before the first frame update
    void Start()
    {

        addHeath.SetActive(false);

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
        if (audio && audio_death)
        {

            //audio.PlayOneShot(audio_death);
            AudioSource.PlayClipAtPoint(audio_death, transform.position);
        }

        
        if (explosiveBig)
        {
            explosiveBig.transform.localScale = new Vector3(5, 5, 0);
            GameObject a = Instantiate(explosiveBig, transform.position, Quaternion.identity);
            Destroy(a, 1);
            Destroy(gameObject);
            return;
        }
        if (this.animator && this.collider)
        {
            //isDied = true;
            collider.enabled = false;
            
            audio.PlayOneShot(audio_death);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MedKit"))
        {
            StartCoroutine(ShowAddHealth());
            Destroy(collision.gameObject);
            curentHealth = curentHealth + 50;

            if (curentHealth >= maxHealth)
            {
                curentHealth = maxHealth;
            }

            healthBar.SetHealth(curentHealth);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Thorn"))
        {
            this.Die();

        }
    }

    public IEnumerator ShowAddHealth()
    {
        addHeath.SetActive(true);
        yield return new WaitForSeconds(1);
        addHeath.SetActive(false);
    }
}
