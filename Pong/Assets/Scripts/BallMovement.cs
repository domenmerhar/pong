using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float speed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        if ((Random.Range(0, 100) <= 50))
        {
            rigidbody.velocity = Vector3.left * speed;
        }
        else
        {
            rigidbody.velocity = Vector3.right * speed;      
        } 
    }
    
}
