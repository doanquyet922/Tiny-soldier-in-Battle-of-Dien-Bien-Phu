using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeCac_Scripts : MonoBehaviour
{
    Animator animator;
    public GameObject eCanvas;
    public bool dauhang = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("dauhang");
        eCanvas.SetActive(true);
        dauhang = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
