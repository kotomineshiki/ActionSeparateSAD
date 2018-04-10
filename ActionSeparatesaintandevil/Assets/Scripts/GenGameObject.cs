using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenGameObject : MonoBehaviour {
    public GameObject saintPrefabs;
    public GameObject devilPrefabs;
    public GameObject sidePrefabs;
    public GameObject[] saints;
    public GameObject[] devils;
    public GameObject Aside;
    public GameObject Bside;
    public GameObject Boat;
    public GameObject boat;
    // Use this for initialization
    private void Awake()
    {
        
    }
    void Start () {
      //  generate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void generate()
    {
        saints = new GameObject[3];
        saints[0] = Object.Instantiate( saintPrefabs) as GameObject;
        saints[1] = Object.Instantiate(saintPrefabs) as GameObject;
        saints[2] = Object.Instantiate(saintPrefabs) as GameObject;
        saints[0].transform.position = new Vector3(-1.87f, 1.43f, -2.19f);
        saints[1].transform.position = new Vector3(-0.2f, 1.43f, -2.19f);
        saints[2].transform.position = new Vector3(1.2f, 1.43f, -2.19f);
        devils = new GameObject[3];
        devils[0] = Object.Instantiate(devilPrefabs) as GameObject;
        devils[1] = Object.Instantiate(devilPrefabs) as GameObject;
        devils[2] = Object.Instantiate(devilPrefabs) as GameObject;
        devils[0].transform.position = new Vector3(2.67f, 1.43f, -2.19f);
        devils[1].transform.position = new Vector3(4.18f, 1.43f, -2.19f);
        devils[2].transform.position = new Vector3(5.61f, 1.43f, -2.19f);
        Aside = Object.Instantiate(sidePrefabs) as GameObject;
        Bside = Object.Instantiate(sidePrefabs) as GameObject;
        Aside.transform.position = new Vector3(1.918f,0.782f,-5.69f);
        Bside.transform.position = new Vector3(1.918f, 0.782f, 15.2f);
        boat = Instantiate(Boat);
        boat.transform.position = new Vector3(1.91f, 0.78f, 0.81f);
        foreach(var i in saints)
        {
            i.GetComponent<CharacterMoving>().setBoat(boat);
        }
        foreach (var i in devils)
        {
            i.GetComponent<CharacterMoving>().setBoat(boat);
        }
    }
}
