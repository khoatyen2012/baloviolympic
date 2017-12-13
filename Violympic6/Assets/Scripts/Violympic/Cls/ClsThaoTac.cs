using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class ClsThaoTac  {

    public static double doKetQua(string tmp)
    {
        double ok;
        if (GameController.instance.level == 14 || GameController.instance.level == 15 || GameController.instance.level == 19 || GameController.instance.level == 20)
        {
            if (tmp.Contains(":"))
            {
                string[] mang = tmp.Split(':');
                ok = Math.Round((double.Parse(mang[0]) / double.Parse(mang[1])), 6);
            }
            else
            {
                ok = double.Parse(tmp);
            }
        }
        else
        {
            ok = double.Parse(tmp);
        }
        return ok;
    }

    public static string CoverTimeToString(int mTime)
    {
        string stTime = "";
        int timeN = mTime / 60;
        int timeD = mTime % 60;
        if (timeD >= 10)
        {
            stTime = "" + timeN + ":" + timeD;
        }
        else
        {
            stTime = "" + timeN + ":0" + timeD;
        }
        return stTime;
    }

   






    }

