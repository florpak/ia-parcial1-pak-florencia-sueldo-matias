using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    Dictionary<PlayerState, State> allStates = new Dictionary<PlayerState, State>();
    State _currentState;
    Player player;
    

    public FiniteStateMachine(Player player)
    {
        this.player = player;
    }

    public void AddState(PlayerState playerState, State state)
    {

        if (!allStates.ContainsKey(playerState))
        {
            allStates.Add(playerState, state);
            state.fsm = this;
            state.player = this.player;
        }
        else
        {
            allStates[playerState] = state;
        }
    }

    public void Update()
    {
        _currentState.OnUpdate();
    }

    public void ChangeState(PlayerState state, Vector3 target)
    {
        _currentState?.OnExit();
        if (!player.HasToUseObstacleAvoidance())
        {
            if (allStates.ContainsKey(PlayerState.Patrol)) _currentState = allStates[PlayerState.Patrol];
        }
        else
        {
            if (allStates.ContainsKey(state)) _currentState = allStates[state];
        }
        _currentState?.OnEnter(target);
    }
}


public enum PlayerState
{
    Idle, Patrol, Chase
}
