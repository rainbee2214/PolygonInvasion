using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndOfLevelArea : MonoBehaviour 
{
    public Slider slider;

    public int health = 100;

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Polygon")
        {
            Polygon p = other.GetComponent<Polygon>();
            Debug.Log(p.speed);
            p.TurnOff();
            health--;
            if (health <= 0)
            {
                health = 0;
                //todo: game over in game controller
            }
            slider.value = health;
        }
    }
}
