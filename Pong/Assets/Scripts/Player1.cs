using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    private float movement = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.getPause())
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            if (Input.GetKey("w"))
            {
                rigidbody2D.MovePosition(new Vector2(0, rigidbody2D.position.y + movement));
            }
            else if (Input.GetKey("s"))
            {
                rigidbody2D.MovePosition(new Vector2(0, rigidbody2D.position.y - movement));
            }
        }
    }
    
}
