using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;


    void Start()
    {
        spawnObjects();
    }


    public void spawnObjects()
    {
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            toSpawn = spawnPool[Random.Range(0, spawnPool.Count)];

            screenX = Random.Range(c.bounds.min.x + 8, c.bounds.min.x + 12);
            screenY = Random.Range(c.bounds.min.y + 4, c.bounds.min.y + 8);

            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
}