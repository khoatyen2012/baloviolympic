using UnityEngine;
using System.Collections;

public class DapAnController : MonoBehaviour {


    public tk2dUIItem btnA;
    public tk2dUIItem btnB;
    public tk2dUIItem btnC;
    public tk2dUIItem btnD;

    private tk2dSprite spriteA;
    private tk2dSprite spriteB;
    private tk2dSprite spriteC;
    private tk2dSprite spriteD;



    float numColorA = 1f;
    bool nhapnhayok = true;

    #region Singleton
    private static DapAnController _instance;

    public static DapAnController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<DapAnController>();
            return _instance;
        }
    }
    #endregion


    public enum State
    {
        Stop,
        Play

    }

    private State curentNhapNhay;

    void Reply(int k)
    {

        GameController.instance.setLaiVanSam("suyluan");
        GameController.instance.currentState = GameController.State.Reply;
        GameController.instance.selectCase = k;
        doSetEnabal(false);


        StartCoroutine(WaitTimeDuaRa(4.4f));
    }

    IEnumerator WaitTimeDuaRa(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);
        SoundController.Instance.Stop();
        int chon = Random.Range(0, 2);
        if (chon == 0)
        {
            SoundController.Instance.PlayDuaRa2();
        }
        else
        {
            SoundController.Instance.PlayDuaRa1();
        }

        if (GameController.instance.level <= 5)
        {

            StartCoroutine(WaitTimeXuLy(4f));
        }
        else if (GameController.instance.level > 5 && GameController.instance.level <= 10)
        {
            StartCoroutine(WaitTimeXuLy(5f));
        }
        else
        {
            StartCoroutine(WaitTimeXuLy(7f));
        }

    }

    IEnumerator WaitTimeXuLy(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        
        GameController.instance.doXuLy();
        setSprite();
        curentNhapNhay = State.Play;
        


    }

    public void resetDapAN()
    {
        curentNhapNhay = State.Stop;
         numColorA = 1f;
         nhapnhayok = true;
         doSetEnabal(true);
         spriteA.SetSprite("select");
         spriteB.SetSprite("select");
         spriteC.SetSprite("select");
         spriteD.SetSprite("select");
         spriteA.color = new Color(1, 1, 1, 1);
         spriteB.color = new Color(1, 1, 1, 1);
         spriteC.color = new Color(1, 1, 1, 1);
         spriteD.color = new Color(1, 1, 1, 1);


        
    }

    void setSprite()
    {
        if (GameController.instance.selectCase != GameController.instance.truecase)
        {

            if (GameController.instance.selectCase == 1)
            {
                spriteA.SetSprite("selectfalse");
            }

            if (GameController.instance.selectCase == 2)
            {
                spriteB.SetSprite("selectfalse");
            }

            if (GameController.instance.selectCase == 3)
            {
                spriteC.SetSprite("selectfalse");
            }

            if (GameController.instance.selectCase == 4)
            {
                spriteD.SetSprite("selectfalse");
            }
           
        }


        if (GameController.instance.truecase == 1)
        {
            spriteA.SetSprite("selecttrue");
        }

        if (GameController.instance.truecase == 2)
        {
            spriteB.SetSprite("selecttrue");
        }

        if (GameController.instance.truecase == 3)
        {
            spriteC.SetSprite("selecttrue");
        }

        if (GameController.instance.truecase == 4)
        {
            spriteD.SetSprite("selecttrue");
        }

    }

 

  public  void doSetEnabal(bool ok)
    {

        spriteA.gameObject.GetComponent<BoxCollider>().enabled = ok;
        spriteB.gameObject.GetComponent<BoxCollider>().enabled = ok;
        spriteC.gameObject.GetComponent<BoxCollider>().enabled = ok;
        spriteD.gameObject.GetComponent<BoxCollider>().enabled = ok;
            //twA.enabled = ok;
            //twB.enabled = ok;
            //twC.enabled = ok;
            //twD.enabled = ok;
      
    }


    void btnA_Click()
    {
        try
        {

       
            if (GameController.instance.currentState == GameController.State.Question)
            {
                SoundController.Instance.Stop();
                spriteA.SetSprite("traloicau");
                SoundController.Instance.PlayChonA();
                Reply(1);
            }

        }
        catch (System.Exception)
        {

            throw;
        }
        
    }

    void btnB_Click()
    {
        try
        {
        if (GameController.instance.currentState == GameController.State.Question)
        {
            SoundController.Instance.Stop();
            spriteB.SetSprite("traloicau");
            SoundController.Instance.PlayChonB();
            Reply(2);
        }
         }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    void btnC_Click()
    {
        try{
        if (GameController.instance.currentState == GameController.State.Question)
        {
            SoundController.Instance.Stop();
            spriteC.SetSprite("traloicau");
            SoundController.Instance.PlayChonC();
            Reply(3);
        }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    void btnD_Click()
    {
        try
        {
            if (GameController.instance.currentState == GameController.State.Question)
            {
                SoundController.Instance.Stop();
                spriteD.SetSprite("traloicau");
                SoundController.Instance.PlayChonD();
                Reply(4);
            }
        }
        catch (System.Exception)
        {

            throw;
        }
    }

	// Use this for initialization
	void Start () {
        btnA.OnClick += btnA_Click;
        btnB.OnClick += btnB_Click;
        btnC.OnClick += btnC_Click;
        btnD.OnClick += btnD_Click;
        spriteA = btnA.gameObject.GetComponent<tk2dSprite>();
        spriteB = btnB.gameObject.GetComponent<tk2dSprite>();
        spriteC = btnC.gameObject.GetComponent<tk2dSprite>();
        spriteD = btnD.gameObject.GetComponent<tk2dSprite>();
 
	}
	
	// Update is called once per frame
	void Update () {

        if (curentNhapNhay == State.Play)
        {
            if (GameController.instance.selectCase != GameController.instance.truecase)
            {
                if (GameController.instance.selectCase == 1)
                {
                    doNhapNhay(spriteA);
                }

                if (GameController.instance.selectCase == 2)
                {
                    doNhapNhay(spriteB);
                }

                if (GameController.instance.selectCase == 3)
                {
                    doNhapNhay(spriteC);
                }

                if (GameController.instance.selectCase == 4)
                {
                    doNhapNhay(spriteD);
                }
            }

            if (GameController.instance.truecase == 1)
            {
                doNhapNhay(spriteA);
            }

            if (GameController.instance.truecase == 2)
            {
                doNhapNhay(spriteB);
            }

            if (GameController.instance.truecase == 3)
            {
                doNhapNhay(spriteC);
            }

            if (GameController.instance.truecase == 4)
            {
                doNhapNhay(spriteD);
            }
          
        }
	}


    void doNhapNhay(tk2dSprite sp)
    {


        if (nhapnhayok)
        {
            numColorA = numColorA - 0.02f;
            if (numColorA <= 0.4)
                nhapnhayok = false;
        }
        else
        {
            numColorA = numColorA + 0.02f;
            if (numColorA >= 1)
            {
                nhapnhayok = true;
            }
        }
        sp.color = new Color(1,1,1,numColorA);
       // Debug.Log("sss:"+numColorA);
    }
}
