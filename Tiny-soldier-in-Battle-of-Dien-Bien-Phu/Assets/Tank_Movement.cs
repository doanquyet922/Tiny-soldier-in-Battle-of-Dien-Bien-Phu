using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Movement : MonoBehaviour
{

       
    public Rigidbody2D rb;
    float m_movehorizontal = 0f;
    public float speed = 20f;

    public bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        m_movehorizontal = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;
        Vector3 targetVelocity = new Vector2(m_movehorizontal * 10f, rb.velocity.y);
        // And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (m_movehorizontal > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (m_movehorizontal < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
