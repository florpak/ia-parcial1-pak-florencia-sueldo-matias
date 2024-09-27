using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] GameObject targetBoid;
    [SerializeField] float minDist;

    private void Start()
    {
        GameManager.Instance.food.Add(this);
    }
    void Update()
    {
        foreach (Boid item in GameManager.Instance.agents)
        {
            if (Vector3.Distance(transform.position, item.transform.position) > minDist) continue;
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        GameManager.Instance.food.Remove(this);
    }
}
