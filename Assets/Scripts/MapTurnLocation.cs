using UnityEngine;
using System.Collections;

public class MapTurnLocation : MonoBehaviour
{
    public P.Direction direction = P.Direction.Up;
    public Vector3 offset;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Polygon")
        {
            Debug.Log("Touching polygon");
            other.GetComponent<Polygon>().Move(transform.position+offset, direction);
        }
    }
}
