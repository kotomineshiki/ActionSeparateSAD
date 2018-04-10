using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager,ISSActionCallback {
    public gameController sceneController;
    public CCMoveToAction ASideToBside, BSideToAside;
    public Dictionary<int, CCOn_OffAction> on_off = new;//
	// Use this for initialization
	void Start () {
        float speed = 5f;
        sceneController =(gameController)SSDirector.getInstance().currentSceneController;
        sceneController.actionManager = this;

        ASideToBside = CCMoveToAction.GetSSAction(sceneController.BsidePosition, speed);
        BSideToAside = CCMoveToAction.GetSSAction(sceneController.AsidePosition, speed);
        foreach(KeyValuePair<int,GameObject>obj in sceneController.On_Aside)
        {
            
        }
    }
	
	// Update is called once per frame
    public void SSActionEvent(SSAction source,
        SSActionEventType events = SSActionEventType.Competed,
        int intParam = 0,
        string strParam = null,
        Object objectParam = null
        )
    {

    }
}
