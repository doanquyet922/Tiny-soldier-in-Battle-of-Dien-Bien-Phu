using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirot_Script : MonoBehaviour
{
    public GameObject Dialog_MoCua;

    

    public Animator die_anim;
    // Start is called before the first frame update
    void Start()
    {
        Dialog_MoCua.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            die_anim.SetTrigger("die");
            Dialog_MoCua.SetActive(true);
        }
    }
}
