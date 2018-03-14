using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComponent : MonoBehaviour {

    public List<Rigidbody> enemiesToSpawn;
    public float spawnRate;
    public int numberOfEnemies;

    public static int enemiesKilled;

    private float lastSpawnTime;
    private int enemiesSpawned;
    
    private float spawnX;
    private float spawnZ;
	
	// Update is called once per frame
	void Update () {
		
        // spawn enemies if appriopriate
        if (enemiesSpawned < numberOfEnemies &&
            lastSpawnTime + spawnRate <= Time.time)
        {
            var enemyToSpawn = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
            spawnX = Random.Range(-4.7f, 4.7f);
            spawnZ = Random.Range(2.8f, 4.7f);

            Instantiate(enemyToSpawn, new Vector3(spawnX, 0f, spawnZ), Quaternion.identity);

            enemiesSpawned++;
            lastSpawnTime = Time.time;
        }

        // if all enemies are dead, level complete
        if (enemiesKilled == numberOfEnemies)
        {
            // display level complete screen


            // detect keypress to go to next scene
        }
	}
}
