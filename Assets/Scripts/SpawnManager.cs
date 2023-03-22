using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject animalPrefab;
    private float spawnRangeX = 14.3f;
    private float spawnRangeZ = 5.5f;
    private float startDelay = 1;
    private float spawnInterval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(SpawnRandomAnimal, startDelay, spawnInterval);
    }
    private void SpawnRandomAnimal()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return;
        Instantiate(animalPrefab, randomPos, animalPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
