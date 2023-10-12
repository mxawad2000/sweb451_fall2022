using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject entityToSpawn;

    // An instance of the ScriptableObject defined above.
    public SpawnManagerScriptableObject spawnManagerValues;

    // This will be appended to the name of the created entities and increment when each is created.
    int instanceNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEntities();
    }


    void SpawnEntities()
    {
        int currentSpawnPointIndex = 0;
        spawnManagerValues.spawnPoints = new Vector3[spawnManagerValues.numberOfPrefabsToCreate];
        for (int i = 0; i < spawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(-5, 5);
            spawnManagerValues.spawnPoints[currentSpawnPointIndex] = new Vector3(x,y,0);   
            // Creates an instance of the prefab at the current spawn point.
            GameObject currentEntity = Instantiate(entityToSpawn, spawnManagerValues.spawnPoints[currentSpawnPointIndex], Quaternion.identity);
            currentEntity.GetComponent<BulletScript>().setTrajectory(spawnManagerValues.spawnPoints[currentSpawnPointIndex],i%4);
            // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
            currentEntity.name = spawnManagerValues.prefabName + instanceNumber;
            // Moves to the next spawn point index. If it goes out of range, it wraps back to the start.
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnManagerValues.spawnPoints.Length;
            instanceNumber++;
        }
    }
    float time = 0;
    int secs = 0;
    void Update()
    {
        time += Time.deltaTime;
        if ((int)time > secs)
        {
            secs = (int)time;
        }
        else return;
        for (int i = 0; i < spawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            float x = Random.Range(-10, 10);
            float y = Random.Range(-5, 5);
            //spawnManagerValues.spawnPoints[i] = new Vector3(x, y, 0);
            GameObject go = GameObject.Find("Mamoun" + (i+1));
            go.GetComponent<BulletScript>().SetPosition(new Vector3(x, y, 0));
            
        }
    }

}
