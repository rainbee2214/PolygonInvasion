using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WeaponType
{
    Gun,
    Laser
}

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;
    public List<Polygon> polygonsInRange;

   public float shootDelay = 1f;
    float lastShootTime;

    public int gunID;
    public bool moving = true;

    void Awake()
    {

    }
    public void Setup(int id)
    {
        gunID = id;
    }

    void Update()
    {
        if (moving)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            if (Input.GetButtonDown("FireGun") && weaponType == WeaponType.Gun)
            {
                Debug.Log("Fire gun");
                Fire();
            }

            if (polygonsInRange.Count > 1 && Time.time > lastShootTime)
            {
                Debug.Log("Fire gun");
                Fire();
            }
        }
    }

    public void Fire()
    {
        if (polygonsInRange.Count > 0)
        {
            WeaponSpawner.spawner.SendTopBullet(transform.position, polygonsInRange[0].gameObject, gunID);
            lastShootTime = Time.time + shootDelay;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Polygon p = other.GetComponent<Polygon>();
        if (p != null)
        {
            polygonsInRange.Add(p);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Polygon p = other.GetComponent<Polygon>();
        if (p != null)
        {
            polygonsInRange.Remove(p);
        }
    }

    void OnMouseDown()
    {
        moving = false;
    }
}
