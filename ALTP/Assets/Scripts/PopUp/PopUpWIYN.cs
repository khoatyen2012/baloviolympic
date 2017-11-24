using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopUpWIYN : MonoBehaviour {

    public tk2dUIItem btnOK;
    public tk2dUIItem btnCancel;
     public InputField myName;

    private string mynameShow = "";
    private string sk;

    void btnOk_OnClick()
    {
        try
        {
            sk = "" + myName.text;
            if (sk.Length > 40)
            {
                sk = sk.Substring(0, 39);
            }
            int i = sk.IndexOf(" ", 0);
            while (i >= 0 && i < sk.Length)
            {
                sk = sk.Replace(" ", "_");
                i = sk.IndexOf(" ", i);
            }

            if (!sk.Trim().Equals(""))
            {
       

         
                tk2dUIDemo5Controller.instance.getSetData(sk);
            }
        }
        catch
        {

        }
    }

    void btnCancel_OnClick()
    {
        try
        {
        tk2dUIDemo5Controller.instance.HideWYN();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

	// Use this for initialization
	void Start () {



        mynameShow = "" + DataController.GetName();
        myName.text = "" + mynameShow;

        btnOK.OnClick += btnOk_OnClick;
        btnCancel.OnClick += btnCancel_OnClick;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
