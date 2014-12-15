using UnityEngine;
using System.Collections;

public class EndOfLevelArea : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
    }
}
