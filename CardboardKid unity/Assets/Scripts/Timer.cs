using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public static float TimeScoreSeconds, TimeScoreMin, TimeScoreHours;
    public bool TimerOff;

	// Use this for initialization
	void Start ()
    {
        TimeScoreHours = 0;
        TimeScoreMin = 0;
        TimeScoreSeconds = 0;
        TimerOff = true;
        Invoke("TimerOn", 3);
	}
	
	// Update is called once per frame
	void Update ()

    {
        if (TimerOff == false)
        {
            TimeScoreSeconds = TimeScoreSeconds + Time.deltaTime;
            if (TimeScoreSeconds >= 60)
            {
                TimeScoreMin = TimeScoreMin + 1;
                TimeScoreSeconds = 0;
            }
            if (TimeScoreMin >= 60)
            {
                TimeScoreHours = TimeScoreHours + 1;
                TimeScoreMin = 0;
            }
        }
       

    }

    public void TimerOn()
    {
        TimerOff = false;
    }
}
