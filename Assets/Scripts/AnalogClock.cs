using UnityEngine;
using System;

public class AnalogClockVR : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    void Start()
    {
        SetTime(); // sync immediately on start
    }

    void Update()
    {
        SetTime(); // update every frame
    }

    void SetTime()
    {
        DateTime now = DateTime.Now;

        float seconds = now.Second + now.Millisecond / 1000f;
        float minutes = now.Minute + seconds / 60f;
        float hours   = (now.Hour % 12) + minutes / 60f;

        // Your clock is facing sideways, so rotate on Y axis
        secondHand.localRotation = Quaternion.Euler(0, -seconds * 6f, 0);
        minuteHand.localRotation = Quaternion.Euler(0, -minutes * 6f, 0);
        hourHand.localRotation   = Quaternion.Euler(0, -hours * 30f, 0);
    }
}