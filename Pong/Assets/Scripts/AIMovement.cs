using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody2D ballRigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        FollowBall();
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
}
