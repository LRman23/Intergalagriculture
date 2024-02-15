using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int min;
    public int Minutes
    { get { return min; } set { min = value; OnMinsChange(value); } }

    private int hours;
    public int Hours 
    { get { return hours; } set { hours = value; OnHoursChange(value); } }

    private int days;
    public int Days
    { get { return days; } set { days = value; } }

    private float tempSec;

    public void Update()
    {
        tempSec += Time.deltaTime;
        if(tempSec >= 1)
        {
            min += 1;
            tempSec = 0;
        }
    }

    private void OnMinsChange(int value)
    {
        if (value >+ 60)
        {
            Hours++;
            min = 0;
        }
        if(Hours >= 24)
        {
            Hours = 0;
            Days++;
        }
    }

    private void OnHoursChange(int value)
    {
        if(value == 6)
        {
        }
        else if(value == 8)
        {
        }
        else if(value == 18)
        {
        }
        else if(value == 22)
        {
        }
    }
}
