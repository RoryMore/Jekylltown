using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Imp : NPC
{
    //Eventually, game manager should spawn all entities who need to be

    

    //The time before imp doubles their movement speed
    float timeUntilSprint = 2.0f;
    float timeUntilWalk = 5.0f;
    public float runDistance = 4.0f;
    bool retreat = false;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Retreat();
    }

    //Function to retreat
    void Retreat()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        
        //If too close, run away
        if (dist <= 4.0f)
        {
            retreat = true;
        }

        if (retreat)
        {
            //Moves directly away from target
            Vector3 target = (transform.position - player.transform.position);
            Vector3 newPos = transform.position + target;
            agent.SetDestination(newPos);

            //Countdown to sprint
            timeUntilSprint -= Time.deltaTime;
            if (timeUntilSprint <= 0)
            {
                //Begin Sprint!
                agent.speed = 6.0f;
                timeUntilWalk -= Time.deltaTime;

                if (timeUntilWalk <= 0)
                {
                    agent.speed = 3.0f;
                    timeUntilWalk = 5.0f;
                    timeUntilSprint = 2.0f;
                }
            }
        }
        
        //Can the camera see imp? This isn't quite working right but 
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if ( viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            retreat = false;
            //Teleport him maybe?
        }

        
          

            
        
    }
}
