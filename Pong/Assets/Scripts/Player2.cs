using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player2 : MonoBehaviour
{
   public Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.getPause())
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            if (Input.GetKey("up"))
            {
                rigidbody2D.MovePosition(new Vector2(0, rigidbody2D.position.y + 0.2f));
            }
            else if (Input.GetKey("down"))
            {
                rigidbody2D.MovePosition(new Vector2(0, rigidbody2D.position.y - 0.2f));
            }
        }
    }
}
