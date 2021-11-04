
using UnityEngine;

public class Ball : MonoBehaviour
{
	public GameObject explosive;
	public int  damage;
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D col;
	 public AudioSource aus;

	[HideInInspector] public Vector3 pos { get { return transform.position; } }

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<CircleCollider2D> ();
	}

	public void Push (Vector2 force)
	{
		rb.AddForce (force, ForceMode2D.Impulse);
	}

	public void ActivateRb ()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb ()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LimitBullet") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy") || collision.CompareTag("Ground"))
        {
			if (explosive)
			{
				if (this.aus)
				{

					Debug.Log("AAA");
					aus.enabled = true;
					AudioSource.PlayClipAtPoint(aus.clip, transform.position);
				}
				
				GameObject e = Instantiate(explosive, transform.position, Quaternion.identity);
				Destroy(e, 1);
			}
		}
        if (collision.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject;
            HealthEnemy hd = enemy.GetComponent<HealthEnemy>();
            hd.TakeDamge(damage);
           
            Destroy(gameObject);
        }

    }
}

