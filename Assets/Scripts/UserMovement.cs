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

    // world coordinates
    float screenLeft, screenRight, screenTop, screenBot;
    // overlay on the player square object
    float colliderHalfWidth, colliderHalfHeight;


    // Start is called before the first frame update
    void Start()
    {
        speed = moveSpeed * Time.deltaTime;

        float screenZ = -Camera.main.transform.position.z;
        Debug.Log($"width: {Screen.width}  height: {Screen.height}");
        //Debug.Log($"object position: {transform.position.x}");
        
        Vector3 botLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 botLeftCornerWorld = Camera.main.ScreenToWorldPoint(botLeftCornerScreen);

        Vector3 topRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 topRightCornerWorld = Camera.main.ScreenToWorldPoint(topRightCornerScreen);

        screenLeft = botLeftCornerWorld.x;
        screenRight = topRightCornerWorld.x;
        screenTop = topRightCornerWorld.y;
        screenBot = botLeftCornerWorld.y;

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Vector3 boxColliderDim = collider.bounds.max - collider.bounds.min;
        colliderHalfWidth = boxColliderDim.x / 2;
        colliderHalfHeight = boxColliderDim.y / 2;

        Debug.Log($"top.y:{screenTop}  bot.y:{screenBot}  left.x:{screenLeft}  right.x:{screenRight}  width.coli:{colliderHalfWidth}  height.coli:{colliderHalfHeight}");
        
        //transform.position = new Vector2(screenLeft+colliderHalfWidth, transform.position.y);
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
        if(transform.position.x < screenLeft)
        {
            transform.position = new Vector2(screenLeft+colliderHalfWidth, transform.position.y);
        }
        if(transform.position.x > screenRight)
        {
            transform.position = new Vector2(screenRight-colliderHalfWidth, transform.position.y);
        }
        if(transform.position.y > screenTop)
        {
            transform.position = new Vector2(transform.position.x, screenTop-colliderHalfHeight);
        }
        if(transform.position.y < screenBot)
        {
            transform.position = new Vector2(transform.position.x, screenBot+colliderHalfHeight);
        }

        //Vector2 position = transform.position;

        //if (position.x - colliderHalfWidth <= screenLeft)
        //{
        //    position.x = screenLeft + colliderHalfWidth;
        //}
        //if ((position.x + colliderHalfWidth) >= screenRight)
        //{
        //    position.x = screenRight - colliderHalfWidth;
        //}
        //if ((position.y + colliderHalfHeight) >= screenTop)
        //{
        //    position.y = screenTop - colliderHalfHeight;
        //}
        //if ((position.y - colliderHalfWidth) <= screenBot)
        //{
        //    position.y = screenBot + colliderHalfHeight;
        //}


        //if (position.x < screenLeft)
        //{
        //    //Physics.SyncTransforms();
        //    position.x = screenLeft;
        //    //Physics.SyncTransforms();
        //}
        //if (position.x > screenRight)
        //{
        //    position.x = screenRight;
        //}
        //if (position.y > screenTop)
        //{
        //    position.y = screenTop;
        //}
        //if (position.y < screenBot)
        //{
        //    position.y = screenBot;
        //}

    }
}
