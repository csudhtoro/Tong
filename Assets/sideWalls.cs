using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideWalls : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Tennis_Ball")
        {
            string wallName = transform.name;
            gameManager.Score(wallName);
            collision.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
