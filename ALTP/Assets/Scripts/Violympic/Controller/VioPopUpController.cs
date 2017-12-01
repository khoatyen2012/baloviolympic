using UnityEngine;
using System.Collections;

public class VioPopUpController : MonoBehaviour {


	#region Singleton
	private static VioPopUpController _instance;

	public static VioPopUpController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<VioPopUpController>();
			return _instance;
		}
	}
	#endregion


	public float showY;
	public float hideY;   

	public float moveSpeed;

	public VioMainGame maingame;
	public GameObject loading;
	public VioLevelController level;
	public StartGame startgame;
	public StartDinhNui startdinhnui;
	public QuestionDN questionDn;
	public StopDinhNui stopDN;
	public GameObject startthongthai;


	public void ShowStartThongThai()
	{

		StartCoroutine(ieMoveDown(startthongthai, showY));
	}
	public void HideStartThongThai()
	{
		StartCoroutine(ieMoveUp(startthongthai, hideY));
	}



	public void ShowStopDinhNui(int diem,string time)
	{
		stopDN.setData(diem, time);

		StartCoroutine(ieMoveDown(stopDN.gameObject, showY));
	}
	public void HideStopDinhNui()
	{
		StartCoroutine(ieMoveUp(stopDN.gameObject, hideY));
	}

	public void ShowQuestionDinhNui()
	{

		questionDn.getDataLevel();
		StartCoroutine(ieMoveDown(questionDn.gameObject, showY));
	}
	public void HideQuestionDinhNui()
	{
		StartCoroutine(ieMoveUp(questionDn.gameObject, hideY));
	}

	public void ShowStartDinhNui(int lesson)
	{
		startdinhnui.setData(lesson);
		StartCoroutine(ieMoveDown(startdinhnui.gameObject, showY));
	}
	public void HideStartDinhNui()
	{
		StartCoroutine(ieMoveUp(startdinhnui.gameObject, hideY));
	}

	public void ShowStartGame()
	{
		startgame.setData();
		StartCoroutine(ieMoveDown(startgame.gameObject, showY));
	}
	public void HideStartGame()
	{
		StartCoroutine(ieMoveUp(startgame.gameObject, hideY));
	}


	public void ShowLevel()
	{
		level.resetData();
		StartCoroutine(ieMoveDown(level.gameObject, showY));
	}
	public void HideLevel()
	{

		StartCoroutine(ieMoveUp(level.gameObject, hideY));
	}


	public void HideLoading()
	{
		StartCoroutine(ieMoveUp(loading, hideY));
	}


	public void ShowMainGame()
	{
		maingame.setData();
		StartCoroutine(ieMoveDown(maingame.gameObject, showY));
	}
	public void HideMainGame()
	{
		StartCoroutine(ieMoveUp(maingame.gameObject, hideY));
	}


	IEnumerator ieMoveDown(GameObject popup, float SY)
	{
		while (popup.transform.position.y >= SY)
		{
			popup.transform.position += Vector3.down
				* (moveSpeed)
				* Time.deltaTime;
			yield return 0;
		}
		popup.transform.position = new Vector3(popup.gameObject.transform.position.x, SY, popup.gameObject.transform.position.z);

	}

	IEnumerator ieMoveUp(GameObject popup, float HY)
	{
		while (popup.transform.position.y <= HY)
		{
			popup.transform.position += Vector3.up
				* (moveSpeed)
				* Time.deltaTime;
			yield return 0;
		}
		popup.transform.position = new Vector3(popup.gameObject.transform.position.x, HY, popup.gameObject.transform.position.z);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
