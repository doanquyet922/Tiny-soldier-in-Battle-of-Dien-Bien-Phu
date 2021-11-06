using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBoom : MonoBehaviour
{
    bool setBoom = false;
    public GameObject tnt_boom;
    public Transform boomPoint;
    public GameObject DeCac;
    int boom = 1;
    public bool Destroy = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && setBoom==true && boom>0)
        {
            boom--;
            
            tnt_boom.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            GameObject boomPre= Instantiate(tnt_boom,boomPoint.position,Quaternion.identity);
            Tnt tnt = boomPre.GetComponent<Tnt>();
           int time= tnt.SetTime();
            if (DeCac)
            {
                StartCoroutine(ShowTuong(time));
            }
            if (Destroy == true)
            {
                Destroy(gameObject, time);
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            setBoom = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            setBoom = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            setBoom = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            setBoom = true;
        }
    }
    IEnumerator ShowTuong(int timeshow)
    {
        yield return new WaitForSeconds(timeshow+1);
        Debug.Log("Decac");
        DeCac.SetActive(true);
    }
}
