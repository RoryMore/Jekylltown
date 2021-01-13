using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public float smoothing = 5f;
	private Vector3 offset;


    private Vector4 currentCam;
    public Vector4 outsideCam; //X,y,z,x rotation

	void Start()
	{
        SetCam(outsideCam);

        transform.position = new Vector3(currentCam.x, currentCam.y, currentCam.z);
        transform.localEulerAngles = new Vector3(currentCam.w, 0, 0);
        //transform.position = new Vector3(target.position.x, target.position.y +6, target.position.z - 4);
        
        

		offset = transform.position - target.position;
	}

	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
	}

    void SetCam(Vector4 camToCopy)
    {
        currentCam = camToCopy;
    }
}
