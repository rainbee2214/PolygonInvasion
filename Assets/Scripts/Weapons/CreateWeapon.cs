using UnityEngine;
using System.Collections;

public class CreateWeapon  : MonoBehaviour
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

    void FixedUpdate() 
	{
		if (pickedUp && Input.GetButtonDown("PlaceWeapon"))
		{
			Debug.Log("Dropping weapon");
			if (pickedUp) pickedUp = SetDown();
		}

        //if (gameObject.GetComponent<GUIText>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Vector3 mousePosition = ray.origin + ray.direction;
        //    mousePosition.z = 0f;
        //    newWeapon = Instantiate(Resources.Load("Prefabs/"+this.name, typeof(GameObject)), mousePosition, Quaternion.identity) as GameObject;
        //    pickedUp = true;
        //    newWeapon.transform.position = new Vector3(newWeapon.transform.position.x, newWeapon.transform.position.y, 0f);
        //}


        //if (gameObject.GetComponent<GUIText>().HitTest(Input.mousePosition) && Input.GetMouseButtonDown(0))
        //{
        //    Pickup(this.name);
        //}
        Debug.Log(pickedUp);

        //    Pickup(this.name);
        //}
        Debug.Log(pickedUp);
		if (pickedUp)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 mousePosition = ray.origin + ray.direction;
            Vector3 mPosition = Input.mousePosition;
            mPosition.z = 10;
            Debug.Log("Picked up..." + mPosition);
			newWeapon.transform.position = Camera.main.ScreenToWorldPoint(mPosition);
		}

	}

    public void Pickup(string title)
    {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 mousePosition = ray.origin + ray.direction;
			mousePosition.z = 0f;
			newWeapon = Instantiate(Resources.Load("Prefabs/"+title, typeof(GameObject)), mousePosition, Quaternion.identity) as GameObject;
			newWeapon.GetComponent<CreateWeapon>().pickedUp = true;
			newWeapon.transform.position = new Vector3(newWeapon.transform.position.x, newWeapon.transform.position.y, 0f);
    }
}
