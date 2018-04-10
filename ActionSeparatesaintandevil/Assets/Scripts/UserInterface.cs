using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour {
    private IUserAction action;
	// Use this for initialization
	void Start () {
        action = SSDirector.getInstance().currentSceneController as IUserAction;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnGUI()
    {
        if (gameState == "Win")
        {
            GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.5f, 100, 30), "WIN");
            if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.5f, 100, 30), "REstart"))
            {
                restart();
            }
        }
        if (gameState == "Lose")
        {
            GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.5f, 100, 30), "saint KILLED");
            if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.5f, 100, 30), "REstart"))
            {
                restart();
            }
        }

    }
}
