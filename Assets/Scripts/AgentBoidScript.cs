using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBoidScript : MonoBehaviour
{
    [SerializeField] protected int speed;
    private Vector3 velocity;
    [SerializeField] protected GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget(target);
    }


    private void FollowTarget(GameObject target)
    {
        Vector3 dir = target.transform.position - transform.position;
        velocity = Vector3.ClampMagnitude(dir.normalized * speed * Time.deltaTime, speed);
        Debug.DrawLine(new Vector3(0, 0, 0), Vector3.ClampMagnitude(target.transform.position, speed));
        transform.position += velocity;
    }
}
