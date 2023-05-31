using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;

    private float currentSpeed;

    private GameManager gameManagerScript;
    private SoundManager soundManagerScript;
    private SpriteRenderer spriteRenderer;

    private bool isRed;

    private void Awake()
    {
        isRed = false;
        currentSpeed = speed;
        ResetBallPosition();

        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundManagerScript = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Racket")) // Changes X and gets Y upon hittin racket
        {
            soundManagerScript.PlaySFX(soundManagerScript.bounceSound);
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
            int scoreToAdd = isRed ? 5 : 1;
            GetClass();
            ResetBallPosition();
            gameManagerScript.AddScoreRightPlayer(scoreToAdd);
        }
        else if (collision.gameObject.CompareTag("ScoreTriggerRight"))
        {
            int scoreToAdd = isRed ? 5 : 1;
            GetClass();
            ResetBallPosition();
            gameManagerScript.AddScoreLeftPlayer(scoreToAdd);
        }
    }

    public void ResetBallPosition()
    {
        transform.position = Vector3.zero;
        
        rigidbody.velocity = Vector2.left * currentSpeed;
        if ((UnityEngine.Random.Range(0, 100) <= 50))
        {
            rigidbody.velocity = Vector2.left * currentSpeed;
        }
        else
        {
            rigidbody.velocity = Vector2.right * currentSpeed;
        }
    }

    private void GetClass()
    {
        float randomNumber = UnityEngine.Random.Range(1, 100);

        if(randomNumber <= 80)
        {
            currentSpeed = speed;
            spriteRenderer.color = Color.white;
            isRed = false;
        }
        else if(randomNumber > 80 && randomNumber <= 90) //Fast class (blue)
        {
            currentSpeed = speed * 1.5f;
            spriteRenderer.color = Color.cyan;
            isRed = false;
        }
        else //Red class
        {
            currentSpeed = speed;
            spriteRenderer.color = Color.red;
            isRed = true;
        }
    }
}
