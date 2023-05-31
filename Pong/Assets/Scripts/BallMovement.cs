using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;

    private GameManager gameManagerScript;

    private void Awake()
    {
        ResetBallPosition();
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Racket")) // Changes X and gets Y upon hittin racket
        {
            rigidbody.velocity = new Vector2(
                    -rigidbody.velocity.x,
                    collision.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (collision.gameObject.CompareTag("Border"))
        {
            rigidbody.velocity = new Vector2(
                rigidbody.velocity.x,
                -rigidbody.velocity.y); // Changes Y upon hiting wall 
        }
        else if (collision.gameObject.CompareTag("ScoreTriggerLeft"))
        {
            ResetBallPosition();
            gameManagerScript.AddScoreLeft();
        }
        else if (collision.gameObject.CompareTag("ScoreTriggerLeft"))
        {
            ResetBallPosition();
            gameManagerScript.AddScoreRight();
        }
    }

    public void ResetBallPosition()
    {
        transform.position = Vector3.zero;
        
        rigidbody.velocity = Vector2.left * speed;
        if ((UnityEngine.Random.Range(0, 100) <= 50))
        {
            rigidbody.velocity = Vector2.left * speed;
        }
        else
        {
            rigidbody.velocity = Vector2.right * speed;
        }
    }
}
