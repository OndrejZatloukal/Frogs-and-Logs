using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPickup : MonoBehaviour {

    [SerializeField]
    private GameObject pickupPrefab;

    private void OnTriggerEnter(Collider other)
    {
        // If the collider Other is tagged with "Player" then...
        if (other.CompareTag("Player"))
        {
            // ...add pick up particles...
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);

            // ...decrement the total amount of flies...
            FlySpawner.totalFlies--;

            // ...update the score...
            ScoreCounter.score++;

            Destroy(gameObject);
        }
    }

}
