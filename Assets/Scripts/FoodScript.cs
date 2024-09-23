using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] GameObject targetBoid;
    [SerializeField] float minDist;

    void Update()
    {
        Transform target = targetBoid.transform;
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= minDist)
        {
            Destroy(this.gameObject);
        }
    }
}
