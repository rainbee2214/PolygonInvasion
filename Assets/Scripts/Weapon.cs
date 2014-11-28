using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	public bool configure;
	public bool turnedOn = false;

	protected float baseLineRange;
	protected float baseLineDelay;
	protected float baseLinePower;

	protected string weapon;
	protected bool target;
	protected float range;
	protected float delay;
	protected float power;

	protected float nextShootTime = 4f;

	protected string weaponType;

	protected GameObject laser;

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
		weaponType = gameObject.tag;
		switch(weaponType)
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
			laser = Instantiate(Resources.Load("Laser", typeof(GameObject))) as GameObject;
			laser.SetActive(false);
			baseLineRange = 5f;
			baseLineDelay = 1f;
			baseLinePower = 1f;
			break;
		}
		case "Bomb":
		{
	
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
		if (turnedOn && Time.time > nextShootTime) Fire();
	}

	public void Fire()
	{
		if (GameController.controller.PolygonEmitter.gameObject.GetComponent<PolygonEmitter>().GetFrontPolygon() != null)
		{
			Debug.Log(weaponType+" firing");
			switch (weaponType)
			{
			case "Gun": case "gun":
			{
				GameController.controller.bulletPool[GameController.controller.frontOfPool].gameObject.transform.position = transform.position;
				GameController.controller.bulletPool[GameController.controller.frontOfPool].gameObject.GetComponent<Bullet>().TurnOn();
				GameController.controller.bulletPool[GameController.controller.frontOfPool].gameObject.GetComponent<Bullet>().parentObject = this.gameObject;
				GameController.controller.IncrementFrontOfBulletPool();
				break;
			}
			case "Laser": case "laser":
			{
				break;
			}
			case "Bomb": case "bomb":
			{
				break;
			}
			}
			nextShootTime = Time.time + delay;
		}
	}

	public void ConfigureWeapon(string weapon, bool target, float range = 0f, float delay = 1f, float power = 0f)
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
