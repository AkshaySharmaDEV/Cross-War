using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public static Shooting instance;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletCapacity;
    public float bulletForce = 20f;


    int i;
    List<GameObject> BulletNo;
    
    // Update is called once per frame
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        BulletNo = new List<GameObject>();
    }
    public void fire()
    {
        Shoot();

    }
    void Shoot()
    {
        //Spawn objects on screen because there's no object on screen
        if (BulletNo.Count < bulletCapacity)
        {
            SpawnObj(bulletPrefab, i);
            i++;
        }
        //Activate the inactive objects which were already created
        if (BulletNo.Count == bulletCapacity)
        {
            for (int i = 0; i < BulletNo.Count; i++)
            {
                if (!BulletNo[i].activeSelf)
                {
                    BulletNo[i].transform.position = transform.position; //Position of object back to spawn site
                    BulletNo[i].SetActive(true); //Setting it true means it's respawned
                    BulletNo[i].GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                    break;
                }
            }
        }

    }


    void SpawnObj(GameObject spawnObject,int i)
    {
        BulletNo.Add(Instantiate(spawnObject, firePoint.position, firePoint.rotation));
        BulletNo[i].GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }



    
    
}