using UnityEngine;
using System.Collections;

public class Laser : Weapon 
{
	GameObject[] lasers;
	float rotation1, rotation2, rotation0;

	public float laserDelay = 1f;
	float nextRotation;

	void Start () 
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
			lasers[i].name = i+"Laser";
		}
//		Debug.Log("I am a "+weapon+" and I target enemies: "+target+". My range is "
//		          + range+", my delay is "+delay+" and my power is "+power+".");
	}
	
	void Update () 
	{
		if (turnedOn && Time.time > nextShootTime) Fire();
		if (turnedOn && Time.time > nextRotation) SpinLasers();
		if (!turnedOn) 
		{
			for (int i = 0; i < 3; i++)
			{
				lasers[i].SetActive(false);
			}
		}
	}

	public void Fire()
	{
		if (GameController.controller.PolygonEmitter.gameObject.GetComponent<PolygonEmitter>().GetFrontPolygon() != null)
		{
			nextShootTime = Time.time + delay;
		}
	}

	void SpinLasers()
	{
		for (int i = 0; i < 3; i++)
		{
			lasers[i].SetActive(true);
		}

		lasers[0].transform.rotation = Quaternion.Euler(0f,0f,rotation0);
		lasers[1].transform.rotation = Quaternion.Euler(0f,0f,rotation1);
		lasers[2].transform.rotation = Quaternion.Euler(0f,0f,rotation2);

		rotation0++;
		if (rotation0 >= 360f) rotation0 = 0f;
		rotation1++;
		if (rotation1 >= 360f) rotation1 = 0f;
		rotation2++;
		if (rotation2 >= 360f) rotation2 = 0f;

		nextRotation = Time.time + laserDelay;
	}

	public float GetPower()
	{
		return power;
	}
}
