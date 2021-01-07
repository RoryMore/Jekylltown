using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    float seconds;
    [SerializeField]
    float minutes;
    [SerializeField]
    float hours;


    public float smooth = 10; //The rate at which the sun moves
    public float timeScale; //The number that changes how fast time goes by. 1 is real time.

    // Start is called before the first frame update
    void Start()
    {
        seconds = 0.0f; minutes = 0.0f; hours = 6.0f; //Dawn?



    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime * timeScale;
        Quaternion nextPos = new Quaternion(transform.localRotation.x + 1, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
        ///transform.localRotation = Quaternion.Slerp(transform.rotation, nextPos, Time.deltaTime * smooth);
        if (seconds >= 60.0f)
        {
            seconds = 0.0f;
            minutes += 1.0f;
            if (minutes >= 60.0f)
            {
                minutes = 0.0f;
                hours += 1;
            }
        }
    }




}
