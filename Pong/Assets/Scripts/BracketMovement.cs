using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BracketMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField] private float speed;
    [SerializeField] private KeyCode keyInput;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rigidBody.velocity = Vector2.up * speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyInput))
        {
            rigidBody.velocity = Vector2.up * speed;
            speed *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Border"))
        {
            rigidBody.velocity = new Vector2(0, -rigidBody.velocity.y);
        }
    }
}
