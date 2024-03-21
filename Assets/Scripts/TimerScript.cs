using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class TimerScript : MonoBehaviour
{

    //public TimerScript timer;

    //public class Timer
    //{
        /// <summary> Default value (= 0) when timer begins </summary>
        public float startPoint = 0;
        /// <summary> End of timer duration </summary>
        public float endPoint = 2.5f;
        /// <summary> Running time...current total time during runtime </summary>
        public float elapsed = 0;
        /// <summary> If the timer is still counting up </summary>
        public bool running = false;
        //public bool pause = false;
        //public bool resume = true;


        /// <summary> (optional) Set beginning point when timer starts </summary>
        public float StartPoint 
        { 
            get => startPoint; 
            set => startPoint = value; 
        }
        /// <summary> Set deadline when timer restarts </summary>
        public float EndPoint 
        { 
            get => endPoint; 
            set => endPoint = value; 
        }
        public float Elapsed => elapsed;
        public bool Running => running;


        public void DeactivateTimer()
        {
            running = false;
        }
        
        public void ActivateTimer()
        {
            running = true;
        }

        public void KillTimer()
        {
            // destroy object
        }

        public void CountUp()
        {
            if (!running)
            {
                return;
            }
            if (running)
            {
                //Debug.Log($"elapsed: {elapsed}");
                elapsed += Time.deltaTime;
                running = true;
                
                
            }

        }

        public void RestartTimer()
        {
            //if (elapsed > endPoint)
            //{
            elapsed = startPoint;
            //}
        }

        public bool UnderTime()
        {
            //if (elapsed < endPoint)
            //{
            //    return true;
            //}
            //return false;
            return (elapsed < endPoint);
        }

        public bool OverTime()
        {
            return (elapsed > endPoint);
        }

}
