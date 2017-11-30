using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnDiemCao;

    void btnContinute_OnClick()
    {

        PopupController.instance.ShowSHA();
        SoundController.Instance.Stop();
        SoundController.Instance.PlayChungTa();
        PopupController.instance.HideMainGame();
        StartCoroutine(WaitTimeSHA(4f));
    
    }

    IEnumerator WaitTimeSHA(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        PopupController.instance.HideSHA();
        GameController.instance.suget();
        GameController.instance.currentState = GameController.State.Question;


    }

    void btnDiemCao_OnClick()
    {
        Application.LoadLevel("Rank");
    }

	// Use this for initialization
	void Start () {
        btnDiemCao.OnClick += btnDiemCao_OnClick;
        btnContinute.OnClick += btnContinute_OnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
