using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{   
    public abstract void OnEnter();
    public abstract void OnUpdate();
    public abstract void OnExit();
    public FiniteStateMachine fsm;
    public Player player;

    public Vector3 Arrive(GameObject WayPoint)
    {
        Vector3 desired = WayPoint.transform.position- player.transform.position;

        float dist = Vector3.Distance(player.transform.position, desired);
        if (dist > player.GetViewRadius())
        {
            return Seek(desired.normalized, player.GetMaxSpeed());
        }
        else if( dist> 0.01f)
        {
            return Seek(desired.normalized, player.GetMaxSpeed() * (dist / player.GetViewRadius()));
        }
        return Vector3.zero;
    }
    public Vector3 Seek(Vector3 targetPos, float maxSpeed)
    {
        Debug.DrawLine(player.transform.position, targetPos, Color.yellow);
        Vector3 vectorDeseado = targetPos - player.transform.position;
        Debug.DrawLine(player.transform.position, targetPos - player.transform.position, Color.white);

        vectorDeseado.Normalize();
        vectorDeseado *= maxSpeed;

        Vector3 steering = vectorDeseado - player.GetVelocity();
        steering = Vector3.ClampMagnitude(steering, player.GetMaxForce() * Time.deltaTime);


        return steering;

    }

    public void AddForce(Vector3 force)
    {
        player.SetVelocity(Vector3.ClampMagnitude(force + player.GetVelocity(), player.GetMaxSpeed()));
    }
    public void AddChaseForce(Vector3 force,float velocity)
    {
        player.SetVelocity(Vector3.ClampMagnitude(force + player.GetVelocity(), player.GetMaxSpeed()));
    }

}
