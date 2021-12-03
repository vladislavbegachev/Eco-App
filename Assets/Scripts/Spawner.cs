using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public float timer = 0.1f; 
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    public bool hasSpawned = false;


    void Start()
    {
        spawnObjects();
    }

    void Update()
    {

    }

    public void spawnObjects()
    {
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();
        IEnumerable<int> indexes1 = Enumerable.Range(0, spawnPool.Count);
        List<int> indexes = indexes1.ToList();
        int toSpawnIndex;

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            screenX = Random.Range(c.bounds.min.x + 8, c.bounds.min.x + 12);
            screenY = Random.Range(c.bounds.min.y + 4, c.bounds.min.y + 8);

            pos = new Vector2(screenX, screenY);

            toSpawnIndex = indexes[Random.Range(0, indexes.Count)];
            while (toSpawnIndex == -1)
            {
                toSpawnIndex = indexes[Random.Range(0, indexes.Count)];
            }

            toSpawn = spawnPool[toSpawnIndex];
            indexes[toSpawnIndex] = -1;
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

        }
        hasSpawned = true;
    }
}