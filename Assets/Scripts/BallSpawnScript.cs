using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{

    public GameObject ball;
    public TimerScript spawnTimer;


    private void Awake()
    {
        spawnTimer = gameObject.AddComponent<TimerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer.ActivateTimer();
        spawnTimer.EndPoint = Random.Range(2, 4);
        spawnBall();

    }

    // Update is called once per frame
    void Update()
    {

        if (spawnTimer.UnderTime())
        {
            spawnTimer.CountUp();
        }
        else
        {
            spawnBall();
            spawnTimer.RestartTimer();
            spawnTimer.EndPoint = Random.Range(2, 4);
        }
        
    }

    void spawnBall()
    {
        Instantiate(ball, 
            new Vector3(
            Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight), 
            Random.Range(ScreenUtils.ScreenTop, ScreenUtils.ScreenBot), 
            0), 
            transform.rotation);

    }
}
