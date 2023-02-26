using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class BallBehavior : MonoBehaviour
{
    public float speedx = 0.07f;
    public float speedy = 0.05f;
    public float incrementx = 0.005f;
    private int direction;
    public Text P1;
    public Text P2;
    public Text goal;
    private int p1;
    private int p2;
    public AudioSource pong;
    public AudioSource score;
    public Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        p1 = 0;
        p2 = 0;
        P1.text = p1.ToString();
        P2.text = p2.ToString();
        goal.text = "";
        
        transform.position = new Vector3(0, 0, 0);
        speedx = 0.07f;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pause.getPause())
        {
            moving(direction);
        }
    }


    void moving(int lastWin)
    {
        rigidbody2D.MovePosition(new Vector2(rigidbody2D.position.x + (speedx*direction),
            (rigidbody2D.position.y + speedy)));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "wall")
        {
            Debug.Log("Hit a wall");
            speedy = -speedy;
        }
        
        else if(collision.collider.tag=="Player")
        {
            playerCollision(collision);
            Debug.Log("going back");
            direction = -direction;
            speedx += incrementx;
            pong.Play();
        }
        
        else
        {
            Scoring(direction);
        }
    }
    

    void Scoring(int player)
    {
        score.Play();
        rigidbody2D.isKinematic = true;
        goal.text = "GOAL!";
        if (player == 1)
        {
            p1++;
            P1.text = p1.ToString();
        }
        else
        {
            p2++;
            P2.text = p2.ToString();
        }

        StartCoroutine(Delay());
        rigidbody2D.isKinematic = false;
    }

    void playerCollision(Collision2D collision2D)
    {
        float y, yb= transform.position.y;;
        if (direction == 1)
        {
            y = FindObjectOfType<Player2>().transform.position.y;
            if (y<=yb)
            {
                if (speedy > 0)
                    speedy += 0.04f;
                else
                    speedy = speedy*0.5f +0.04f;
            }else if (y > yb)
            {
                if (speedy < 0)
                    speedy -= 0.04f;
                else
                    speedy = speedy * 0.5f - 0.04f;
            }
            else
            {
                speedy = 0;
            }
        }
        else
        {
            y = FindObjectOfType<Player1>().transform.position.y;
            if (y<=yb)
            {
                if (speedy > 0)
                    speedy += 0.04f;
                else
                    speedy = speedy*0.5f +0.04f;
            }else if (y > yb)
            {
                if (speedy < 0)
                    speedy -= 0.04f;
                else
                    speedy = speedy * 0.5f - 0.04f;
            }
            else
            {
                speedy = 0;
            }
        }
    }
    void resetBall()
    {
        transform.position = new Vector3(0, 0, 0);
        goal.text = "";
        speedx = 0.07f;
        speedy = 0.05f;
        direction = -direction;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        resetBall();
    }
}
