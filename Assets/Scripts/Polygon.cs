using UnityEngine;
using System.Collections;

[System.Serializable]
public class Polygon : MonoBehaviour
{
    Sprite currentSprite;
    Rigidbody2D rb2d;
    SpriteRenderer sr;

    Vector2 velocity, lastVelocity;
    public float speed = 10f;
    public float angularSpeed = 2f;

    public int health = 1;
    int maxHealth = 1;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public bool move, stop;
    public P.Direction dir = P.Direction.Down;

    void Update()
    {
        if (GameController.controller.Paused)
        {
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

    public void Send(Sprite polygonSprite, Color color, Vector2 startPosition, P.Direction d)
    {
        currentSprite = polygonSprite;
        sr.sprite = currentSprite;
        sr.color = color;
        Move(startPosition, d);
    }

    //Send the polygon where it was already going
    public void Move()
    {
        Move(transform.position, dir);
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
        this.dir = dir;
        rb2d.velocity = velocity * speed;
    }

    public void Stop()
    {
        lastVelocity = rb2d.velocity;
        rb2d.velocity = Vector2.zero;
    }

    public void TurnOff()
    {
        for (int i = 0; i < WeaponSpawner.spawner.guns.Count; i++)
        {
            if (WeaponSpawner.spawner.guns[i].polygonsInRange.Contains(this))
            {
                WeaponSpawner.spawner.guns[i].polygonsInRange.Remove(this);
                //break;
            }
        }
        gameObject.SetActive(false);
        health = maxHealth;
    }

    public void TakeDamage(int damage = 1)
    {
        health -= damage;
        if (health <= 0)
        {
            TurnOff();
        }
    }
}
