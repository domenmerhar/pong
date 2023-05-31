using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PongMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField] private float speed;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable()
    {
        rigidBody.velocity = Vector3.up * speed;
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            rigidBody.velocity = Vector3.up * speed; 
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            rigidBody.velocity = Vector3.down * speed; 
        }
    }
}
