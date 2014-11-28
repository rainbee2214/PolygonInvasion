using UnityEngine;
using System.Collections;

public class Laser : Weapon 
{
	
	void Start () 
	{
		laser = Instantiate(Resources.Load("Laser", typeof(GameObject))) as GameObject;
		laser.SetActive(false);
		baseLineRange = 5f;
		baseLineDelay = 1f;
		baseLinePower = 1f;
	}
	
	void Update () 
	{
		
	}
}
