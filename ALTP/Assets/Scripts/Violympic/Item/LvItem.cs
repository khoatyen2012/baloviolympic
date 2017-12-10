using UnityEngine;
using System.Collections;

public class LvItem : MonoBehaviour {

    private tk2dSprite spiteLv;

    private GameObject txtSp;
    private tk2dTextMesh txtMesh;
    private tk2dSprite spiteRate;
    private tk2dUIItem itemLevel;
    public int giatri = 1;

    void Awake()
    {
        spiteLv = this.gameObject.GetComponent<tk2dSprite>();
        txtSp = this.gameObject.transform.GetChild(1).gameObject;
        txtMesh = txtSp.GetComponent<tk2dTextMesh>();
        spiteRate = this.gameObject.transform.GetChild(0).GetComponent<tk2dSprite>();
        itemLevel = this.gameObject.GetComponent<tk2dUIItem>();
    }

    public void setData(int gt)
    {
        giatri = gt;
		if (gt > (VioGameController.instance.vuotqua + 1))
        {
            spiteLv.SetSprite("levellock");
            txtSp.SetActive(false);
            spiteRate.gameObject.SetActive(false);
            spiteLv.color = new Color(1, 1, 1, 1);
           
        }
        else
        {
            spiteRate.gameObject.SetActive(true);
            spiteLv.SetSprite("levelopen");
            txtSp.SetActive(true);
            txtMesh.text = "" + gt;
            spiteLv.color = new Color(1, 1, 0, 1);
			if (gt == (VioGameController.instance.vuotqua + 1))
            {
                spiteRate.SetSprite("khongsao");
            }
            else
            {
				if (int.Parse(VioGameController.instance.mang[gt - 1]) >=180)
                {
                    spiteRate.SetSprite("basao");
                }
				else if (int.Parse(VioGameController.instance.mang[gt - 1]) > 150)
                {
                    spiteRate.SetSprite("haisao");
                }
                else
                {
                    spiteRate.SetSprite("motsao");
                }
            }
        }
    }

    void btnItem_onClick()
    {
       
		if ((VioGameController.instance.vuotqua + 1) >= giatri)
        {
			VioGameController.instance.level = giatri;
			VioPopUpController.instance.HideLevel();
            VioPopUpController.instance.ShowStartGame();
			VioGameController.instance.ckResetLv = true;
            SoundController.Instance.PlayClick();
            if (VioGameController.instance.checkvip != 10)
            {
                AdManager.instance.HideBaner();
            }
        }
    }

	// Use this for initialization
	void Start () {
        itemLevel.OnClick += btnItem_onClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
