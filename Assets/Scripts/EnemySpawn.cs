using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > nextSpawn){

        nextSpawn = Time.time + spawnRate;
        randX = Random.Range (-40f,40f);
        whereToSpawn = new Vector2 (randX, transform.position.y);
        Instantiate(enemy,whereToSpawn,Quaternion.identity);

        }

        
        
    }
}
