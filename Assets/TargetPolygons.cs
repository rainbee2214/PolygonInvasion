using UnityEngine;
using System.Collections;

public class TargetPolygons : MonoBehaviour 
{
	public Vector2 OUT_OF_VIEW;
	public Transform target;
    public float speed;
    
	public bool turnedOn = false;
	public float power = 50f;

	public float delay = 2f;
	float nextShootTime;

	public void TurnOn()
	{
		turnedOn = true;
	}

	public void TurnOff()
	{
		turnedOn = false;
	}

    void Update() {
		if (turnedOn)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.gameObject.GetComponent<PolygonEmitter>().GetFrontPolygon().position, step);
		}
		if (Time.time > nextShootTime) TurnOn();

    }

	public void ResetBullet()
	{
		transform.position = OUT_OF_VIEW;
		TurnOff();
		nextShootTime = Time.time + delay;
	}
}
