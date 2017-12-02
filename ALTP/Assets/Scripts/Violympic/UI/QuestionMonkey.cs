using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionMonkey : MonoBehaviour {


	public enum State
	{
		Start,
		InGame,
		Click,
		XuLyT,
		XyLyF,
		Stop
	}

	public State currentState;

	public List<ThongThai> lstLevel = new List<ThongThai>();


	public void getDataLevel()
	{

		foreach (ThongThai item in VioGameController.instance.lstThongThai)
		{
			if (item.Level == VioGameController.instance.level)
			{
				lstLevel.Add(item);
			}
		}

		//doSubGet(ref lstLevel);
		currentState = State.InGame;

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
