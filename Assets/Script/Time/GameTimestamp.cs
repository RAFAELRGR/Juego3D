using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameTimestamp
{
    public int day, hour, minute;
    public bool timesUp = false;
    public enum DayOfTheWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }

    public GameTimestamp(int day, int hour, int minute)
    {
        this.day = day;
        this.hour = hour;
        this.minute = minute;
    }

    public void UpdateClock()
    {
        if (timesUp == false)
        {
            minute++;
            if (minute >= 60)
            {
                minute = 0;
                hour++;
            }

            if (hour >= 12)
            {
                hour = 0;
                day++;
                timesUp = true;
            }
        }
    }

    public void DisableTime()
    {
        timesUp = true;
    }

    public static int HoursToMinutes(int hour)
    {
        return hour * 60;
    }

    public static int DaysToHours(int days)
    {
        return days * 12;
    }

    public DayOfTheWeek GetDayOfTheWeek()
    {
        int dayIndex = day % 7;
        return (DayOfTheWeek)dayIndex;
    }
}
//un dia en el juego-> 12m de juego continuo y una pausa para prepararse al siguiente dia. 15m de juego por dia de granja

//