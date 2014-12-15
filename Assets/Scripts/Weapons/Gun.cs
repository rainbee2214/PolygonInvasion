using UnityEngine;
using System.Collections;

public class Gun : Weapon 
{

	void Start () 
	{
		weaponType = gameObject.tag;

		range = 10f;
		delay = 0.5f;
		power = 5f;
		ConfigureWeapon(this.gameObject.tag, true, range, delay, power);
//		Debug.Log("I am a "+weapon+" and I target enemies: "+target+". My range is "
//		          + range+", my delay is "+delay+" and my power is "+power+".");
	}

	void FixedUpdate () 
	{
		if (turnedOn && Time.time > nextShootTime) Fire();
	}

	public void Fire()
	{
        //So yucky. Going to fix soon. Working on more fun things atm :)
		if (GameController.controller.PolygonEmitter.gameObject.GetComponent<PolygonEmitter>().GetFrontPolygon() != null)
		{
			GameController.controller.bulletPool[GameController.controller.frontOfPool].gameObject.transform.position = transform.position;
			GameController.controller.bulletPool[GameController.controller.frontOfPool].gameObject.GetComponent<Bullet>().power = power;
			GameController.controller.bulletPool[GameController.controller.frontOfPool].gameObject.GetComponent<Bullet>().TurnOn();
			GameController.controller.bulletPool[GameController.controller.frontOfPool].gameObject.GetComponent<Bullet>().parentObject = this.gameObject;
			GameController.controller.IncrementFrontOfBulletPool();

			nextShootTime = Time.time + delay;
		}
	}

}
