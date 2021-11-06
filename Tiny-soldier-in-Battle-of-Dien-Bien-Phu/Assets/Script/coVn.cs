using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coVn : MonoBehaviour
{
    bool onClick = false;
    SpriteRenderer rd;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onClick==true)
        {
            rd.enabled = true;
            StartCoroutine(Win());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onClick = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onClick = false;
        }
    }
    IEnumerator Win()
    {
        yield return new WaitForSeconds(3);
        GameManager.ins.GameWin();
    }
}
