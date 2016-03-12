using UnityEngine;
using System.Collections;

public class Polygon : MonoBehaviour
{
    Sprite currentSprite;
    Rigidbody2D rb2d;
    SpriteRenderer sr;

    Vector2 velocity, lastVelocity;
    public float speed = 10f;
    public float angularSpeed = 2f;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public bool move, stop;
    public P.Direction dir = P.Direction.Down;
    void Update()
    {
        if (GameController.controller.paused)
        {
            //TODO: unpause the shapes: something like this: if the game is paused, velocity = 0, use a trigger bool to set velocity back to dir when the game unpauses
            // if (!paused && triggerBool): set triggerBool = true when paused = true
            //I think, I'm tired and it's late.
            rb2d.velocity = Vector2.zero;
            return;
        }

        if (move)
        {
            move = false;
            Move(transform.position, dir);
        }
        if (stop)

        {
            stop = false;
            Stop();
        }

        rb2d.angularVelocity = angularSpeed;
    }

    public void Send(Sprite polygonSprite, Color color, Vector2 startPosition, P.Direction dir)
    {
        currentSprite = polygonSprite;
        sr.sprite = currentSprite;
        sr.color = color;
        Move(startPosition, dir);
    }
    public void Move(Vector2 startPosition, P.Direction dir)
    {
        transform.position = startPosition;
        switch (dir)
        {
            case P.Direction.Up:
                velocity = Vector2.up;
                break;
            case P.Direction.Down:
                velocity = Vector2.down;
                break;
            case P.Direction.Left:
                velocity = Vector2.left;
                break;
            case P.Direction.Right:
                velocity = Vector2.right;
                break;
        }

        rb2d.velocity = velocity * speed;
    }

    public void Stop()
    {
        lastVelocity = rb2d.velocity;
        rb2d.velocity = Vector2.zero;
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
