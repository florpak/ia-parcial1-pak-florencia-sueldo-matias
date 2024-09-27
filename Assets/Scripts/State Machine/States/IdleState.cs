using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

        player.AddStamina( 20 * Time.deltaTime);
        if(player.GetStamina() > 100) 
        { 
            fsm.ChangeState(PlayerState.Patrol);
        }
    }

    /*IEnumerable recoverStamina()
    {
        yield return new WaitForSecondsRealTime(0.1f);
    }*/

}
