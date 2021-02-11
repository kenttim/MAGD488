using UnityEngine;
using UnityEngine.AI;


/*
    BE SURE TO APPLY A NAV MESH AGENT TO BOTH THE PLAYER AND THE BOSS
 */

public class BossController : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public NavMeshAgent player;

    public int frequency;
    private int timer;
    // Update is called once per frame
    void Start()
    {
        timer = frequency;
    }
    void Update()
    {
        timer -= 1;
        if (timer < 0)
        {
            agent.SetDestination(GameObject.Find("player").transform.position);
            timer = frequency;
        }
        
    }
}
/*
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{

    public NavMeshAgent boss;

    

    private int timer = 60;

    void Update()
    {
        timer -= 1;
        if (timer <= 0)
        {
            
            timer = 60;
        }
    }
}
*/