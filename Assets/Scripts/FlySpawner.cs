using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{

    [SerializeField] private GameObject flyPrefab;

    [SerializeField] private int totalFlyMinimum = 12;

    private float spawnArea = 25f;

    public static int totalFlies;

	// Use this for initialization
	void Start()
    {
        totalFlies = 0;
	}
	
	// Update is called once per frame
	void Update()
    {
        FlySpawn();
    }

    private void FlySpawn()
    {
        // While the total number of flies is less than the minimum...
        while (totalFlies < totalFlyMinimum)
        {
            // ...then increment the total amount of flies...
            totalFlies++;

            //...create a random position for a fly...
            Vector3 flyPosition = CreateNewRandomSpawnPosition();

            // ...and create a new fly.
            Instantiate(flyPrefab, flyPosition, Quaternion.identity);
        }
    }

    private Vector3 CreateNewRandomSpawnPosition()
    {
        float positionX = Random.Range(-spawnArea, spawnArea);
        float positionZ = Random.Range(-spawnArea, spawnArea);

        Vector3 flyPosition = new Vector3(positionX, 2f, positionZ);
        return flyPosition;
    }
}
