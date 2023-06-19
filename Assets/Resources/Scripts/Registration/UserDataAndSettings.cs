using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserDataAndSettings
{
    string UserName;
    public bool EnableBoardMarking = false;

    public int countOfGames = 0;
    public int countOfWins = 0;
    public int countOfLose = 0;
    public int countOfPatAndDraw = 0;

    public UserDataAndSettings(string UserName)
    {
        this.UserName = UserName;
    }

    public UserDataAndSettings()
    { }

    public string GetUserName()
    {
        return UserName;
    }
}
