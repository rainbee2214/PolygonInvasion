using UnityEngine;
using System.Collections;

public class Laser : Weapon
{
    GameObject[] lasers;
    float rotation1, rotation2, rotation0;

    public float laserDelay = 1f;
    float nextRotation;

    void Start()
    {
        range = 3f;
        delay = 5f;
        power = 1f;
        ConfigureWeapon(this.gameObject.tag, true, range, delay, power);

        rotation1 = 120f;
        rotation2 = 240f;

        lasers = new GameObject[3];
        weaponType = gameObject.tag;
        for (int i = 0; i < 3; i++)
        {
            lasers[i] = Instantiate(Resources.Load("Prefabs/LaserBeam", typeof(GameObject))) as GameObject;
            lasers[i].transform.parent = transform;
            lasers[i].transform.localScale = new Vector2(range, 0.5f);
            lasers[i].transform.position = transform.position;
            lasers[i].SetActive(false);
            lasers[i].name = i + "Laser";
        }
        //		Debug.Log("I am a "+weapon+" and I target enemies: "+target+". My range is "
        //		          + range+", my delay is "+delay+" and my power is "+power+".");
    }

    void FixedUpdate()
    {
        if (turnedOn && Time.time > nextShootTime) Fire();
    }

    public void Fire()
    {
        nextShootTime = Time.time + delay;
    }


    public float GetPower()
    {
        return power;
    }
}
