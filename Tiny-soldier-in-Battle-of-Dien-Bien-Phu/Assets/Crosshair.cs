using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    Vector2 targetPos;
    public int damage = 10;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = targetPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("dame");
            HealthEnemy healthEnemy = collision.gameObject.GetComponent<HealthEnemy>();
            healthEnemy.TakeDamge(damage);
        }
        if (collision.CompareTag("Player"))
        {
            HealthPlayer healthPlayer = collision.gameObject.GetComponent<HealthPlayer>();
            healthPlayer.TakeDamge(damage);
        }


    }
    public void SetEnableColision(bool col)
    {
        collider.enabled = col;
    }
}
