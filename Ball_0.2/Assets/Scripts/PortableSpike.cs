using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortableSpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == BallController2.Instance.gameObject)
        {

            BallController2.Instance.GetDamage();
        }
    }

    // Update is called once per frame

/*    private void Movement()
    {

    }

    void Update()
    {
        
    } */
}
