using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SunTime : MonoBehaviour
{
    float timer;
    public float addTimer = 3.0f;
    public float smooth = 10;
    public int nextDayTime = 0;
    public List<Quaternion> dayTimes = new List<Quaternion>();
    // Use this for initialization
    void Start()
    {
        timer = Time.time + addTimer;
        Quaternion Morning = Quaternion.Euler(45, 0, 0);
        Quaternion Day = Quaternion.Euler(90, 0, 0);
        Quaternion Evening = Quaternion.Euler(135, 0, 0);
        Quaternion Night = Quaternion.Euler(-78, 0, 0);
        dayTimes.Add(Morning);
        dayTimes.Add(Day);
        dayTimes.Add(Evening);
        dayTimes.Add(Night);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = dayTimes[nextDayTime];
        transform.localRotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        if (Time.time > timer)
        {
            letfRollTehSunHurrDurr();
            timer = Time.time + addTimer;
        }
    }

    void letfRollTehSunHurrDurr()
    {
        if (nextDayTime < 3)
        {
            nextDayTime += 1;
        }
        else
        {

            nextDayTime = 0;
        }
        Debug.Log(dayTimes[nextDayTime].ToString());
    }
}
