using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    #region Singleton
    private static GameController _instance;

    public static GameController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GameController>();
            return _instance;
        }
    }
    #endregion

    public int sumCoin = 0;
    public int sumTime;
    public int level = 1;
    public int vuotqua = 0;
    public bool tienganh = true;
    public List<DinhNui> lstSum = new List<DinhNui>();
   
    public List<PhepToan> lstPhepToan = new List<PhepToan>();


    public string stSumcoin = "";
    public string[] mang;
    public bool ckResetLv = true;
    public int checkvip = 0;

    void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = -1;
    
        tienganh = CheckNgonNgu();
     
        vuotqua = DataManager.GetHightLevel();
        level = vuotqua + 1;
        checkvip = DataManager.GetVip();

    }

    void GetDaTaBang(string tmg)
    {
        string[] mang = tmg.Trim().Split('*');
        //Debug.Log("KK:"+mang[mang.Length-2]);


        for (int i = 0; i < mang.Length - 1; i++)
        {
            string[] items = mang[i].Split(',');

            PhepToan pt = new PhepToan(items[0], items[1], items[2]);

            lstPhepToan.Add(pt);
        }


        // Debug.Log("1:" + lst1.Count + "2:" + lst2.Count + "3:" + lst3.Count + "4:" + lst4.Count + "5:" + lst5.Count + "6:" + lst6.Count);

    }

 

    public bool CheckNgonNgu()
    {
        bool ok = true;
        string ngonngu = Application.systemLanguage.ToString().ToLower().Trim();
        if (ngonngu.Equals("vietnamese"))
        {
            ok = false;
        }
        return ok;
    }

    public void ShowLevel3()
    {
        PopUpController.instance.ShowStartThongThai();
    }

    public void ShowLevel2()
    {
        PopUpController.instance.ShowStartDinhNui(2);
      
    }

    public void ShowLevel1()
    {
        if (GameController.instance.level == 5 || GameController.instance.level == 15)
        {
            PopUpController.instance.ShowStartSapXep();
        }
        else if (GameController.instance.level == 14 || GameController.instance.level == 19 || GameController.instance.level == 20)
        {
            PopUpController.instance.ShowStartBangNhau(1);
        }
        else
        {
            int chon = UnityEngine.Random.Range(0, 3);
            if (chon == 0)
            {
                PopUpController.instance.ShowStartSapXep();
            }
            else
            {
                PopUpController.instance.ShowStartBangNhau(1);
            }
        }

       // PopUpController.instance.ShowStartDinhNui(1);
       
    }

    //IEnumerator WaitTimeLoading(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    PopUpController.instance.HideLoading();
    //    PopUpController.instance.HideLevel();
    //}
      void GetDaTa(string tmg)
    {
        string[] mang = tmg.Trim().Split('#');
        //Debug.Log("KK:"+mang[mang.Length-2]);


        for (int i = 0; i < mang.Length - 1; i++)
        {
        
            string[] items = mang[i].Split('*');
            DinhNui dn = new DinhNui(items[1], items[2], items[3], items[4], items[5], int.Parse(items[6]), items[7], int.Parse(items[8]));
            lstSum.Add(dn);
         
           
        }

        
       
        
      }

	// Use this for initialization
	void Start () {


        stSumcoin = DataManager.GetHightStringCoin();
        mang = stSumcoin.Split('+');
        
        StartCoroutine(WaitTimeLoadData());
      
    
	}

    IEnumerator WaitTimeLoadData()
    {
        yield return new WaitForSeconds(0);

        TextAsset txtBang = (TextAsset)Resources.Load("violympic", typeof(TextAsset));
        string data = txtBang.text;
        GetDaTaBang(data);

        PopUpController.instance.HideLoading();
        PopUpController.instance.HideLevel();

        TextAsset txt;
        if (tienganh)
        {
            txt = (TextAsset)Resources.Load("violympica", typeof(TextAsset));
        }
        else
        {
            txt = (TextAsset)Resources.Load("violympicv", typeof(TextAsset));
        }
        string content = txt.text;

        GetDaTa(content);
    }



    // Update is called once per frame
    void Update()
    {
	
	}
}
