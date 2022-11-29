using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barre : MonoBehaviour
{

    [SerializeField]
    float Speed;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Vector3 velocity = Vector3.zero;

    private void Mouvement(float _horizontalMouvement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMouvement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
    private void Update()
    {
      float horizontalMouvement = Input.GetAxis("Mouse X") * Speed;

      Mouvement(horizontalMouvement);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
