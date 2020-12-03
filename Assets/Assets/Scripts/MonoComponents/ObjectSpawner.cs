using Assets.Assets.Scripts.Other;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject objectToSpawn;
    public IFrequency frequency;
    public ISize size;
    public RandomPosition spawningPosition;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            // relative position
            var position = transform.position + (Vector3)spawningPosition.Value();
            // spawn
            GameObject spawnedObject = Instantiate(objectToSpawn, position, Quaternion.identity);
            // scale
            var scale = spawnedObject.transform.localScale;
            spawnedObject.transform.localScale = new Vector3(scale.x * size.Value(), scale.y, scale.z);
            // frequency
            yield return new WaitForSeconds(frequency.value());
        }
    }
}
