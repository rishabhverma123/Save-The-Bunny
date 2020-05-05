using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is applied to Empty Game object , the place from where Enemy will start to fall down
 *
 **/
public class EnemySpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    //creating object of enemy type beacause enemyspwaner object will instatiate enemy object from it.  
    public GameObject enemy;
    public float xPostionLimitSpawn = 2.0f; //to set enemy spawn from diff position within this limit.
    public float spawnRate;

    void Start()
    {
        //SpawnSpike();
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void SpawnSpike()
    {
        //select diff random position to spawn enemy
        float spawn = Random.Range(-xPostionLimitSpawn, xPostionLimitSpawn);   
        Vector2 spawnerPosition = new Vector2(spawn, transform.position.y);

        /*
         * Instatiating enemy object  
         * from transform.postion i.e current postion of enemySpwner game object
         * Quaternion.identity will stop enemy rotation while it is instantiating
         * */
        // Instantiate(enemy, transform.position, Quaternion.identity);

        Instantiate(enemy, spawnerPosition, Quaternion.identity);
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnSpike", 1f, spawnRate);
    }

   public  void StopSpawning()
    {
        CancelInvoke("SpawnSpike");
    }
}
