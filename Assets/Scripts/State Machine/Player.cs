using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    private FiniteStateMachine fsm;
    [SerializeField] protected float size = 1f;
    List<Agent> boidsList;
    [SerializeField]
    protected Agent targetAgent;
    [SerializeField]
    protected float stamina;
    [SerializeField]
    protected List<GameObject> wayPoints;

    // Start is called before the first frame update
    void Start()
    {
         size = 1f;
        //GameManager.Instance.enemyAgent.Add(this);
        fsm = new FiniteStateMachine(this);
        fsm.AddState(PlayerState.Idle, new IdleState());
        fsm.AddState(PlayerState.Patrol, new PatrolState());
        fsm.ChangeState(PlayerState.Idle,transform.position);
        boidsList = GameManager.Instance.agents;
    }

    // Update is called once per frame
    void Update()
    {
        fsm.Update();

    }

    private void UpdateToChase()
    {
        foreach (Boid item in boidsList)
        {
            /*if (Vector3.Distance(transform.position,item.transform.position< viewRadius){
                fsm.ChangeState(PlayerState.Attack,);
            })*/
        }
       
    }

    public Transform GetTransform()
    {
        return this.transform;
    }

    public float GetSize()
    {
        return this.size;
    }
    public float GetMaxSpeed()
    {
        return this._maxSpeed;
    }
    public float GetMaxForce()
    {
        return this._maxForce;
    }
    public float GetViewRadius()
    {
        return this.viewRadius;
    }
    public Vector3 GetVelocity()
    {
        return this.velocity;
    }
    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }
    public LayerMask GetObstacleLayer()
    {
        return this.obstacleLayer;
    }
    public float GetStamina()
    {
        return this.stamina;
    }
    public float AddStamina(float amount)
    {
        return this.stamina += amount;
    }
    public List<GameObject> GetWayPoints()
    {
        return this.wayPoints;
    }
}
