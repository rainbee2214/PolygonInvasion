using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponSpawner : MonoBehaviour
{
    public Canvas weaponCanvas;

	void Update ()
    {
	    if (Input.GetMouseButtonDown(1))
        {
            weaponCanvas.gameObject.SetActive(true);
        }
	}
}
