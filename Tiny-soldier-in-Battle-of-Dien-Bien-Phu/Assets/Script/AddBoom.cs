using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Boom boom = collision.gameObject.GetComponent<Boom>();
            boom.AddBoom();
            Destroy(gameObject);
        }
    }
}
