using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheBoat : MonoBehaviour {
    private FirstSceneControl firstSceneControl;
    // Use this for initialization
    void Start () {
        firstSceneControl = (FirstSceneControl)Director.getInstance().currentSceneControl;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        var action = Director.getInstance().currentSceneControl as IUserAction;
        action.MoveBoat();
    }
}
