using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public override void OnEnter(Vector3 target)
    {
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (player.GetStamina() < 100)
        {
            player.AddStamina( 1 * Time.deltaTime);
        }
        else
        {
            fsm.ChangeState(PlayerState.Patrol, player.GetWayPoints()[0].transform.position);
        }
    }

    /*IEnumerable recoverStamina()
    {
        yield return new WaitForSecondsRealTime(0.1f);
    }*/

}
