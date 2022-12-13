using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBrick : MonoBehaviour
{
    [SerializeField]
    private int nbMaxTouch;
    [SerializeField]
    private int nbTouch;
    [SerializeField]
    private int ball = 7;
    [SerializeField]
    private int ballSp� = 9;

    [SerializeField]
    private GameObject powerPrefab;

    [SerializeField]
    private Transform specialPosition;

//Bricks health by collision with the ball. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == ball)
        {
            nbTouch++;
        }
        if (collision.gameObject.layer == ballSp�)
        {
            nbTouch++;
        }

        if (nbTouch >= nbMaxTouch)
        {
            Destroy(gameObject);
            Instantiate(powerPrefab, specialPosition.position, Quaternion.identity);
        }
    }
   

}
