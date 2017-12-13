using System.IO;
using UnityEngine;
using System.Collections;

public class ReadText {

    public static string readTextFile(string sText)
    {
    
        string kq = "";
        TextAsset ta = (TextAsset)Resources.Load(sText);
        kq = ta.text;
        return kq;
        
    }

    	// Use this for initialization

}
