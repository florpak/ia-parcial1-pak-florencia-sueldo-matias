using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public override void OnEnter(Vector3 target)
    {
        //throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        foreach (GameObject waypoint in player.GetWayPoints())
        {
            while (Vector3.Distance(player.transform.position, waypoint.transform.position) > 0.1f)
            {
                AddForce(Arrive(waypoint));
                player.Move();
            }
        }
        
    }
}
