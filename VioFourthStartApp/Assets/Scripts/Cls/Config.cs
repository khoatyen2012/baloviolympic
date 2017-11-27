using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
       public static string adsInIDGameOver = "ca-app-pub-5148482490300491/2810940969";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/2810940969";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/2810940969";
     public static string hedieuhanh="ios4";
   

#endif

#if UNITY_ANDROID


    public static string adsInIDGameOver = "ca-app-pub-5148482490300491/1537085763";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/3013818961";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/6159811067";
                         public static string hedieuhanh = "android4";

#endif

}
