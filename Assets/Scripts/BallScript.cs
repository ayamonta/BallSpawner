using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    //static int numCollisions = 0;
    const float MinImpulseForce = 3.0f;
    const float MaxImpulseForce = 5.0f;

    public TimerScript deathTimer;

    //bool m_Activate;


    private void Awake()
    {
        deathTimer = gameObject.AddComponent<TimerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("This is the first game");
        //m_Activate = true;
        //Vector3 position = transform.position;
        //position.x = 5;
        //transform.position = position;

        //Vector3 scale = transform.localScale;     //method1:works
        //scale.x = scale.x + scale.x;
        //scale.y = scale.y + scale.y;
        //transform.localScale = scale; 
        ////transform.localScale *= 2;  // method2:works
        ////scale *= 2;     // method3:doesn't work 

        
        //Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        //// rb2d.AddForce(new Vector2(Random.Range(-10,10), Random.Range(-10,10)), ForceMode2D.Impulse); 
        //rb2d.AddForce(new Vector2(Random.Range(-10,10), Random.Range(-10,10)), ForceMode2D.Impulse);


        float angle = Random.Range(0, 2* Mathf.PI);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(magnitude * direction, ForceMode2D.Impulse);

        deathTimer.ActivateTimer();
        deathTimer.EndPoint = 10;


    }

    // Update is called once per frame
    void Update()
    {
        if (deathTimer.UnderTime())
        {
            deathTimer.CountUp();
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("ball deleted");
            deathTimer.RestartTimer();
        }

    }

    void OnCollisionEnter2D(Collision2D col) {
        //we can add code to resolve the collision
 
        //++numCollisions;
        //if(numCollisions == 20)
        //{
        //    Destroy(gameObject);
        //    Debug.Log("Object is destroyed after 20 collisions");
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}

        //Debug.Log($"# collisions: {numCollisions}");
    }

}
