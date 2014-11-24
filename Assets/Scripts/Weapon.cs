using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	public bool configure;
	public bool turnedOn = false;

	float baseLineRange;
	float baseLineDelay;
	float baseLinePower;

	string weapon;
	bool target;
	float range;
	float delay;
	float power;

	float nextShootTime;

	public void TurnOn()
	{
		turnedOn = true;
	}

	public void TurnOff()
	{
		turnedOn = false;
	}

	void SetBaseLine()
	{
		switch(gameObject.tag)
		{
		case "Gun":
		{
			baseLineRange = 10f;
			baseLineDelay = 0.1f;
			baseLinePower = 1f;
			break;
		}
		case "Laser":
		{
			baseLineRange = 5f;
			baseLineDelay = 1f;
			baseLinePower = 1f;
			break;
		}
		case "Bomb":
		{
			baseLineRange = 2f;
			baseLineDelay = 10f;
			baseLinePower = 10f;
			break;
		}
		default:break;
		}
		range = baseLineRange;
		delay = baseLineDelay;
		power = baseLinePower;
	}

	void Start () 
	{
		SetBaseLine();
		ConfigureWeapon(this.gameObject.tag, true);
		Debug.Log("I am a "+weapon+" and I target enemies: "+target+". My range is "
		          + range+", my frequency is "+delay+" and my power is "+power+".");
	}

	void Update () 
	{
		if (turnedOn) Fire();
	}

	public void Fire()
	{
		if (Time.time > nextShootTime)
		{
			//Fire weapon
			Debug.Log("Shooting " + this.name);
			nextShootTime = Time.time + delay;
		}
	}

	public void ConfigureWeapon(string weapon, bool target, float range = 0f, float delay = 0f, float power = 0f)
	{
		configure = false;
		this.weapon = weapon;
		this.target = target;
		this.range += range;
		this.delay += delay;
		this.power += power;
		nextShootTime = delay;
	}
}
