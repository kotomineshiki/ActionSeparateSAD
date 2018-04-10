using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour ,ISceneController,IUserAction{
    //public  Camera viewport;
    // Use this for initialization

    
    public string gameState="";
    public enum BoatState { }
    public GameObject Aside;
    public GameObject Bside;
    public GameObject boat;

    public Dictionary<int, GameObject> On_Boat = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> On_Aside = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> On_Bside = new Dictionary<int, GameObject>();

    public Vector3 AsidePosition =;
    public Vector3 BsidePosition =;

    public GameState game_state;
    void Awake()
    {
        SSDirector director = SSDirector.getInstance();
        director.currentSceneController = this;
        director.currentSceneController.GenGameObject();
    }
	void Start () {


    }
    public void GenGameObject()
    {
        saints = new GameObject[3];
        saints[0] = Object.Instantiate(saintPrefabs) as GameObject;
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
        Aside.transform.position = new Vector3(1.918f, 0.782f, -5.69f);
        Bside.transform.position = new Vector3(1.918f, 0.782f, 15.2f);
        boat = Instantiate(Boat);
        boat.transform.position = new Vector3(1.91f, 0.78f, 0.81f);
        foreach (var i in saints)
        {
            i.GetComponent<CharacterMoving>().setBoat(boat);
        }
        foreach (var i in devils)
        {
            i.GetComponent<CharacterMoving>().setBoat(boat);
        }
    }

    public void restart()
    {

    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                //Debug.Log("!");
                var todo = hit.collider;
                switch (todo.transform.tag)
                {
                    case "saint":
                        todo.GetComponent<CharacterMoving>().move();
                        break;
                    case "devil":
                        todo.GetComponent<CharacterMoving>().move();
                        break;
                    case "boat":
                        todo.GetComponent<Boat>().move();
                        break;
                }

            }
        }
        switch (checkWin())
        {
            case 1:
                Debug.Log("Wins");
                gameState = "Win";
                break;
            case 2:
                Debug.Log("Saints defeated");
                gameState = "Lose";
                break;

        }

    }
    GameState checkWin()//检查游戏结果
    {
        int AsideSaintsCount=0;
        int BsideSaintsCount=0;
        int AsideDevilsCount = 0;
        int BsideDevilsCount = 0;

        int BoatSaintsCount = 0;
        int BoatDevilsCount = 0;
        foreach(var i in this.GetComponent<GenGameObject>().saints)
        {
            if (i.GetComponent<CharacterMoving>().status == "Bside"|| i.GetComponent<CharacterMoving>().status == "BoatToBside"|| i.GetComponent<CharacterMoving>().status == "BsideToBoat") BsideSaintsCount++;
            if (i.GetComponent<CharacterMoving>().status == "Aside"|| i.GetComponent<CharacterMoving>().status == "BoatToAside" || i.GetComponent<CharacterMoving>().status == "AsideToBoat") AsideSaintsCount++;

            if (i.GetComponent<CharacterMoving>().status == "Boat") BoatSaintsCount++;
        }

        foreach (var i in this.GetComponent<GenGameObject>().devils)
        {
            if (i.GetComponent<CharacterMoving>().status == "Bside"|| i.GetComponent<CharacterMoving>().status == "BoatToBside" || i.GetComponent<CharacterMoving>().status == "BsideToBoat") BsideDevilsCount++;
            if (i.GetComponent<CharacterMoving>().status == "Aside"|| i.GetComponent<CharacterMoving>().status == "BoatToAside" || i.GetComponent<CharacterMoving>().status == "AsideToBoat") AsideDevilsCount++;

            if (i.GetComponent<CharacterMoving>().status == "Boat") BoatDevilsCount++;
        }
        string bstatus = this.GetComponent<GenGameObject>().boat.GetComponent<Boat>().status;
        if (BsideSaintsCount + BsideDevilsCount == 6) return GameState.WIN;//全员到达B
        if (bstatus == "Aside")
        {
            
            AsideSaintsCount += BoatSaintsCount;
            AsideDevilsCount += BoatDevilsCount;
       //     Debug.Log("A"+BoatSaintsCount);
        }
        if (bstatus == "Bside")
        {
            BsideSaintsCount += BoatSaintsCount;
            BsideDevilsCount += BoatDevilsCount;
        }

        if (BsideSaintsCount != 0 && BsideSaintsCount < BsideDevilsCount) {
            //Debug.Log(BsideSaintsCount);
            return GameState.FAILED;
        }//牧师人数比魔鬼少
        //牧师被杀了
        if (AsideSaintsCount != 0 && AsideSaintsCount < AsideDevilsCount)
        {
            //Debug.Log(AsideSaintsCount);
            return GameState.FAILED;
        }
        return GameState.NOT_ENDED;//无事发生
    }
    public GameState getGameState()
    {
        return game_state;
    }
    public void GameOver()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(700, 300, 400, 400), "GameOver");
    }
    /*public int get_num(Dictionary<int,GameObject> dict,int ch)
    {
        var keys = dict.Keys;
        int d_num = 0;
        int p_num = 0;
        foreach(int i in keys)
        {
            if (i < 3 || (i >= 6 && i <= 8))
            {
                p_num++;
            }
            else
            {
                d_num++;
            }

        }
        return (ch == 1 ? p_num : d_num);
    }*/
}
