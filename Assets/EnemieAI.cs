using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor.Rendering;
using LootLocker.Requests;

public class EnemieAI : MonoBehaviour
{
    public Transform target;
    public float speed = 400f;
    public float NextWaypointdistance = 3f;
    Path path;
    int currentwaypoint = 0;
    bool reachedendofpath;
    Seeker seeker;
    Rigidbody2D rb;
    public GameObject player;
    public float distancebeforrandomMovement;
    public bool following; // Reference to the target object
    public float maxDistance = 5f; // Maximum distance from the target object
    public bool movingrandom;
    // Start is called before the first frame update
    void Start()
    {
       seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("updating", 0f, .5f);
    }
     public void updating()
    {
        print(seeker.IsDone() + "s");
        if (seeker.IsDone() ){startpath();}
        
    }
    // Update is called once per frame
    void Update()
    {
        if(path == null)
        {
            return;
        }
        if (currentwaypoint>= path.vectorPath.Count)
        {
            reachedendofpath= true;
            return;
        }
        else
        {
            reachedendofpath= false;
        }
        Vector2 dir = ((Vector2)path.vectorPath[currentwaypoint] -rb.position).normalized;
        Vector2 force = dir *speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentwaypoint]);
        if ( distance < NextWaypointdistance)
        {
            currentwaypoint++;
        }
    }
    public void startpath()
    {
        print("looking for path enemie");
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);
        if ( distance > distancebeforrandomMovement)
        {
            seeker.StartPath(rb.position, player.transform.position, onpathComplete);
            print("going to player");
        }
        else
        {
            Vector2 randomOffset = Random.insideUnitCircle.normalized * Random.Range(0f, maxDistance);
            Vector2 randomPosition = (Vector2)gameObject.transform.position + randomOffset;
            seeker.StartPath(rb.position, randomPosition, onpathComplete);
            movingrandom = true;
            print("going random");
        }




    }
    void onpathComplete(Path p )
    {
        if(!p.error)
        {
            path= p;
            currentwaypoint= 0;
        }
    }
}
