using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racketHandler : MonoBehaviour
{

    public float yBound = 3.0f;
    public float speed = 10.0f;
    public string axis = "Vertical";

    // Start is called before the first frame update
   

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

}
