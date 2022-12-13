using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    public int ball = 7;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer==ball)
        {
            FindObjectOfType<MainMenu>().Dead();  
        }

    }
}
