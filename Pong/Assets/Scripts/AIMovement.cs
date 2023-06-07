using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private float speed;

    private Rigidbody2D ballRigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckBallRigidBody();
        FollowBall();
    }

    private void CheckBallRigidBody()
    {
        if(ballRigidBody == null)
        {
            ballRigidBody = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        }
    }

    private void FollowBall()
    {
        rigidBody.velocity = new Vector2(0, (ballRigidBody.velocity.y)).normalized * speed;
    }

    public void Teleport(float y)
    {
        this.transform.position = new Vector3(
            this.transform.position.x,
            y,
            0);
    }

    public void ChangeRigidBody2D(GameObject rigidBodyGameObject)
    {
        ballRigidBody = rigidBodyGameObject.GetComponent<Rigidbody2D>();
    }
}
