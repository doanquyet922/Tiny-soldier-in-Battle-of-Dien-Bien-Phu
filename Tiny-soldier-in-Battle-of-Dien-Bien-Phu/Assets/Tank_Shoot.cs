using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Shoot : MonoBehaviour
{

    

    Vector2 targetPos;

    public GameObject fireGun;

    public float damge_Tank = 200;

    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        explosion.transform.localScale = new Vector3(2, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
        
        
    }

    IEnumerator Shoot()
    {

        

        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        GameObject explo = Instantiate(explosion, targetPos, Quaternion.identity);
        
        fireGun.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        fireGun.SetActive(false);
        Destroy(explo);

        

    }


    


}
