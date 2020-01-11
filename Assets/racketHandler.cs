using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketHandler : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float yBound = 3.0f;
    public float speed = 10.0f;
    public string axis = "Vertical";


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;   

        var pos = transform.position;
        if (pos.y > yBound) pos.y = yBound;
        else if (pos.y < -yBound) pos.y = -yBound;

        transform.position = pos;

    }

    void ResetRacket()
    {
        if (rb2d.name == "Player_Tennis_Racket")
        {
            rb2d.velocity = Vector2.zero;
            rb2d.position = new Vector2(-7.85f, 0);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
            rb2d.position = new Vector2(7.85f, 0);
        }
    }

}
