using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentArrive : Agent
{
    public Agent enemy;
    // Start is called before the first frame update
    private void Update()   
    {
        if (!HasToUseObstacleAvoidance())
        {
            if(Vector3.Distance(enemy.transform.position, transform.position) < viewRadius )
            {
                AddForce(Flee(GameManager.Instance.enemyAgent));

            }
            else
            {
                AddForce(Arrive(GameManager.Instance.food));
            }
        }
        Move();
    }
}
