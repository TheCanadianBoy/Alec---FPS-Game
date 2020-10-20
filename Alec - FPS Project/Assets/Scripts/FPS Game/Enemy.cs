using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool gotHit;
    [SerializeField] bool canBeKilled;
    [SerializeField] GameManager gameManager;
    public MeshRenderer m_Renderer;
    public UnityEngine.AI.NavMeshAgent agent;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public LayerMask whatIsGround;
    private void Awake()
    {
        //We find the Mesh Renderer component and start the game with it activated
        m_Renderer = GetComponent<MeshRenderer>();
        gotHit = false;
        canBeKilled = true;

    }

    public void Update()
    {
        if(!gotHit)
        {
            Patroling();
        }
    }
    public void isHit()
    {
        if (canBeKilled)
        {    
            m_Renderer.material.DOColor(Color.red, 2f);
            gotHit = true;
            this.gameObject.GetComponent<Enemy>().canBeKilled = false;
            this.gameObject.tag = "EnemyDead";
            gameManager.EnemyKill();
        }
    }

    private void Patroling()
    {
        //First, we check if we have a position to go to. If we don't, we look for one. If we do, we go there
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        else if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            transform.rotation = Quaternion.LookRotation(transform.position - walkPoint);
        }

        //Afterward, we compare our position to the position we are trying to reach
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //If we arrived to the destination, we stop and look for a new point with SearchWalkPoint()
        //.magnitude is the length of the line between the point of origin and the point of arrival. If the line's length is close to 0, we have arrived
        if (distanceToWalkPoint.magnitude < 2f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //Calculate a random point to walk towards
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        //The AI now finds random points on the map
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //Since the random point could be off the map, we have to check if the point is on the ground. If it is, he have our walkPoint
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }
}
