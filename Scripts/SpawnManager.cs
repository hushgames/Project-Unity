using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    private float spawnRangeX = 7;
    private float spawnPosZ = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            int animalIndex = Random.Range(0, carPrefabs.Length);

            Vector3 randomSpawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnPosZ), 0.4f, 12);
            Instantiate(carPrefabs[animalIndex], randomSpawnPosition, carPrefabs[animalIndex].transform.rotation);
        }
    }
}

