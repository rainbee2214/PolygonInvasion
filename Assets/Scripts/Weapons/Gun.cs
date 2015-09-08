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

	}

}
