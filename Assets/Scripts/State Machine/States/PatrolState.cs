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
        if (Vector3.Distance(player.GetWayPoints()[player.GetWayPointNumber()].transform.position, player.transform.position)>0.1f)
        {
            AddForce(Seek(player.GetWayPoints()[player.GetWayPointNumber()].transform.position, player.GetMaxSpeed()));
            player.Move();
        }
        else 
        {
            if (player.GetWayPoints().Count-1 > player.GetWayPointNumber())
            {
                player.SetWayPointNumber(player.GetWayPointNumber() +1);
            }
            else
            {
                player.SetWayPointNumber(0);
            }
        }
    }
}
