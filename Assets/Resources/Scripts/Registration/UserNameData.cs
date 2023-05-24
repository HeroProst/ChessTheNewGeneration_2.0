using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserNameData
{
    string UserName;

    public UserNameData(string UserName)
    {
        this.UserName = UserName;
    }

    public string GetUserName()
    {
        return UserName;
    }
}
