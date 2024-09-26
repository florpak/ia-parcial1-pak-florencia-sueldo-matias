using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float width, height;

    public static GameManager Instance;
    public List<Agent> agents;
    public List<EnemyAgent> enemyAgent;
    public List<Player> playerAgent;
    public List<FoodScript> food;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
        }
        
    }

    public Vector3 AdjustPositionsToBounds(Vector3 pos)
    {
        float boundWidth = width / 2;
        float boundHeight = height / 2;

        if (pos.x > boundWidth) pos.x = -boundWidth;
        if (pos.x < -boundWidth) pos.x = boundWidth;
        if (pos.z > boundHeight) pos.z = -boundHeight;
        if (pos.z < -boundHeight) pos.z = boundHeight;
        return pos;

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(width,0,height));
    }
}
