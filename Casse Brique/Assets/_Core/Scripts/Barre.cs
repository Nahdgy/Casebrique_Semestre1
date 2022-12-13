using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barre : MonoBehaviour
{

    [SerializeField]
    float Speed;
    [SerializeField]
    Rigidbody2D rb;
  
    Vector3 velocity = Vector3.zero;
    
//Horizontal mouvement of the bar.
    private void Mouvement(float _horizontalMouvement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMouvement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
//Input used for the bar deplacement.
    private void Update()
    {
      float horizontalMouvement = Input.GetAxis("Horizontal") * Speed;

      Mouvement(horizontalMouvement);
    }
//Go get the ridgid body on awake.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
//Reste the posion of the bar.
    public void ResetBarre()
    {
        transform.position = new Vector2(0f, transform.position.y);
        rb.velocity = Vector2.zero;

    }
}
