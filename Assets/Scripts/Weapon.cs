using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour 
{
	public bool configure;
	public bool turnedOn = false;

	protected string weapon;
	protected bool target;
	protected float range;
	protected float delay;
	protected float power;

	protected float nextShootTime = 4f;

	protected string weaponType;

	public void TurnOn()
	{
		turnedOn = true;
	}

	public void TurnOff()
	{
		turnedOn = false;
	}

	public void ConfigureWeapon(string weapon, bool target, float range = 0f, float delay = 1f, float power = 0f)
	{
		Debug.Log("Configuring weapon.");
		configure = false;
		this.weapon = weapon;
		this.target = target;
		this.range = range;
		this.delay = delay;
		this.power = power;
		nextShootTime = delay;
	}
}
