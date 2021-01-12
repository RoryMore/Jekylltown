using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothing = 5f;
	private Vector3 offset;



    private Vector4 currentCam; // The format goes x = x position, y = y position, z = z position and w = x rotation
    public Vector4 outsideCam;
    public Vector4 ButcherWindowCam;

	void Start()
	{
        SetCam(outsideCam, false);
	}

	void FixedUpdate()
	{
        FollowPlayer();
	}

    void SetCam(Vector4 camToCopy, bool lerp)
    {
        currentCam = camToCopy;

        //Make it smooth transition
        if (lerp)
        {
            transform.position = Vector3.Lerp(transform.position, currentCam, smoothing * Time.deltaTime);
            transform.localEulerAngles = new Vector3(currentCam.w, 0, 0);
            offset = transform.position - target.position;

        }

        //Snap to new location
        else
        {
            transform.position = new Vector3(currentCam.x, currentCam.y, currentCam.z);
            transform.localEulerAngles = new Vector3(currentCam.w, 0, 0);
            offset = transform.position - target.position;
        }


    }

    void FollowPlayer()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }

}
