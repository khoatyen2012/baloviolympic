using UnityEngine;
using System.Collections;

public class PopUpNguoiThan : MonoBehaviour {

    public tk2dUIItem btnBanThan;
    public tk2dUIItem btnBanDeu;
    public tk2dUIItem btnHangXom;
    public tk2dUIItem btnDongNghiep;
    public tk2dUIItem btnNguoiNha;
    public tk2dUIItem btnBoBich;
    public tk2dUIItem btnContinute;
    public tk2dTextMesh txtCauHoi;
    public tk2dTextMesh txtTraLoi;
    private tk2dSprite sprite;

    void btnBanThan_OnClick()
    {
        ketNoi(1);
    }
    void btnBanDeu_OnClick()
    {
        ketNoi(2);
    }
    void btnHangXom_OnClick()
    {
        ketNoi(3);
    }
    void btnDongNghiep_OnClick()
    {
        ketNoi(4);
    }
    void btnNguoiNha_OnClick()
    {
        ketNoi(5);
    }
    void btnBoBich_OnClick()
    {
        ketNoi(6);
    }

    public void resetNguoiThan()
    {
        sprite.SetSprite("banthan");
        btnBanDeu.gameObject.SetActive(true);
        btnHangXom.gameObject.SetActive(true);
        btnDongNghiep.gameObject.SetActive(true);
        btnNguoiNha.gameObject.SetActive(true);
        btnBoBich.gameObject.SetActive(true);
        btnBanThan.gameObject.GetComponent<BoxCollider>().enabled = true;
        btnContinute.gameObject.SetActive(false);
        txtTraLoi.gameObject.SetActive(false);
    }
    void btnContinute_OnClick()
    {
        GameController.instance.currentState = GameController.State.Question;
        PopupController.instance.HidePopupNguoiThan();
        DapAnController.instance.doSetEnabal(true);
        resetNguoiThan();
    }

    void ketNoi(int k)
    {
        try
        {
            SoundController.Instance.PlayGoiNguoiThan();
            if (k == 2)
            {
                sprite.SetSprite("bandeu");
            }
            else if (k == 3)
            {
                sprite.SetSprite("hangxom");
            }
            else if (k == 4)
            {
                sprite.SetSprite("dongnghiep");
            }
            else if (k == 5)
            {
                sprite.SetSprite("nguoinha");
            }
            else if (k == 6)
            {
                sprite.SetSprite("bobich");
            }
            btnBanDeu.gameObject.SetActive(false);
            btnHangXom.gameObject.SetActive(false);
            btnDongNghiep.gameObject.SetActive(false);
            btnNguoiNha.gameObject.SetActive(false);
            btnBoBich.gameObject.SetActive(false);
            btnBanThan.gameObject.GetComponent<BoxCollider>().enabled = false;

            StartCoroutine(WaitTimeGoiDien(3f));

        }
        catch (System.Exception)
        {

            throw;
        }
    }

    IEnumerator WaitTimeGoiDien(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        btnContinute.gameObject.SetActive(true);
        txtTraLoi.gameObject.SetActive(true);
        txtCauHoi.text = "Câu trả lời của người thân !";

        int k = GameController.instance.truecase;
        int lv = GameController.instance.level;
        int chon = Random.Range(0, 17 - lv);
        string dapan = "";
        if (k == 1)
        {
            dapan = "A";
        }
        else if (k == 2)
        {
            dapan = "B";
        }
        else if (k == 3)
        {
            dapan = "C";
        }
        else
        {
            dapan = "D";
        }


        if (chon >1)
        {
            if (chon == 2)
            {
                txtTraLoi.text = "Theo mình thì là đáp án "+dapan;
            }
            else if (chon == 3)
            {
                txtTraLoi.text = "Theo tôi thì là đáp án " + dapan;
            }
            else if (chon == 4)
            {
                txtTraLoi.text =" Đáp án " + dapan+" nhé !";
            } else if (chon == 5)
            {
                txtTraLoi.text = "Hình như là đáp án " + dapan;
            } else if (chon == 6)
            {
                txtTraLoi.text ="Có vẻ như là đáp án " + dapan+" nhé !";
            }
            else if (chon == 7)
            {
                txtTraLoi.text = dapan + " nhé !";
            }
            else
            {
                txtTraLoi.text = " Đáp án " + dapan + " là đáp án đúng !";
            }
        }
        else
        {
            if (chon == 0)
            {
                txtTraLoi.text = "Câu hỏi này khó quá mình không biết ! ";
            }
            else
            {
                int chonlai = Random.Range(1, 5);
                if (chonlai == 1)
                {
                    dapan = "A";
                }
                else if (chonlai == 2)
                {
                    dapan = "B";
                }
                else if (chonlai == 3)
                {
                    dapan = "C";
                }
                else
                {
                    dapan = "D";
                }
                txtTraLoi.text = " Đáp án " + dapan + " là đáp án đúng !";
            }
        }

    }

	// Use this for initialization
	void Start () {
           btnBanThan.OnClick+=btnBanThan_OnClick;
	       btnBanDeu.OnClick+=btnBanDeu_OnClick;
           btnHangXom.OnClick += btnHangXom_OnClick;
           btnDongNghiep.OnClick += btnDongNghiep_OnClick;
           btnNguoiNha.OnClick += btnNguoiNha_OnClick;
           btnBoBich.OnClick += btnBoBich_OnClick;
           btnContinute.OnClick += btnContinute_OnClick;
        sprite=btnBanThan.gameObject.GetComponent<tk2dSprite>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
