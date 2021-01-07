using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderRaycast : MonoBehaviour
{
    public GameObject cam;
    public GameObject target;
    public GameObject sphere;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //Does the ray touch the sphere?
        if (Physics.Raycast(cam.transform.position,
            (target.transform.position - cam.transform.position).normalized, out hit, Mathf.Infinity))

        {
            if (hit.collider.gameObject.tag == "Player")
            {
                //sphere.transform.
                sphere.transform.localScale = new Vector3(0,0,0);
            }

            else
            {

                sphere.transform.localScale = new Vector3(10, 10, 10);
            }
        }

        else
        {

            sphere.transform.localScale = new Vector3(10, 10, 10);
        }
        
    }
}
