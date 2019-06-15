using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class MVC 
{
    //存储MVC
    //名字-模型
    public static Dictionary<string,Model> Models=new Dictionary<string,Model>();
    //名字-视图
    public static Dictionary<string,View> Views=new Dictionary<string,View>();
    //事件名称-控制器"类型"
    public static Dictionary<string,Type> CommandMap=new Dictionary<string,Type>();

    //注册
    public static void RegisterModel(Model model){
        Models[model.Name]=model;
    }

    public static void RegisterView(View view){
        Views[view.Name]=view;
    }

    public static void RegisterController(string eventName,Type controllerType){
        CommandMap[eventName]=controllerType;
    }
    
    
    //获取
    public static Model GetModel<T>()
        where T:Model
    {
        foreach (Model m in Models.Values)
        {
            if(m is T){
                return m;
            }
        }
        return null;
    }
    
    public static View GetView<T>()
        where T:View
    {
        foreach (View v in Views.Values)
        {
            if(v is T){
                return v;
            }
        }
        return null;
    }

    //发送事件
    public static void SendEvent(string eventName,object data=null){
        //优先执行控制器，再执行模型

        //控制器响应逻辑
        if(CommandMap.ContainsKey(eventName)){
            Type t=CommandMap[eventName];
            
            //反射
            Controller c=Activator.CreateInstance(t) as Controller;
            //控制器执行
            c.Execute(data);
        }

        //视图响应逻辑
        foreach (View v in Views.Values)
        {
            if(v.AttationEvents.Contains(eventName)){
                //视图响应事件
                v.HandleEvent(eventName,data);
            }
        }
    }
}

