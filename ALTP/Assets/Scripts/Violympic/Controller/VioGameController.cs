using UnityEngine;
using System.Collections;

public class VioGameController : MonoBehaviour {


	public bool tienganh = true;
	public int level = 1;
	public int vuotqua = 0;
	public bool ckResetLv = true;
	public string[] mang;
	public string stSumcoin = "";


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
	}


	IEnumerator WaitTimeLoadData(float time)
	{
		yield return new WaitForSeconds(time);

		VioPopUpController.instance.HideLevel();
		VioPopUpController.instance.HideLoading();

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
		VioPopUpController.instance.ShowStartDinhNui (1);
	}

	// Use this for initialization
	void Start () {
	
		stSumcoin = DataManager.GetHightStringCoin();
		mang = stSumcoin.Split('+');
		StartCoroutine(WaitTimeLoadData(2f));

	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
