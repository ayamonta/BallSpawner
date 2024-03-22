using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class UserMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1.25f;
    public float speed;

    // overlay on the player square object
    float colliderHalfWidth, colliderHalfHeight;


    // Start is called before the first frame update
    void Start()
    {
        speed = moveSpeed * Time.deltaTime;

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector3 boxColliderDim = collider.bounds.max - collider.bounds.min;
        colliderHalfWidth = boxColliderDim.x / 2;
        colliderHalfHeight = boxColliderDim.y / 2;

        Debug.Log($"top.y:{ScreenUtils.ScreenTop}  bot.y:{ScreenUtils.ScreenBot}  " +
            $"left.x:{ScreenUtils.ScreenLeft}  right.x:{ScreenUtils.ScreenRight}  " +
            $"width.coli:{colliderHalfWidth}  height.coli:{colliderHalfHeight}");
    
    }

    // Update is called once per frame
    void Update()
    {
        // moving by using position
        float horizontalInput = Input.GetAxis("Horizontal");    // -1, 0, 1
        float verticalInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalInput * speed, 0, 0);
        transform.position += new Vector3(0, verticalInput * speed, 0);

        KeepInScreen();

    }

    public void KeepInScreen()
    {
        if(transform.position.x < ScreenUtils.ScreenLeft)
        {
            transform.position = new Vector2(ScreenUtils.ScreenLeft+colliderHalfWidth, transform.position.y);
        }
        if(transform.position.x > ScreenUtils.ScreenRight)
        {
            transform.position = new Vector2(ScreenUtils.ScreenRight-colliderHalfWidth, transform.position.y);
        }
        if(transform.position.y > ScreenUtils.ScreenTop)
        {
            transform.position = new Vector2(transform.position.x, ScreenUtils.ScreenTop-colliderHalfHeight);
        }
        if(transform.position.y < ScreenUtils.ScreenBot)
        {
            transform.position = new Vector2(transform.position.x, ScreenUtils.ScreenBot+colliderHalfHeight);
        }

    }
}
