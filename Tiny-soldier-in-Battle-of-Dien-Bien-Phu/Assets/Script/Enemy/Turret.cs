using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float Range;

     Transform target;

    bool Dectected = false;

    Vector2 Direction;

    public GameObject AlarmLight;
    public GameObject Gun;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement pm = FindObjectOfType<PlayerMovement>();
        target = pm.gameObject.transform; ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        Direction = targetPos - (Vector2) transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Dectected == false)
                {
                    Dectected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
               
            }
            else
            {
                if (Dectected == true)
                {
                    Dectected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
        else
        {
            if (Dectected == true)
            {
                Dectected = false;
                AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
        if (Dectected == true)
        {
            Gun.transform.up = Direction;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);

    }
}
