using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speedBall;
    [SerializeField]
    private float maxSpeed;

    private int all = 0;
    private int desteroy = 3;


//Fonctions called at the start.
    private void Start()
    {
        Lancement();
    }
//Fonction called before the start, on awake.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
//Force add to the velocity of the ball when it collide with annything
        if (collision.gameObject.layer == all)
        {
            Vector3 direction = rb.velocity.normalized;
            rb.AddForce(direction.normalized * speedBall * rb.velocity.magnitude);
        }
//Random directionnal force add to the ball if his way is too vertical or horizontal.

        if (rb.velocity.y < 0.8f && rb.velocity.y > -0.8f && rb.velocity.x < 0.8f && rb.velocity.x > -0.8f)
        {
            Vector3 direction = rb.velocity.normalized;
            direction.x = Random.Range(-5f, 5f);
            direction.y = Random.Range(-5f, 5f);
            rb.AddForce(direction.normalized * speedBall * rb.velocity.magnitude);
        }
//Suppression of the ball if it has missed the bar.
        if(collision.gameObject.layer == desteroy)
        {
            Destroy(gameObject);
        }
    }
//Launch of the ball when it's instantiate.
    private void Lancement()
    {
        Vector2 force = Vector2.zero;
        force.x = 0f;
        force.y = 0.3f;
        rb.AddForce(force.normalized * speedBall, ForceMode2D.Impulse);
    }
//Normalization of the velocity's vector.
    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * maxSpeed;
    }
}
