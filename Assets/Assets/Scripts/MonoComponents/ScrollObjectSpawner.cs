using System.Collections;
using System.Collections.Generic;
using Assets.Assets.Scripts.Other;
using UnityEngine;

public class ScrollObjectSpawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    public ISize HscrollLengthToSpawn;
    public ISize size;
    public RandomPosition spawningPosition;
    public int amountOfFloors; 
    public GameObject endFloor; // when amountOfFloors is reached, endFloor is spawned.

    private Vector3 lastSpawningPosition;
    private float cachedHscrollLengthToSpawn;
    private int amountOfSpawnedFloors;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawningPosition = transform.position;
        cachedHscrollLengthToSpawn = HscrollLengthToSpawn.Value();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > (lastSpawningPosition.y + cachedHscrollLengthToSpawn))
        {
            if (amountOfSpawnedFloors == amountOfFloors)
            {
                Instantiate(endFloor, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Spawn();
                lastSpawningPosition = transform.position;
                cachedHscrollLengthToSpawn = HscrollLengthToSpawn.Value();
                amountOfSpawnedFloors++;
            }

        }
        
    }
    private void Spawn()
    {
        // relative position
        var position = transform.position + (Vector3)spawningPosition.Value();
        // spawn
        GameObject spawnedObject = Instantiate(objectToSpawn, position, Quaternion.identity);
        // scale
        var scale = spawnedObject.transform.localScale;
        spawnedObject.transform.localScale = new Vector3(scale.x * size.Value(), scale.y, scale.z);

    }
}
