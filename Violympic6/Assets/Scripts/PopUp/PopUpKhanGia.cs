using UnityEngine;
using System.Collections;

public class PopUpKhanGia : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dClippedSprite sprProcessA;
    public tk2dClippedSprite sprProcessB;
    public tk2dClippedSprite sprProcessC;
    public tk2dClippedSprite sprProcessD;
    public tk2dTextMesh txtA;
    public tk2dTextMesh txtB;
    public tk2dTextMesh txtC;
    public tk2dTextMesh txtD;

    public void setPhanTram()
    {
        int k = GameController.instance.truecase;
        int lv = GameController.instance.level;
        int chon = Random.Range(0, 18-lv);
        if (chon != 0)
        {
            int ptT = Random.Range(50, 95);
            int ptS1 = Random.Range(0, 101 - ptT);
            int ptS2 = Random.Range(0, 101 - ptT - ptS1);
            int ptS3 = Random.Range(0, 101 - ptT - ptS1 - ptS2);
            float Dung = (float)ptT / 100;
            float sai1 = (float)ptS1 / 100;
            float sai2 = (float)ptS2 / 100;
            float sai3 = (float)ptS3 / 100;

       

            if (k == 1)
            {
                sprProcessA.ClipRect = new Rect(0f, 0f, 1f, Dung);
                sprProcessB.ClipRect = new Rect(0f, 0f, 1f, sai1);
                sprProcessC.ClipRect = new Rect(0f, 0f, 1f, sai2);
                sprProcessD.ClipRect = new Rect(0f, 0f, 1f, sai3);
                txtA.text = ptT + "%";
                txtB.text = ptS1 + "%";
                txtC.text = ptS2 + "%";
                txtD.text = ptS3 + "%";
            }
            else if (k == 2)
            {
                sprProcessB.ClipRect = new Rect(0f, 0f, 1f, Dung);
                sprProcessA.ClipRect = new Rect(0f, 0f, 1f, sai1);
                sprProcessC.ClipRect = new Rect(0f, 0f, 1f, sai2);
                sprProcessD.ClipRect = new Rect(0f, 0f, 1f, sai3);


                txtB.text = ptT + "%";
                txtA.text = ptS1 + "%";
                txtC.text = ptS2 + "%";
                txtD.text = ptS3 + "%";

            }
            else if (k == 3)
            {
                sprProcessC.ClipRect = new Rect(0f, 0f, 1f, Dung);
                sprProcessB.ClipRect = new Rect(0f, 0f, 1f, sai1);
                sprProcessA.ClipRect = new Rect(0f, 0f, 1f, sai2);
                sprProcessD.ClipRect = new Rect(0f, 0f, 1f, sai3);


                txtC.text = ptT + "%";
                txtB.text = ptS1 + "%";
                txtA.text = ptS2 + "%";
                txtD.text = ptS3 + "%";


            }
            else
            {
                sprProcessD.ClipRect = new Rect(0f, 0f, 1f, Dung);
                sprProcessA.ClipRect = new Rect(0f, 0f, 1f, sai1);
                sprProcessC.ClipRect = new Rect(0f, 0f, 1f, sai2);
                sprProcessB.ClipRect = new Rect(0f, 0f, 1f, sai3);

                txtD.text = ptT + "%";
                txtA.text = ptS1 + "%";
                txtC.text = ptS2 + "%";
                txtB.text = ptS3 + "%";
            }

        }
        else
        {
            int ptT = Random.Range(0, 47);
            int ptS1 = Random.Range(0, 101 - ptT);
            int ptS2 = Random.Range(0, 101 - ptT - ptS1);
            int ptS3 = Random.Range(0, 101 - ptT - ptS1 - ptS2);
            float chuabiet1 = (float)ptT / 100;
            float chuabiet2 = (float)ptS1 / 100;
            float chuabiet3 = (float)ptS2 / 100;
            float chuabiet4 = (float)ptS3 / 100;

            sprProcessA.ClipRect = new Rect(0f, 0f,1f, chuabiet1);
            sprProcessB.ClipRect = new Rect(0f, 0f,1f, chuabiet2);
            sprProcessC.ClipRect = new Rect(0f, 0f,1f, chuabiet3);
            sprProcessD.ClipRect = new Rect(0f, 0f, 1f, chuabiet4);

            txtA.text = ptT + "%";
            txtB.text = ptS1 + "%";
            txtC.text = ptS2 + "%";
            txtD.text = ptS3 + "%";
        }

    }

    void btnContinute_OnClick()
    {
        try
        {
            PopupController.instance.HidePopupKhanGia();
            GameController.instance.currentState = GameController.State.Question;
            DapAnController.instance.doSetEnabal(true);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += btnContinute_OnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
