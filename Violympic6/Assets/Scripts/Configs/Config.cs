using UnityEngine;
using System.Collections;

public class Config  {

#if UNITY_IPHONE
       public static string adsID = "ca-app-pub-2127327600096597/8097963269";
    public static string adsInID = "ca-app-pub-2127327600096597/2550957266";


#endif

#if UNITY_ANDROID

    public static string appId = "ca-app-pub-5148482490300491~9904638392";

    public static string adsID = "ca-app-pub-5148482490300491/5396038437";
    public static string adsInID = "ca-app-pub-5148482490300491/5204466745";


#endif

}
