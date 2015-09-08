using UnityEngine;
using System.Collections;

public class EndOfLevelArea : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Polygon")
        {
            other.GetComponent<Polygon>().TurnOff();
        }
    }
}
