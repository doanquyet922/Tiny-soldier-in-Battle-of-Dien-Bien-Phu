using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject SafeLine;
    BoxCollider2D boxSL;

    public Transform player;
    public Transform elevatorSwitch;
    public Transform downPos;
    public Transform upperPos;

    

    public SpriteRenderer elevator;

    public float speed;
    bool isElevatorDown;
    // Start is called before the first frame update
    void Start()
    {
        boxSL = SafeLine.GetComponent<BoxCollider2D>();
        boxSL.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartElevator();
        
        DisplayColor();
    }


    void StartElevator()
    {
        if(Vector2.Distance(player.position,elevatorSwitch.position)<0.5f && Input.GetKeyDown("e"))
        {
            
            if(transform.position.y <= downPos.position.y)
            {            
                isElevatorDown = true;
                

            }
            else if (transform.position.y >= upperPos.position.y)
            {             
                isElevatorDown = false;
                
            }
            
        }
         
        if (isElevatorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
            
        }
        

    } 

   

    void DisplayColor()
    {
        if(transform.position.y <= downPos.position.y || transform.position.y >= upperPos.position.y)
        {

            elevator.color = Color.green;
            boxSL.enabled = false;
        }
        else
        {
            elevator.color = Color.red;
            boxSL.enabled = true;
        }
    }
}
