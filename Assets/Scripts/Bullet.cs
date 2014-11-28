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

	Transform currentTarget;

	public void TurnOn()
	{
		turnedOn = true;
	}

	public void TurnOff()
	{
		turnedOn = false;
	}

    void Update() {

		if (currentTarget != target.gameObject.GetComponent<PolygonEmitter>().GetFrontPolygon())
			currentTarget = target.gameObject.GetComponent<PolygonEmitter>().GetFrontPolygon();
		if (turnedOn)
		{
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);
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
