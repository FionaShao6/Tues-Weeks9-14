using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;
    public Transform minuteHand;
    public Transform hourHand;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;
    Coroutine ClockIsRuning;
    IEnumerator doOneHour;
    void Start()
    {
        ClockIsRuning = StartCoroutine(MoveTheClock());
    }
    private IEnumerator MoveTheClock()
    {
        while(true)
        {
            doOneHour = MoveTheClockHandsOneHour();
            yield return StartCoroutine(MoveTheClockHandsOneHour());
        }
    }
    IEnumerator MoveTheClockHandsOneHour()
    {
        t = 0;
        while(t< timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;if(hour==13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }
    public void StopTheClock()
    {
        if(ClockIsRuning != null)
        {
            StopCoroutine(ClockIsRuning);
        }
        if(doOneHour != null)
        {
            StopCoroutine(doOneHour);
        }
        
    }
}
