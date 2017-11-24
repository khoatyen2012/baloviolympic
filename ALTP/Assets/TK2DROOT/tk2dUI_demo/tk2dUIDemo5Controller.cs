using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;
using GoogleMobileAds.Api;



public class tk2dUIDemo5Controller : tk2dUIBaseDemoController {

	public tk2dUILayout prefabItem;

	// Manually set up a scrollable area by working out offsets manually
	public tk2dUIScrollableArea manualScrollableArea;
    public tk2dUIItem btnBack;
    public GameObject WYN;
    public tk2dTextMesh txtName;
    public tk2dTextMesh txtCoin;
    public tk2dTextMesh txtLoading;

    private string mymac = "";
    private string myname = "";
    private int myCoin;
    private int mySecond;
    private int mytop;
    string url = "http://ailatrieuphu.somee.com/Service.asmx/gettop?sha=ai.la.trieu.phu.altp.tiengbuivanban";
    List<AltpUser> lst = new List<AltpUser>();
    InterstitialAd interstitial;

    #region Singleton
    private static tk2dUIDemo5Controller _instance;

    public static tk2dUIDemo5Controller instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<tk2dUIDemo5Controller>();
            return _instance;
        }
    }
    #endregion


    private void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInID);
        // Create an empty ad request.
        AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("54829CBF8D1115A66940C3B0C88A9B7E").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }

    private void ShowAdsInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HideAdsInterstitial()
    {
        interstitial.Destroy();
    }

    void btnBack_OnClick()
    {
        Application.LoadLevel("InGame");
    }

    public void HideWYN()
    {
        WYN.SetActive(false);
        StartCoroutine(WaitForRequest());
        txtName.text = "" + myname;
        txtCoin.text = "Top:" + mytop;
        int chon = UnityEngine.Random.Range(0, 4);
        if (chon == 0)
        {
            ShowAdsInterstitial();
        }
    }

    public void getSetData(string name)
    {
        if (name.Trim().Equals(""))
        {
        }
        else
        {
            myname = name;
        }

        if (!myname.Trim().Equals(""))
        {
        
            string check = "" + getPosive(mymac, "" + myCoin, "" + mySecond, myname, "ai.la.trieu.phu.altp.tiengbuivanban");
            StartCoroutine(WaitForRequestPosive(check));
            DataController.SaveName(myname);

        }

        HideWYN();
    }

    IEnumerator WaitForRequestPosive(string checkhang)
    {
        WWW www = new WWW(checkhang);

        yield return www;
        // check for errors

        if (www.error == null)
        {



            string tmg = "" + www.text;

            mytop = int.Parse(tmg.Trim())+1;
            DataController.SaveTop(mytop);

            txtCoin.text = "Top:" + mytop;
 

        }
        else
        {

            txtCoin.text = "Not Connected";
   
        }

    }


    void getInfoData()
    {

        myname = "" + DataController.GetName();
        mymac = "" + DataController.GetMac();
        mySecond = DataController.GetHightSecond();
        myCoin = DataController.GetHightScore();
        mytop = DataController.GetTop();


        if (mymac.Trim().Equals(""))
        {
            mymac = "" + GetUniqueIdentifier();
            DataController.SaveMac("" + mymac);
        }

    }

    private string getPosive(string pMac, string pCoin,string pSecond, string pName, string sha)
    {
        string urls = "http://ailatrieuphu.somee.com/Service.asmx/updateMac?pMac=" + pMac + "&pCoin=" + pCoin + "&pSecond=" +pSecond+ "&pName=" + pName + "&sha=" + sha;
        return urls;
    }

    public static string GetUniqueIdentifier()
    {
        System.Guid uid = System.Guid.NewGuid();
        return uid.ToString();
    }


    void CustomizeListObject(Transform contentRoot, int ip, string name, string coin,string second)
    {

        contentRoot.Find("ID").GetComponent<tk2dTextMesh>().text = "Top:" + ip;
        contentRoot.Find("Name").GetComponent<tk2dTextMesh>().text = "" + name;
        contentRoot.Find("COIN").GetComponent<tk2dTextMesh>().text =  coin+" Câu-"+second+" Giây";
       
		
	}

    IEnumerator WaitForRequest()
    {
        WWW www = new WWW(url);

        yield return www;
        // check for errors

        if (www.error == null)
        {

          
            ParseAccessData(www.text);

            txtLoading.transform.gameObject.SetActive(false);

        }
        else
        {
            txtLoading.text = "Not Connected";
        }

    }

    void ParseAccessData(string wtxt)
    {

        try
        {


            JsonData data = JsonMapper.ToObject(wtxt);

            for (int i = 0; i < data.Count; i++)
            {
                if (int.Parse("" + data[i]["Coin"]) > 500)
                {
                    continue;
                }
                AltpUser cb = new AltpUser();
                cb.Stt = "" + (i + 1);
                cb.Name = "" + data[i]["Name"];

             

                cb.Coin = "" + data[i]["Coin"];
                cb.Second = "" + data[i]["Second"];

                lst.Add(cb);
            }

           


            doLoadData();

        }
        catch
        {

        }






    }

    void doLoadData()
    {
        prefabItem.transform.parent = null;
        DoSetActive(prefabItem.transform, false);

        // Disable the prefab item
        // don't want it visible when the game is running, as it is in the scene
        prefabItem.transform.parent = null;
        DoSetActive(prefabItem.transform, false);

        // Add a bunch of items to the manual list
        // You will need to parent the object manually and then calculate the step
        float x = 0;
        float w = (prefabItem.GetMaxBounds() - prefabItem.GetMinBounds()).y;
        for (int i = 0; i < lst.Count; ++i)
        {
            tk2dUILayout layout = Instantiate(prefabItem) as tk2dUILayout;
            layout.transform.parent = manualScrollableArea.contentContainer.transform;
            layout.transform.localPosition = new Vector3(0, x, 0);
            DoSetActive(layout.transform, true);
            CustomizeListObject(layout.transform, (i + 1), lst[i].Name, lst[i].Coin,lst[i].Second);
            x -= w;
        }
    }

	void Start () {

        getInfoData();
	

        btnBack.OnClick += btnBack_OnClick;
        LoadAdsInterstitial();

 

	
	}


	
}
