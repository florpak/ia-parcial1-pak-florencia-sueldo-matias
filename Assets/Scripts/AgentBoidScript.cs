using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBoidScript : MonoBehaviour
{
    private Vector3 velocity;
    [SerializeField] protected GameObject target;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _maxForce;
    [SerializeField] private float viewRadius;
    [SerializeField] private GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec;
        if (Vector3.Distance(transform.position, enemy.transform.position)<= viewRadius)
        {
             vec = Flee(enemy.transform.position);
        }
        else
        {
            vec = Arrive(target.transform.position);

        }
        AddForce(vec);

        transform.position += velocity * Time.deltaTime;
        Debug.DrawLine(transform.position, transform.position + velocity,Color.cyan);
        transform.forward = velocity;
    }

    private Vector3 Seek(Vector3 targetPos,float maxSpeed)
    {
        Vector3 vectorDeseado = targetPos - transform.position;
        Debug.DrawLine(transform.position, targetPos);

        vectorDeseado.Normalize();
        vectorDeseado *= maxSpeed;

        Vector3 steering = vectorDeseado - velocity;
        steering = Vector3.ClampMagnitude(steering, _maxForce* Time.deltaTime);
        Debug.DrawLine(transform.position, transform.position+steering, Color.red);

        return steering;

    }

    private Vector3 Arrive(Vector3 targetPos)
    {
        float dist = Vector3.Distance(transform.position, targetPos);
        if(dist < viewRadius)
        {
            return Seek(targetPos, _maxSpeed);
        }
        else
        {
            return Seek(targetPos, _maxSpeed * (dist / viewRadius));
        }
    }

    private Vector3 Flee(Vector3 targetPos)
    {
        return -Seek(targetPos,_maxSpeed);
    }

    private void AddForce(Vector3 force)
    {
        velocity = Vector3.ClampMagnitude(force + velocity, _maxSpeed);
    }


}
