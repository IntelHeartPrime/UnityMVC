﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{   
    //视图标识
    public abstract string Name{get;}
    
    //事件列表
    public List<string> AttationEvents=new List<string>();
    
    //事件处理
    public abstract void HandleEvent(string eventName,object data);
    //获取模型
    protected Model GetModel<T>()
        where T:Model
    {
            return MVC.GetModel<T>();
    }

    //发送消息
    protected void SendEvent(string eventName,object data=null){
        MVC.SendEvent(eventName,data);
    }


}
