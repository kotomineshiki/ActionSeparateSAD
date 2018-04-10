using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoving : MonoBehaviour {
    Vector3 Aside = new Vector3(0, 0f, -2.19f);
    Vector3 Bside = new Vector3(0f, 0f, 11.35f);
    public string status = "Aside";//表明当前状态
    public  GameObject boat;
    public float speed;
    public string identity;
	// Use this for initialization
	void Start () {
        identity = tag;
	}
	public void setBoat(GameObject b)
    {
        boat = b;
    }
	// Update is called once per frame
	void Update () {
        switch (status)
        {
            case "AsideToBoat":
                if (transform.position.z <= boat.transform.position.z)//如果在动
                {
                    transform.position= transform.position+new Vector3(0,0, speed * Time.deltaTime) ;
                }
                else
                {
                    status = "Boat";
                    transform.parent = boat.transform;//调节附属关系
                }
                break;
            case "BsideToBoat":
                if (transform.position.z >= boat.transform.position.z)//如果在动
                {
                    transform.position = transform.position - new Vector3(0, 0, speed * Time.deltaTime);
                }
                else
                {
                    status = "Boat";
                    transform.parent = boat.transform;//调节附属关系
                }
                break;
            case "BoatToBside":
                if (transform.position.z <= Bside.z)//如果在动
                {
                    transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
                }
                else
                {
                    status = "Bside";
                    transform.parent = null;//调节附属关系
                }
                break;
            case "BoatToAside":
                if (transform.position.z >= Aside.z)//如果在动
                {
                //    Debug.Log("t");
                    transform.position = transform.position - new Vector3(0, 0, speed * Time.deltaTime);
                }
                else
                {
                    status = "Aside";
                //    Debug.Log("8");
                    transform.parent = null;//调节附属关系
                }
                break;
        }
	}
    public void move (){

        switch (status)
        {
            case "Aside"://走到船上
                if (boat.transform.childCount >= 2) return;
                if ( boat.GetComponent<Boat>().status == "Aside")
                    status = "AsideToBoat";
                break;
            case "Bside"://走到船上
                if (boat.transform.childCount >= 2) return;
                if (boat.GetComponent<Boat>().status == "Bside")
                    status = "BsideToBoat";
                break;
            case "Boat"://走到岸A或者岸B
                if (boat.GetComponent<Boat>().status == "Aside")
                {
                    status = "BoatToAside";
                }
                if (boat.GetComponent<Boat>().status == "Bside")
                {
                    status = "BoatToBside";
                }
                break;
            case "moving"://表示正在移动
                break;
        }
    }
}
