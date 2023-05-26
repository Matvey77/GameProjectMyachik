using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject ssilka;
    private bool close;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        close = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (close == true && transform.position.y < -4f)
        {
            transform.Translate(Vector2.up * Time.deltaTime / 5);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        close = false;
        ssilka.GetComponent<Wall_vbok>().move = true;
        if (transform.position.y > -4.15f)
        {
            transform.Translate(Vector2.down * Time.deltaTime);
            //wall.transform.Translate(Vector2.up * Time.deltaTime);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        ssilka.GetComponent<Wall_vbok>().move = false;
        close = true;
    }
}