using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BinSpawner : MonoBehaviour
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

        float screenX = c.bounds.min.x + 2;
        float screenY = c.bounds.min.y + 2; 
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            toSpawn = spawnPool[i];

            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);

            screenX += 4;

        }
    }

}
