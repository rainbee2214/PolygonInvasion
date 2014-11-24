using UnityEngine;
using System.Collections;

public class CreateWeapon : MonoBehaviour 
{
	GameObject newWeapon;
	bool pickedUp = false;

    bool PickUp()
    {
        return true;
    }
    bool SetDown()
    {
		newWeapon.gameObject.GetComponent<Weapon>().TurnOn();
        return false;
    }
    void OnMouseDown()
    {

    }

	void Update () 
	{
		if (pickedUp && Input.GetMouseButtonDown(0))
		{
			Debug.Log("Dropping weapon");
			if (pickedUp) pickedUp = SetDown();
		}

		if (gameObject.guiText.HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 mousePosition = ray.origin + ray.direction;

			newWeapon = Instantiate(Resources.Load("Prefabs/"+this.name, typeof(GameObject)), mousePosition, Quaternion.identity) as GameObject;
			pickedUp = true;
		}

		if (pickedUp)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 mousePosition = ray.origin + ray.direction;
			newWeapon.transform.position = mousePosition;
		}

	}
}
