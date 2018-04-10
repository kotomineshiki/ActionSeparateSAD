using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDirector : System.Object {
    private static SSDirector _instantce;
    public ISceneController currentSceneController
    {
        get;set;
    }
    public bool running
    {
        get;set;

    }
    public static SSDirector getInstance()
    {
        if (_instantce == null)
        {
            _instantce = new SSDirector();
        }
        return _instantce;
    }
	public int getFPS()
    {
        return Application.targetFrameRate;
    }
    public  void setFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}

