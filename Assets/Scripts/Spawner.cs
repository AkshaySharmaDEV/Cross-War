using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    public GameObject SpawnObject;
    List<GameObject> SpawnObjectNo; //This to track the object created
    public float SpawnTime;
    public int SpawnLimit = 15;//this sets the limit to objects instantiated
    int i;
    float timer;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Spawn objects on screen because there's no object on screen
        if (timer > SpawnTime && SpawnObjectNo.Capacity < SpawnLimit)
        {
            SpawnGameObject(SpawnObject, i);
            i++;
        }
        //Activate the inactive objects which were already created
        if (timer > SpawnTime && SpawnObjectNo.Capacity==SpawnLimit)
        {
            for (int i = 0; i < SpawnObjectNo.Capacity; i++)
            {
                if (!SpawnObjectNo[i].activeSelf)
                {
                    SpawnObjectNo[i].transform.position = transform.position; //Position of object back to spawn site
                    SpawnObjectNo[i].SetActive(true); //Setting it true means it's respawned
                    timer = 0; //Setting timer to zero means it'll run only after it again exceeds spawntime
                    break;
                }
            }
        }

    }

   void SpawnGameObject(GameObject bot,int i)
    {
        SpawnObjectNo[i] = Instantiate(bot, transform.position, Quaternion.identity);
    }
}
