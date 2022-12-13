using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PowerUpGrow : MonoBehaviour
{
    [SerializeField]
    private GameObject petit;
    [SerializeField]
    private GameObject grand;

    [SerializeField]
    private SpriteRenderer power;

    [SerializeField]
    private float powerTime;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private CapsuleCollider2D powerCollider;

    private int destroy = 3;
    private int collide = 0;

//The power activation for enlarge the bar, if it colide with.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==collide)
        {
            StartCoroutine(Spriteactive());
            rb.bodyType = RigidbodyType2D.Kinematic;
            powerCollider.enabled = false;
            power.enabled = false;
        }
//Suppression of the power up if it has missed.

        if (collision.gameObject.layer==destroy)
        {
            Destroy(gameObject);
        }
    }
//Timer for the power up's duration.
    private IEnumerator Spriteactive()
    {
        petit.SetActive(false);
        grand.SetActive(true);
        yield return new WaitForSeconds(powerTime);
        petit.SetActive(true);
        grand.SetActive(false);
        Destroy(gameObject);
    }
}
