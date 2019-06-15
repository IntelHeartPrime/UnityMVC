using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Controller
{   
    //一个控制器类型，与一个事件一一对应

    
    //获取模型
    protected Model GetModel<T>()
        where T:Model
    {
        return MVC.GetModel<T>();
    }
    //获取视图
    protected View GetView<T>()
        where T:View
    {
        return MVC.GetView<T>();
    }

    //注册模型
    protected void RegisterModel(Model model){
        MVC.RegisterModel(model);
    }
    //注册视图
    protected void RegisterView(View view){
        MVC.RegisterView(view);
    }
    //注册控制器类型
    protected void RegisterController(string eventName,Type controllerType)
    {
        MVC.RegisterController(eventName,controllerType);
    }
    //执行系统消息
    public abstract void Execute(object data);


}

