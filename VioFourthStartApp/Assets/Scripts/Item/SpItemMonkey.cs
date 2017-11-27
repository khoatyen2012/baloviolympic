using UnityEngine;
using System.Collections;
using System;

public class SpItemMonkey : MonoBehaviour {


    public string mLoai;
    public double giatri = 1;

    //dung de test

    int vitri = 0;

    public int Vitri
    {
        get { return vitri; }
        set { vitri = value; }
    }

    public double Giatri
    {
        get { return giatri; }
        set { giatri = value; }
    }

    string pheptoan = "";

    public string Pheptoan
    {
        get { return pheptoan; }
        set { pheptoan = value; }
    }

    private bool trangthai = true;

    public bool Trangthai
    {
        get { return trangthai; }
        set { trangthai = value; }
    }

    public void RecycleSp()
    {
        this.Recycle<SpItemMonkey>();
    }



    public void setData(string loai)
    {
        this.gameObject.GetComponent<tk2dSprite>().SetSprite("tablemonkey");
        if (loai.Trim().Equals("number"))
        {

            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = pheptoan;
        }
        else if (loai.Trim().Equals("phanso"))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            if (pheptoan.Contains("/") || pheptoan.Contains(":"))
            {
                string[] mang = pheptoan.Split(new Char[] { '/', ':' });
                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = mang[0];
                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = mang[1];
                int mC = mang[0].Length;
                if (mC < mang[1].Length)
                {
                    mC = mang[1].Length;
                }
                string tam = "";
                for (int i = 0; i < mC; i++)
                {
                    tam += "_";
                }
                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = "" + tam;
            }
        }
        else if (loai.Trim().Equals("phansohai"))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            string dau = "";
            if (pheptoan.Contains("+"))
            {
                dau = "+";
            }
            else if (pheptoan.Contains("-"))
            {
                dau = "-";
            }
            else if (pheptoan.Contains("x"))
            {
                dau = "x";
            }
            else if (pheptoan.Contains(":"))
            {
                dau = ":";
            }
            string[] mang = pheptoan.Split(new Char[] { '-', '+', 'x', ':', '/' });

            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = mang[0];
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).GetComponent<tk2dTextMesh>().text = mang[1];
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(4).GetComponent<tk2dTextMesh>().text = mang[2];
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(5).GetComponent<tk2dTextMesh>().text = mang[3];
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(6).GetComponent<tk2dTextMesh>().text = dau;

            int mC = mang[0].Length;
            if (mC < mang[1].Length)
            {
                mC = mang[1].Length;
            }
            string tam = "";
            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).GetComponent<tk2dTextMesh>().text = tam;

            mC = mang[2].Length;
            tam = "";
            if (mC < mang[3].Length)
            {
                mC = mang[3].Length;
            }

            for (int i = 0; i < mC; i++)
            {
                tam += "_";
            }
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(3).GetComponent<tk2dTextMesh>().text = tam;

        }
        mLoai = loai;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
