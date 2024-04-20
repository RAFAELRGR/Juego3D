using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    public ManageClock manageClock;

    [SerializeField]
    GameTimestamp timestamp;
    public float timeScale = 1.0f;

    private void Awake()
    {
        //If there is more than one instance, destroy the extra
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            //Set the static instance to this instance
            Instance = this;
        }
    }

    void Start()
    {
        //Initialise the time stamp
        timestamp = new GameTimestamp(1, 6, 0);
        StartCoroutine(TimeUpdate());
    }


    IEnumerator TimeUpdate()
    {
        while (true)
        {
            Tick();
            yield return new WaitForSeconds(1 / timeScale);
        }

    }


    public void Tick()
    {
        manageClock.Test();
        timestamp.UpdateClock();
        // manageClock.RotationClock();
    }
}