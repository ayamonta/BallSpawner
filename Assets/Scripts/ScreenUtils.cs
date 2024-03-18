using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils
{
	#region Fields
	
	// saved to support resolution changes
	static int screenWidth;
	static int screenHeight;
	
	// cached for efficient boundary checking
	static float screenLeft;
	static float screenRight;
	static float screenTop;
	static float screenBot;

    #endregion Fields

    public static float ScreenLeft{
		get { return screenLeft; }
	}
	
	public static void Initialize(){
		// complete the code
		// put Initialize in Ball object (whatever new object that needs bounds)
        float screenZ = -Camera.main.transform.position.z;
        Debug.Log($"width: {Screen.width}  height: {Screen.height}");
        
        Vector3 botLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 botLeftCornerWorld = Camera.main.ScreenToWorldPoint(botLeftCornerScreen);

        Vector3 topRightCornerScreen = new Vector3(Screen.width, Screen.height, screenZ);
        Vector3 topRightCornerWorld = Camera.main.ScreenToWorldPoint(topRightCornerScreen);

        screenLeft = botLeftCornerWorld.x;
        screenRight = topRightCornerWorld.x;
        screenTop = topRightCornerWorld.y;
        screenBot = botLeftCornerWorld.y;
		
	}
}