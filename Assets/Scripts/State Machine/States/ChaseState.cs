using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if (!player.HasToUseObstacleAvoidance())
        {
            player.SubstractStamina(1 * Time.deltaTime);
            if (player.GetStamina() <= 0)
            {
                fsm.ChangeState(PlayerState.Idle);
            }
            if (player.GetTargetAgent() != null)
            {
                AddForce(player.Pursuit(player.GetTargetAgent()) * 3);
                player.Move();
            }
            else
            {
                fsm.ChangeState(PlayerState.Patrol);
            }
        }
        else
        {
            player.Move();
        }

    }
}
