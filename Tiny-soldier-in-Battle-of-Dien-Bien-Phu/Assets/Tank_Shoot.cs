using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Shoot : MonoBehaviour
{
   public Crosshair crosshair;
    Vector2 targetPos;
    public GameObject fireGun;
    public float damge_Tank = 200;
    public GameObject explosion;
    ExplosiveBig explosiveBig;
    public AudioSource aus;
    public AudioClip auc_Shoot;
    

    public float fireRate = 0.2f;
    float timeUnitFire;
    // Start is called before the first frame update
    void Start()
    {
        explosion.transform.localScale = new Vector3(3, 3, 0);
         
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.mousePresent && Input.GetMouseButtonDown(0) && timeUnitFire < Time.time)
        {
            timeUnitFire = Time.time + fireRate;
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickedPosition = transform.InverseTransformPoint(clickedPosition);
            
            if (clickedPosition.x>1 && clickedPosition.y > -1.1 )
            {
                StartCoroutine(Shoot());
            }

        }

    }

    IEnumerator Shoot()
    {


        aus.PlayOneShot(auc_Shoot);
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        GameObject explo = Instantiate(explosion, targetPos, Quaternion.identity);

        fireGun.SetActive(true);
        crosshair.SetEnableColision(true);
        yield return new WaitForSeconds(0.1f);
        crosshair.SetEnableColision(false);
        yield return new WaitForSeconds(0.3f);
        fireGun.SetActive(false);
        Destroy(explo);



    }
   



}
