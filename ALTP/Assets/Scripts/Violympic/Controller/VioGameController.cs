using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class VioGameController : MonoBehaviour {


	public bool tienganh = true;
	public int level = 1;
	public int vuotqua = 0;
	public bool ckResetLv = true;
	public string[] mang;
	public string stSumcoin = "";
	public List<DinhNui> lstSum = new List<DinhNui>();
	public List<ThongThai> lstThongThai = new List<ThongThai>();
	public int checkvip = 0;
	public int sumCoin = 0;
	public int sumTime;


	#region Singleton
	private static VioGameController _instance;

	public static VioGameController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<VioGameController>();
			return _instance;
		}
	}
	#endregion

	void Awake()
	{
		Application.targetFrameRate = 30;
		QualitySettings.vSyncCount = -1;

		vuotqua = DataManager.GetHightLevel();
		level = vuotqua + 1;
		tienganh = CheckNgonNgu ();
		checkvip = DataManager.GetVip();
	}


	IEnumerator WaitTimeLoadData(float time)
	{
		yield return new WaitForSeconds(time);

		VioPopUpController.instance.HideLevel();
		VioPopUpController.instance.HideLoading();

		//Dinh Nui
		TextAsset txt;
		if (tienganh)
		{
			txt = (TextAsset)Resources.Load("dinhnuien", typeof(TextAsset));
		}
		else
		{
			txt = (TextAsset)Resources.Load("dinhnuivi", typeof(TextAsset));
		}
		string content = txt.text;
		GetDaTa(content);



		//THong Thai
		TextAsset txtTT;
		if (tienganh)
		{
			txtTT = (TextAsset)Resources.Load("khobauen", typeof(TextAsset));
		}
		else
		{
			txtTT = (TextAsset)Resources.Load("khobauvi", typeof(TextAsset));
		}
		string contentTT = txtTT.text;
		GetDaTaThongThai(contentTT);

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

	public void ShowLevel1()
	{
		//VioPopUpController.instance.ShowStartDinhNui (1);
        VioPopUpController.instance.ShowStartThongThai();
	}
	public void ShowLevel2()
	{
		VioPopUpController.instance.ShowStartThongThai ();
	}

	void GetDaTa(string tmg)
	{
		string[] mang = tmg.Trim().Split('&');
		//Debug.Log("KK:"+mang[mang.Length-2]);


		for (int i = 0; i < mang.Length - 1; i++)
		{

			string[] items = mang[i].Split('@');
			DinhNui dn = new DinhNui(items[1], items[2], items[3], items[4], items[5], int.Parse(items[6]), items[7], int.Parse(items[8]));
			lstSum.Add(dn);


		}


	}

	void GetDaTaThongThai(string tmg)
	{
		string[] mang = tmg.Trim().Split('&');
		//Debug.Log("KK:"+mang[mang.Length-2]);


		for (int i = 0; i < mang.Length - 1; i++)
		{
			string[] items = mang[i].Split('@');
			ThongThai tt = new ThongThai (items [1], int.Parse(items [2]), items [3],int.Parse(items[4]));
			lstThongThai.Add (tt);
		}
	}

	// Use this for initialization
	void Start () {
	
		stSumcoin = DataManager.GetHightStringCoin();
		mang = stSumcoin.Split('+');
		StartCoroutine(WaitTimeLoadData(3f));

	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
