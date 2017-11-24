using UnityEngine;
using System.Collections;

public class Config  {

#if UNITY_IPHONE
       public static string adsID = "ca-app-pub-2127327600096597/8097963269";
    public static string adsInID = "ca-app-pub-2127327600096597/2550957266";


#endif

#if UNITY_ANDROID

                         public static string adsID = "ca-app-pub-2127327600096597/2847051268";
    public static string adsInID = "ca-app-pub-2127327600096597/5660916868";


#endif

}
