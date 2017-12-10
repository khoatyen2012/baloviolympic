using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VioLevelController : MonoBehaviour {


	public LvItem lvPrefab;
	public float startX;
	public float distanceX;
	public float startY;
	public float distanceY;



	#region Singleton
	private static VioLevelController _instance;

	public static VioLevelController instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<VioLevelController>();
			return _instance;
		}
	}
	#endregion

	public tk2dUIItem btnBack;
	void onClick_Back()
	{
		VioPopUpController.instance.HideLevel();
		VioPopUpController.instance.ShowMainGame();
        SoundController.Instance.PlayClick();

        if (VioGameController.instance.tienganh)
        {
            if (VioGameController.instance.checkvip != 10)
            {
                AdManager.instance.ShowBanner();
            }
        }
	}

	public void resetData()
	{
		if (VioGameController.instance.ckResetLv == false)
		{
			//remove cây item trống không
			var children = new List<GameObject>();
			foreach (Transform child in this.transform)
			{
				children.Add(child.gameObject);
			}

			foreach (GameObject item in children)
			{
				if (item.CompareTag("nguoi"))
				{
					continue;
				}

				item.GetComponent<LvItem>().setData(item.GetComponent<LvItem>().giatri);
			}
		}
	}

	void CreateItem(float positionX, float positionY, int vitri)
	{

		LvItem levelCreate = lvPrefab.Spawn<LvItem>
			(
				new Vector3(positionX, positionY, 85f),
				lvPrefab.transform.rotation
			);

		levelCreate.setData(vitri);

		levelCreate.transform.parent = this.gameObject.transform;




	}

	public void Createlevl(int sl)
	{
		float positionCreateX = startX;
		float positionCreateY = startY;
		for (int i = 1; i <= sl; i++)
		{
			CreateItem(positionCreateX, positionCreateY, i);
			positionCreateX += distanceX;
			if (i % 5 == 0)
			{
				positionCreateX = startX;
				positionCreateY -= distanceY;
			}
		}
	}

	// Use this for initialization
	void Start () {
		
		btnBack.OnClick += onClick_Back;
		Createlevl(20);

	}

	// Update is called once per frame
	void Update () {

	}
}
