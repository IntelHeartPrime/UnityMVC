using System.Collections;
using System.Collections.Generic;

public abstract class Model 
{
    //read-only
    public abstract string Name{get;}

    protected void SendEvent(string eveName,object data=null){
        MVC.SendEvent(eveName,data);
    }
}
