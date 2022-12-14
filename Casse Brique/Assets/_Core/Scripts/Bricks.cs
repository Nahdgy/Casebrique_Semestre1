using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    [SerializeField]
    private Sprite[] newForm;
    private SpriteRenderer baseForm;

    [SerializeField]
    private int nbMaxTouch;
    [SerializeField]
    private int nbTouch;
    [SerializeField]
    private int ball = 7;
    [SerializeField]
    private int ballSp? = 9;
    [SerializeField]
    private int state;
   

//Normal bricks health and death by collision.  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==ball)
        {
            nbTouch++;
        }
        if (collision.gameObject.layer == ballSp?)
        {
            nbTouch++;
        }
        if (nbTouch >= nbMaxTouch)
        {
            Destroy(gameObject);
        }
    }
}
