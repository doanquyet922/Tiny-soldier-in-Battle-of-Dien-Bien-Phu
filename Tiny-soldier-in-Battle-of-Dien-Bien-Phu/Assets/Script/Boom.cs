using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    Camera cam;
    public int boom = 0;
    public GameObject ballprefab;
    GameObject m_ball_obj;
    Ball ball;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    //---------------------------------------
    void Start()
    {

        cam = Camera.main;
        GameManager.ins.SetBoom(boom);
        //ball.DesactivateRb();
    }

    void Update()
    {
        if (boom>0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                m_ball_obj = Instantiate(ballprefab, trajectory.transform.position, Quaternion.identity);
                m_ball_obj.transform.parent = gameObject.transform;
                ball = m_ball_obj.GetComponent<Ball>();
                isDragging = true;
                OnDragStart();
            }
            if (Input.GetMouseButtonUp(1))
            {
                isDragging = false;
                OnDragEnd();
            }
        }
        

        if (isDragging)
        {
            OnDrag();
        }
    }

    //-Drag--------------------------------------
    void OnDragStart()
    {
        ball.DesactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        //just for debug
        Debug.DrawLine(startPoint, endPoint);


        trajectory.UpdateDots(ball.pos, force);
    }

    void OnDragEnd()
    {
        //push the ball
        ball.ActivateRb();
        ball.Push(force);
        boom--;
        GameManager.ins.SetBoom(boom);

        m_ball_obj.transform.parent = null;
        trajectory.Hide();
    }
}
