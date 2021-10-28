using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    bool win = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthEnemy[] enemys = FindObjectsOfType<HealthEnemy>();
       
        if (enemys.Length == 0)
        {
            win = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && win==true)
        {
            animator.SetTrigger("pullFlag");
            GameManager.ins.GameWin();
        }
    }
}
