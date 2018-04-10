using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour {
    public string status="Aside";
    Vector3 Aside=new Vector3(1.91f,0.78f,0.81f);
    Vector3 Bside = new Vector3(1.91f, 0.78f, 8.66f);
    public float speed = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        switch (status)
        {
            case "AsideToBside":
                if (transform.position != Bside)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Bside, speed * Time.deltaTime);
                }
                else
                {
                    status = "Bside";
                }
                break;

            case "BsideToAside":
                if (transform.position != Aside)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Aside, speed * Time.deltaTime);
                }
                else
                {
                    status = "Aside";
                }
                break;
        }
    }
    public void move()
    {
        if (transform.childCount == 0) return;//如果没有子物体，那么不能移动
        switch (status)
        {
            case "Aside":
             //   Debug.Log("move");
                status = "AsideToBside";
                break;
            case "Bside":
                status = "BsideToAside";
                break;
        }
    }
}
