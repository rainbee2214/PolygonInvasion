using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    public string level = "Menu";
    public bool clickToLoad = true;

    void Update()
    {
        if (clickToLoad && Input.GetButtonDown("LoadLevel")) LoadLevel(level);
    }

    public void LoadLevel(string l)
    {
        Application.LoadLevel(l);
    }
}