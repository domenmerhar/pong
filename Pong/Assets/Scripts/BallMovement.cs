using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private TrailRenderer trailRenderer;
    private AIMovement aIMovementScript;
    [SerializeField] private BallSpawner ballSpawnerScript;

    private GameManager gameManagerScript;
    private SoundManager soundManagerScript;
    private SpriteRenderer spriteRenderer;

    private float currentSpeed;

    private bool isHeavyClass;

    Color purple;
    Color green;

    private void Awake()
    {
        isHeavyClass = false;
        currentSpeed = speed;
        ResetBallPosition();

        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundManagerScript = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        aIMovementScript = GameObject.Find("RacketAI").GetComponent<AIMovement>();
        ballSpawnerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<BallSpawner>();

        purple = new Color32(128, 0, 255, 255);
        green = new Color32(128, 255, 0, 255);

        GetClass();
        ChooseDirection();
    }

    private void Start()
    {
        aIMovementScript.Teleport(this.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Racket")) // Changes X and gets Y upon hittin racket
        {
            soundManagerScript.PlaySFX(soundManagerScript.bounceSound, soundManagerScript.bounceSoundVolume);
            rigidbody.velocity = new Vector2(
                    -rigidbody.velocity.x * 1.1f,
                    collision.GetComponent<Rigidbody2D>().velocity.y);
            trailRenderer.endColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
        }
        else if (collision.gameObject.CompareTag("Border"))
        {
            rigidbody.velocity = new Vector2(
                rigidbody.velocity.x,
                -rigidbody.velocity.y); // Changes Y upon hiting wall 
        }
        else if (collision.gameObject.CompareTag("ScoreTriggerLeft"))
        {
            int scoreToAdd = isHeavyClass ? 5 : 1;
            gameManagerScript.AddScoreRightPlayer(scoreToAdd);
            soundManagerScript.PlaySFX(soundManagerScript.scoreSound, soundManagerScript.scoreSoundVolume);
            ballSpawnerScript.SpawnBall();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("ScoreTriggerRight"))
        {
            int scoreToAdd = isHeavyClass ? 5 : 1;
            gameManagerScript.AddScoreLeftPlayer(scoreToAdd);
            soundManagerScript.PlaySFX(soundManagerScript.scoreSound, soundManagerScript.scoreSoundVolume);
            ballSpawnerScript.SpawnBall();
            Destroy(gameObject);
        }
    }

    public void ResetBallPosition()
    {
        transform.position = new Vector3(
            0f,
            UnityEngine.Random.Range(-4.6f, 4.6f),
            0); //Teleports ball
        

        rigidbody.velocity = Vector2.left * speed;
        if ((UnityEngine.Random.Range(0, 100) <= 50))
        {
            rigidbody.velocity = Vector2.left * currentSpeed;
        }
        else
        {
            rigidbody.velocity = Vector2.left * currentSpeed;
        }
    }

    private void ChooseDirection()
    {
        rigidbody.velocity = Vector2.left * speed;
        if ((UnityEngine.Random.Range(0, 100) <= 50))
        {
            rigidbody.velocity = Vector2.left * currentSpeed;
        }
        else
        {
            rigidbody.velocity = Vector2.left * currentSpeed;
        }
    }

    private void GetClass()
    {
        float randomNumber = UnityEngine.Random.Range(1, 100);

        if (randomNumber <= 80)
        {
            currentSpeed = speed;
            spriteRenderer.color = Color.white;
            isHeavyClass = false;
        }
        else if (randomNumber > 80 && randomNumber <= 90) //Fast class (green)
        {
            currentSpeed = speed * 1.5f;
            spriteRenderer.color = green; 
            isHeavyClass = false;
        }
        else //Heavy Class (yellow)
        {
            currentSpeed = speed;
            spriteRenderer.color = Color.yellow;
            isHeavyClass = true;
        }
    }
}
