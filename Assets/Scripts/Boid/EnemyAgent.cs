using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : Agent
{
    [SerializeField]
    protected Agent targetAgent;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        size = 1f;
        GameManager.Instance.enemyAgent.Add(this);
    }
    private void Update()
    {
        /*if (!HasToUseObstacleAvoidance())
        {
            AddForce(Pursuit());
        }
        Move();*/
    }
}
