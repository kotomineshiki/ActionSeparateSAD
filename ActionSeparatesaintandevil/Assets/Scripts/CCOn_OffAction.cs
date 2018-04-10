/* 这个文件用来实现人物的上下船的动作
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCOn_OffAction : SSAction
{

    private FirstSceneControl firstSceneControl;
    enum Pos { ON_BOAT, ON_SHORE }      //管理人物游戏对象的位置

    //判断人物游戏对象的位置
    Pos find_Pos(int id)
    {
        if (id >= 6) return Pos.ON_BOAT;
        return Pos.ON_SHORE;
    }

    public static CCOn_OffAction GetSSAction()
    {
        CCOn_OffAction action = ScriptableObject.CreateInstance<CCOn_OffAction>();
        return action;
    }

    // Use this for initialization
    public override void Start()
    {
        firstSceneControl = (FirstSceneControl)Director.getInstance().currentSceneControl;
    }

    /* 通过id来判断人物游戏对象的位置，
     * 每个人物对象在不同的位置都有一个id，
     * 在右岸时，从左到右编号为0~5，人物在左岸的
     * id与右岸相同，如果人物上船，那么它对应的id就
     * 加6，如果人物下船，那么它对应的id就减6，另外
     * 人物的id与它们的名字时刻对应，id改变，名字也
     * 会改变
     */
    public override void Update()
    {
        if (firstSceneControl.game_state == GameState.NOT_ENDED)
        {
            if (firstSceneControl.b_state == FirstSceneControl.BoatState.MOVING) return;
            int id = Convert.ToInt32(gameobject.name);
            if (firstSceneControl.b_state == FirstSceneControl.BoatState.STOPRIGHT)
            {
                if (firstSceneControl.On_Shore_r.ContainsKey(id))
                {
                    if (find_Pos(id) == Pos.ON_SHORE && firstSceneControl.boat_capicity != 0)
                    {
                        firstSceneControl.On_Boat.Add(id + 6, firstSceneControl.On_Shore_r[id]);
                        firstSceneControl.On_Shore_r.Remove(id);
                        gameobject.name = (id + 6).ToString();
                        gameobject.transform.parent = firstSceneControl.boat.transform;
                        firstSceneControl.boat_capicity--;
                    }
                }


                if (find_Pos(id) == Pos.ON_BOAT)
                {

                    firstSceneControl.On_Shore_r.Add(id - 6, firstSceneControl.On_Boat[id]);
                    firstSceneControl.On_Boat.Remove(id);
                    gameobject.name = (id - 6).ToString();
                    gameobject.transform.parent = null;
                    firstSceneControl.boat_capicity++;
                }
            }
            if (firstSceneControl.b_state == FirstSceneControl.BoatState.STOPLEFT)
            {

                if (find_Pos(id) == Pos.ON_SHORE && firstSceneControl.boat_capicity != 0)
                {
                    if (firstSceneControl.On_Shore_l.ContainsKey(id))
                    {
                        firstSceneControl.On_Boat.Add(id + 6, firstSceneControl.On_Shore_l[id]);
                        firstSceneControl.On_Shore_l.Remove(id);
                        gameobject.name = (id + 6).ToString();
                        gameobject.transform.parent = firstSceneControl.boat.transform;
                        firstSceneControl.boat_capicity--;
                    }

                }

                if (find_Pos(id) == Pos.ON_BOAT)
                {
                    firstSceneControl.On_Shore_l.Add(id - 6, firstSceneControl.On_Boat[id]);
                    firstSceneControl.On_Boat.Remove(id);
                    gameobject.name = (id - 6).ToString();
                    gameobject.transform.parent = null;
                    firstSceneControl.boat_capicity++;
                }
            }

            int new_id = Convert.ToInt32(gameobject.name);
            if (id != new_id)
            {
                this.enable = false;
                this.callback.SSActionEvent(this);
            }

        }
    }
}