using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class GameController : MonoBehaviour {

    string sText = "databasez";
    List<AiLaTrieuPhu> lst = new List<AiLaTrieuPhu>();
    public tk2dTextMesh txtQuestion;
    public tk2dTextMesh txtDAA;
    public tk2dTextMesh txtDAB;
    public tk2dTextMesh txtDAC;
    public tk2dTextMesh txtDAD;
    public tk2dTextMesh txtTime;
    public int level = 1;
    public int truecase;
    public int selectCase;
    int maxlevel = 0;

    public int dTime = 60;
    int demframe = 0;
    public tk2dSprite spLaiVanSam;

 

    

    public enum State
    {
        Start,
        Question,
        Reply,
        Help,
        GameOver,
        AdVideo

    }

    public State currentState;


    #region Singleton
    private static GameController _instance;

    public static GameController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GameController>();
            return _instance;
        }
    }
    #endregion


    void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = -1;
    }
    
	// Use this for initialization
    void Start()
    {
        string ss = ReadText.readTextFile(sText);
        GetDaTa(ss);

        maxlevel = DataController.GetHightScore();
   
        SoundController.Instance.PlayBatDau();

       
  
        //suget();
        StartCoroutine(WaitTimeLoadData(5f));
     
       
    }

    IEnumerator WaitTimeLoadData(float mtime)
    {
        yield return new WaitForSeconds(mtime);
        PopupController.instance.HideSHA();
    }



 

    IEnumerator WaitTimeVuot14(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);


        if (level == 14)
        {
            SoundController.Instance.PlayVuotQua14();
            nextgame(7f);
        }
     

    }

    void nextgame(float ss)
    {
        level++;
        StartCoroutine(WaitTimeNextLevel(ss));
    }

    IEnumerator WaitTimeWin(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        SoundController.Instance.PlayCamXuc();
        PopupController.instance.ShowPopUpWin();


    }

    IEnumerator WaitTimeCau10(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        SoundController.Instance.PlayCamXuc();
        nextgame(7f);

    }

  public  void doXuLy()
    {
        SoundController.Instance.Stop();
        if (truecase == selectCase)
        {
            LevelController.instance.nhapnhay();
            setLaiVanSam("traloidung");
            if (level > maxlevel)
            {
                maxlevel = level;
            
                DataController.SaveHightScore(maxlevel);
                DataController.SaveHightSecond(dTime);
            }

            if (level == 15)
            {
                SoundController.Instance.PlayVuotQua15();
                //se xu ly ket thuc o day
                StartCoroutine(WaitTimeWin(7f));
            }
            else
            {
                if (truecase == 1)
                {
                    SoundController.Instance.PlayDungA();

                }
                if (truecase == 2)
                {
                    SoundController.Instance.PlayDungB();
                }
                if (truecase == 3)
                {
                    SoundController.Instance.PlayDungC();
                }

                if (truecase == 4)
                {
                    SoundController.Instance.PlayDungD();
                }

                if (level == 14)
                {
                    StartCoroutine(WaitTimeVuot14(3f));
                }
                else
                {
                    if (level == 10)
                    {
                        StartCoroutine(WaitTimeCau10(3f));
                    }
                    else
                    {
                        nextgame(5f);
                    }
                  
                }
            }

         


        

         
        }
        else
        {
            setLaiVanSam("traloisai");
            if (truecase == 1)
            {
                SoundController.Instance.PlaySaiA();
            }
            if (truecase == 2)
            {
                SoundController.Instance.PlaySaiB();
            }
            if (truecase == 3)
            {
                SoundController.Instance.PlaySaiC();
            }

            if (truecase == 4)
            {
                SoundController.Instance.PlaySaiD();
            }

            currentState = State.GameOver;
            StartCoroutine(WaitTimeGameOver(4f));
        }
    }

  IEnumerator WaitTimeGameOver(float time)
  {
      //do something...............
      yield return new WaitForSeconds(time);

     
      PopupController.instance.ShowPopupGameOver(level-1,maxlevel);
		AdStartApp.instance.ShowBanner ();

     

  }

  IEnumerator WaitTimeNextLevel(float time)
  {
      //do something...............
      yield return new WaitForSeconds(time);

      DapAnController.instance.resetDapAN();
      currentState = State.Question;
      suget();
  
      


  }

  IEnumerator WaitTimeQuanTrong(float time)
  {
      //do something...............
      yield return new WaitForSeconds(time);
      SoundController.Instance.Stop();
      if (currentState == State.Question)
      {
          
          SoundController.Instance.PlayQuanTrong();
      }

  }

  public void setDefault()
  {
      level = 1;

      currentState = State.Question;

 
  }

    public void suget()
    {
        List<AiLaTrieuPhu> lstTMG = new List<AiLaTrieuPhu>();
        foreach (AiLaTrieuPhu item in lst)
        {
            if (int.Parse(item.Level) != level)
            {
                continue;
            }
            lstTMG.Add(item);
        }

        int chon = UnityEngine.Random.Range(0, lstTMG.Count - 1);

        txtQuestion.text = "Câu "+level+": " + lstTMG[chon].Question;
        txtDAA.text = "A."  +lstTMG[chon].Casea;
        txtDAB.text = "B." + lstTMG[chon].Caseb;
        txtDAC.text = "C." + lstTMG[chon].Casec;
        txtDAD.text = "D." + lstTMG[chon].Cased;
        truecase = int.Parse(lstTMG[chon].Truecase);

        if (level == 1)
        {
            SoundController.Instance.PlayHoi1();
        }

        if (level == 2)
        {
            SoundController.Instance.PlayHoi2();
        }

        if (level == 3)
        {
            SoundController.Instance.PlayHoi3();
        }

        if (level == 4)
        {
            SoundController.Instance.PlayHoi4();
        }

        if (level == 5)
        {
            SoundController.Instance.PlayHoi5();
            

            StartCoroutine(WaitTimeQuanTrong(3f));
        }

        if (level == 6)
        {
            SoundController.Instance.PlayHoi6();
        }

        if (level == 7)
        {
            SoundController.Instance.PlayHoi7();
        }

        if (level == 8)
        {
            SoundController.Instance.PlayHoi8();
        }

        if (level == 9)
        {
            SoundController.Instance.PlayHoi9();
        }
        if (level == 10)
        {
            SoundController.Instance.PlayHoi10();
            StartCoroutine(WaitTimeQuanTrong(2f));
        }
        if (level == 11)
        {
            SoundController.Instance.PlayHoi11();
        }
        if (level == 12)
        {
            SoundController.Instance.PlayHoi12();
        }
        if (level == 13)
        {
            SoundController.Instance.PlayHoi13();
        }
        if (level == 14)
        {
            SoundController.Instance.PlayHoi14();
        }
        if (level == 15)
        {
            SoundController.Instance.PlayHoi15();
      
        }
       

        LevelController.instance.setEmptyChild(level);
        dTime = 60;
        demframe = 0;
        txtTime.color = new Color(1, 1, 1, 1);
        txtTime.text = "" + dTime;
        setLaiVanSam("hoi");

    }

    public void setLaiVanSam(string caij)
    {
        spLaiVanSam.SetSprite(caij);
    }


    public void helpNamMuoi()
    {
        List<int> tmgList = new List<int>();
        for (int i = 1; i <= 4; i++)
        {
            if (i != truecase)
            {
                tmgList.Add(i);
            }
        }
        int chon = UnityEngine.Random.Range(0, tmgList.Count);
        tmgList.Remove(chon);
        LoaiPhuongAnSai(tmgList[0]);
        LoaiPhuongAnSai(tmgList[1]);

        doPhuongAnSai(tmgList[0], tmgList[1]);


    }

    void doPhuongAnSai(int k, int p)
    {
        if (k == 1)
        {
            if (p == 2)
            {
                SoundController.Instance.PlayAB();
            }

            if (p == 3)
            {
                SoundController.Instance.PlayAC();
            }

            if (p == 4)
            {
                SoundController.Instance.PlayAD();
            }
        }
        else if (k == 2)
        {
            if (p == 3)
            {
                SoundController.Instance.PlayBC();
            }

            if (p == 4)
            {
                SoundController.Instance.PlayBD();
            }
        }
        else
        {
            if (p == 4)
            {
                SoundController.Instance.PlayCD();
            }
        }
    }

    void LoaiPhuongAnSai(int k)
    {
        if (k == 1)
        {
            txtDAA.text = "";
        }
        else if (k == 2)
        {
            txtDAB.text = "";
        }
        else if (k == 3)
        {
            txtDAC.text = "";
        }
        else
        {
            txtDAD.text = "";
        }
        currentState = State.Question;
    }

    void GetDaTa(string tmg)
    {
        string[] mang = tmg.Trim().Split('}');
        for (int i = 0; i < mang.Length-1; i++)
        {
            string[] items = mang[i].Split('^');
          //  Debug.Log("" + items[0] + ":" + items[1] + ":" + items[2] + ":" + items[3] + ":" + items[4] + ":" + items[5] + ":" + items[6] + ":" + items[7]);
            AiLaTrieuPhu altp = new AiLaTrieuPhu();
            altp.Id = "" + items[0];
            altp.Question = "" + items[1];
            altp.Level = "" + items[2];
            altp.Casea = "" + items[3];
            altp.Caseb = "" + items[4];
            altp.Casec = "" + items[5];
            altp.Cased = "" + items[6];
            altp.Truecase = "" + items[7];
            lst.Add(altp);
        }
    }






    // Update is called once per frame
    void Update()
    {

      

        if (currentState == State.Question || currentState == State.Help)
        {
            if (demframe < 30)
            {
                demframe++;
            }
            else
            {
                dTime--;
                txtTime.text = "" + dTime;
                if (dTime <= 10)
                {
                    txtTime.color = new Color(1, 0, 1, 1);
                }
              
                demframe = 0;
                if (dTime <= 0)
                {
                    setLaiVanSam("traloisai");
                    currentState = State.GameOver;
                    PopupController.instance.ShowPopupGameOver(level-1, maxlevel);
                    SoundController.Instance.PlayHetGio();
                }
            }
            
        }
	}
}
