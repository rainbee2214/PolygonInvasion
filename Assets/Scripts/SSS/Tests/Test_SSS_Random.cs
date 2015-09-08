using UnityEngine;
using SSS.Random;

public class Test_SSS_Random : MonoBehaviour
{
    void Start()
    {
        bool alt = false;
        uint min = 0;
        uint max = 0;
        min = RandomAlt.Lehmer_PM(alt);
        max = min;

        for (int i = 0; i < 100; i++)
        {
            if (i % 2 == 0) alt = true;
            else alt = false;

            uint current = RandomAlt.Lehmer_PM(alt);

            if (current < min) min = current;
            else if (current > max) max = current;

            Debug.Log(current);
        }
        Debug.Log("Max: " + max + "\tMin: " + min);
    }
}
