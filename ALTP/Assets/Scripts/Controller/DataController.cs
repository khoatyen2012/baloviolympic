using UnityEngine;
using System.Collections;

public class DataController
{

    private static string TAG_HIGHTSCORE = "hightLevel";
    private static string TAG_HIGHTSECOND = "hightSecond";
    private static string TAG_NAME = "myname";
    private static string TAG_MAC = "mymac";
    private static string TAG_TOP = "mytop";


    //-------------------------------------------



    public static int GetTop()
    {
        if (PlayerPrefs.HasKey(TAG_TOP))
        {
            return PlayerPrefs.GetInt(TAG_TOP);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveTop(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_TOP, newHightScore);
    }



    public static int GetHightSecond()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTSECOND))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTSECOND);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveHightSecond(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTSECOND, newHightScore);
    }



    public static string GetMac()
    {
        if (PlayerPrefs.HasKey(TAG_MAC))
        {
            return PlayerPrefs.GetString(TAG_MAC);
        }
        else
        {
            return "";
        }
    }

    public static void SaveMac(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_MAC, newHightScore);
    }

    //----------------------------------------------------

    public static string GetName()
    {
        if (PlayerPrefs.HasKey(TAG_NAME))
        {
            return PlayerPrefs.GetString(TAG_NAME);
        }
        else
        {
            return "";
        }
    }

    public static void SaveName(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_NAME, newHightScore);
    }


    public static int GetHightScore()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTSCORE))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTSCORE);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveHightScore(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTSCORE, newHightScore);
    }


 

}