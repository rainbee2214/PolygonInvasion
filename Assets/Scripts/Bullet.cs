using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float speed = 1f;

    public int damage = 1;
    public int gunThatSentMe;

    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameController.controller.Paused) return;
        if (target != null)
        {
            //Debug.Log("Sending bullet from " + gunThatSentMe + " to polygon " + target.name);
            if (!target.gameObject.activeInHierarchy)
            {
                //Debug.Log("My target is empty! " + gunThatSentMe);
                if (WeaponSpawner.spawner.guns[gunThatSentMe].polygonsInRange.Count > 0)
                {
                    //Debug.Log("New target " + gunThatSentMe);
                    target = WeaponSpawner.spawner.guns[gunThatSentMe].polygonsInRange[0].gameObject;
                }
                else
                {
                    target = null;
                }
            }
        }
        else
        {
            TurnOff();
        }
    }

    void FixedUpdate()
    {
        if (target != null && target.activeInHierarchy)
        {
            Vector2 newPos = Vector3.MoveTowards(rb2d.position, target.GetComponent<Rigidbody2D>().position, speed * Time.deltaTime);
            rb2d.MovePosition(newPos);
        }
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {
        TurnOff();
    }

    public void TurnOn(GameObject t, Vector2 p, int gunId)
    {
        gunThatSentMe = gunId;
        target = t;
        transform.position = p;
    }

    public void TurnOff()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Polygon p = other.GetComponent<Polygon>();
        if (p != null)
        {
            p.TakeDamage(damage);
            TurnOff();
        }
    }
}
