using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 RandomSpawnPosition = new Vector3(Random.Range(-9f, 10f), 0, Random.Range(-5f, 6f));
            Instantiate(foodPrefab, RandomSpawnPosition, Quaternion.Euler(-90, 0, 0));
        }
    }
}
