using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{

    public TimerScript timer;


    void Awake()
    {
        timer = gameObject.AddComponent<TimerScript>();
    }


    // Start is called before the first frame update
    void Start()
    {
        timer.ActivateTimer();
        timer.EndPoint = 3;
        Debug.Log($"elapsed: {timer.Elapsed}");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.UnderTime())
        {
            timer.CountUp();
            //Debug.Log($"elapsed: {timer.Elapsed}");
        }
        else
        {
            Debug.Log($"finished time: {timer.Elapsed}");
            timer.RestartTimer();
            Debug.Log("Restarted timer");
            //Debug.Log($"elapsed: {timer.Elapsed}");
        }
    }
}
