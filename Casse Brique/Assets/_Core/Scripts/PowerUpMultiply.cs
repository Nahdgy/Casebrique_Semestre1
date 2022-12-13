using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PowerUpMultiply : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer powerRenderer;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private CapsuleCollider2D powerCollider;

    [SerializeField]
    private GameObject ballSp�Prefab;

    [SerializeField]
    private Transform ballSp�Position1;
    [SerializeField]
    private Transform ballSp�Position2;

    private int destroy = 3;
    private int collide = 0;

    //Desactivate and destroy the object "PowerUpMultiply" when it colide whith the player's bar. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == collide)
        {
        Multiply();
        }
        
        if (collision.gameObject.layer == collide)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            powerCollider.enabled = false;
            powerRenderer.enabled = false; 
        }
        if (collision.gameObject.layer == destroy)
        {
            Destroy(gameObject);
        }
    }
    //Instantiate 2 news balls on the stage, at 2 position different.
    private void Multiply()
    {
        Instantiate(ballSp�Prefab, ballSp�Position1.position, Quaternion.identity);
        Instantiate(ballSp�Prefab, ballSp�Position2.position, Quaternion.identity);
    }

   
}
