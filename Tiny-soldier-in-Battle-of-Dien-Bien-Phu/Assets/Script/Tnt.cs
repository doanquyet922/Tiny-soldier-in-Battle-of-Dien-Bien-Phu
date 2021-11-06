using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tnt : MonoBehaviour
{
    public int time=3;
    public GameObject ExplosiveBig;
    public AudioSource aus;
    public AudioClip auc_BoomTime;
    public AudioClip auc_Exp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
        }
    }
    public int SetTime()
    {
        StartCoroutine(Exp());
        return time;
    }
    IEnumerator Exp()
    {
        aus.PlayOneShot(auc_BoomTime);
        yield return new WaitForSeconds(time);
        AudioSource.PlayClipAtPoint(auc_Exp,transform.position);
        GameObject Explosive = Instantiate(ExplosiveBig,transform.position,Quaternion.identity);
        Destroy(Explosive,1);
        Destroy(gameObject);
    }
}
