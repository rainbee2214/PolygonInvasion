using UnityEngine;
using System.Collections;

public class Bomb : Weapon 
{
	
	void Start () 
	{
		weaponType = gameObject.tag;

		range = 2f;
		delay = 10f;
		power = 10f;
		ConfigureWeapon(this.gameObject.tag, true, range, delay, power);
//		Debug.Log("I am a "+weapon+" and I target enemies: "+target+". My range is "
//		          + range+", my delay is "+delay+" and my power is "+power+".");
	}
	
	void Update () 
	{
		if (turnedOn && Time.time > nextShootTime) Fire();
	}

	public void Fire()
	{
		if (GameController.controller.PolygonEmitter.gameObject.GetComponent<PolygonEmitter>().GetFrontPolygon() != null)
		{			
			nextShootTime = Time.time + delay;
		}
	}
}
