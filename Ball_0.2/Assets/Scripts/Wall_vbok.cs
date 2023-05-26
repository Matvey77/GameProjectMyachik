using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_vbok : MonoBehaviour
{
    public bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move == false && transform.position.x > 2)
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        else if (move == true && transform.position.x < 4)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }

    }
}