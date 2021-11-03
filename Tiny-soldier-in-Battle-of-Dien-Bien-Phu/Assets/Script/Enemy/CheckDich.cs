using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDich : MonoBehaviour
{
    EnemyAI enemyAI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyAI = GetComponentInChildren<EnemyAI>();
        if (enemyAI == null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            EnemyAI e = GetComponentInChildren<EnemyAI>();
            e.onMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnemyAI e = GetComponentInChildren<EnemyAI>();
            if (e)
            {
                e.onMove = true;
            }

        }
    }
}
