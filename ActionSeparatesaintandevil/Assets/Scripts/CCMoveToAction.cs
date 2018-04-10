/* 这个文件是移动动作的类，主要用来实现船的向左移动和向右移动
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMoveToAction : SSAction
{

    public Vector3 target;          //要移到的位置
    public float speed;             //移动的速度

    //获取一个移动动作的实例对象
    public static CCMoveToAction GetSSAction(Vector3 target, float speed)
    {
        CCMoveToAction action = ScriptableObject.CreateInstance<CCMoveToAction>();
        action.target = target;
        action.speed = speed;
        Debug.Log(speed.ToString());
        return action;
    }
    // Use this for initialization
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        if (this.transform.position == target)
        {
            //this.destroy = true;
            this.enable = false;
            this.callback.SSActionEvent(this);          //因为SSActionEvent这个函数并没有实现，所以这里并没有什么作用
        }


    }
}