using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WeaponSpawner : MonoBehaviour
{
    public static WeaponSpawner spawner;

    public Canvas weaponCanvas;
    GameObject gunPrefab;

    public List<Bullet> bulletPool;
    public int sizeOfBulletPool = 50;

    GameObject bulletPrefab;

    int topBullet;

    public List<Weapon> guns;

    void Awake()
    {
        spawner = this;
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        gunPrefab = Resources.Load<GameObject>("Prefabs/Gun");
        CreateBullets();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShowWeaponCanvas();
        }
    }

    void CreateBullets()
    {
        bulletPool = new List<Bullet>();
        for (int i = 0; i < sizeOfBulletPool; i++)
        {
            bulletPool.Add(Instantiate<GameObject>(bulletPrefab).GetComponent<Bullet>());
            bulletPool[i].gameObject.SetActive(false);
        }
    }

    public void SendTopBullet(Vector2 pos, GameObject target, int gunId)
    {
        bulletPool[topBullet].TurnOn(target,pos, gunId);
        bulletPool[topBullet].gameObject.SetActive(true);
        topBullet++;
        if (topBullet >= bulletPool.Count) topBullet = 0;
    }

    public void ShowWeaponCanvas()
    {
        GameController.controller.Paused = true;
        weaponCanvas.gameObject.SetActive(true);
    }

    public void CreateGun()
    {
        TurnOffWeaponCanvas();

        guns.Add(Instantiate<GameObject>(gunPrefab).GetComponent<Weapon>());
        guns[guns.Count - 1].Setup(guns.Count - 1);

    }

    public void TurnOffWeaponCanvas()
    {
        weaponCanvas.gameObject.SetActive(false);
        GameController.controller.Paused = false;
    }
}
