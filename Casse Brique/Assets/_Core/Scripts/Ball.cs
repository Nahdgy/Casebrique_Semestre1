using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speedBall;
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private int all = 0;
  
//Go get the ball's rigid body befor the start.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
//Fonction called at the start of the scene.
    private void Start()
    {
        ResetBall();  
    }
//Launch of the ball after its has restarded.
    private void Lancement()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        rb.AddForce(force.normalized * speedBall, ForceMode2D.Impulse) ;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
//Force add to the velocity of the ball when it collide with annything.
        if (collision.gameObject.layer==all)
        {
            Vector3 direction = rb.velocity.normalized;
            rb.AddForce(direction.normalized * speedBall * rb.velocity.magnitude);
        }
//Random directionnal force add to the ball if his way is too vertical or horizontal.
        if (rb.velocity.y < 0.7f && rb.velocity.y > -0.7f && rb.velocity.x < 0.7f && rb.velocity.x > -0.7f)
        {
            Vector3 direction = rb.velocity.normalized;
            direction.x = Random.Range(-5f, 5f);
            direction.y = Random.Range(0f, 5f);
            rb.AddForce(direction.normalized * speedBall * rb.velocity.magnitude);
        }
    }
//Reset position of the principal ball when its has missed.
    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        Invoke(nameof(Lancement), 3f);
    }
//Normalization of the velocity's vector.
    private void FixedUpdate()
    {
     rb.velocity = rb.velocity.normalized * maxSpeed;
    }
}
