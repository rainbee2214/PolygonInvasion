using UnityEngine;
using System.Collections;

public enum WeaponType
{
    Gun,
    Laser
}

public class Weapon : MonoBehaviour
{
    public WeaponType weaponType;

    void Awake()
    {

    }
}
