using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static implicit operator UnityEngine.Sprite(Sprite v)
    {
        throw new NotImplementedException();
    }
}
