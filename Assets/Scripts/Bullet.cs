using UnityEngine;
using System.Collections;

public class Bullet: MonoBehaviour 
{
	public Vector2 OUT_OF_VIEW;
	public Transform target;
    public float speed;
    
	public bool turnedOn = false;
	public float power = 50f;

	public float delay = 2f;
	float nextShootTime;

	public GameObject parentObject;

	public void TurnOn()
	{
		turnedOn = true;
	}

	public void TurnOff()
	{
		turnedOn = false;
	}

    void Update() 
	{

		if (turnedOn)
		{
			float step = speed * Time.deltaTime;
			if (GameController.controller.PolygonEmitter
			    .GetComponent<PolygonEmitter>().GetFrontPolygon() != null)
					transform.position = Vector3.MoveTowards(transform.position, 
			                                         GameController.controller.PolygonEmitter
			                                         .GetComponent<PolygonEmitter>().GetFrontPolygon().position, 
			                                         step);
		}

    }

	public void SetLocation(Transform target)
	{
		transform.position = target.position;
	}

	public void ResetBullet()
	{
		transform.position = parentObject.transform.position;
		TurnOff();
		nextShootTime = Time.time + delay;
	}

}
