using UnityEngine;
using System.Collections;

public class PopupController : MonoBehaviour {


    public PopUpGameOver gameOver;
    public PopUpKhanGia khangia;
    public PopUpNguoiThan nguoithan;
    public PopUpWin iwin;
    public PopUpSHA sha;
    public MainGame mainGame;

    public float showPositionYMainGame;
    public float hidePostionYMainGame;

    public float showPositionY;
    public float hidePostionY;

    public float showPositionYKhanGia;
    public float hidePostionYKhanGia;

    public float moveSpeed;

    public float showPositionYNguoiThan;
    public float showPositionYIwin;


    #region Singleton
    private static PopupController _instance;

    public static PopupController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<PopupController>();
            return _instance;
        }
    }
    #endregion


    IEnumerator ieMoveDown(GameObject popup)
    {
        while (popup.transform.position.y > showPositionY)
        {
            popup.transform.position += Vector3.down
                * (moveSpeed+300)
                * Time.deltaTime;
            yield return 0;
        }

    }

    IEnumerator ieMoveUp(GameObject popup)
    {
        while (popup.transform.position.y < hidePostionY)
        {
            popup.transform.position += Vector3.up
                * (moveSpeed + 300)
                * Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator ieMoveLeft(GameObject popup)
    {
        while (popup.transform.position.x > 0f)
        {
            popup.transform.position += Vector3.left
                * (moveSpeed+200)
                * Time.deltaTime;
            yield return 0;
        }

    }

    IEnumerator ieMoveRight(GameObject popup)
    {
        while (popup.transform.position.x < 1200f)
        {
            popup.transform.position += Vector3.right
                * (moveSpeed + 200)
                * Time.deltaTime;
            yield return 0;
        }
    }
    public void ShowSHA()
    {
        StartCoroutine(ieMoveLeft(sha.gameObject));
    }


    public void HideSHA()
    {
        StartCoroutine(ieMoveRight(sha.gameObject));
    }


  

    IEnumerator ieMoveUpKG(GameObject popup)
    {
        while (popup.transform.position.y < hidePostionYKhanGia)
        {
            popup.transform.position += Vector3.up
                * moveSpeed
                * Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator ieMoveDownMain(GameObject popup)
    {
        while (popup.transform.position.y >= showPositionYMainGame)
        {
            popup.transform.position += Vector3.down
                * moveSpeed
                * Time.deltaTime;
            yield return 0;
        }

    }

    IEnumerator ieMoveUpMain(GameObject popup)
    {
        while (popup.transform.position.y < hidePostionYMainGame)
        {
            popup.transform.position += Vector3.up
                * moveSpeed
                * Time.deltaTime;
            yield return 0;
        }
    }

    public void ShowMainGame()
    {
        StartCoroutine(ieMoveDownMain(mainGame.gameObject));
    }

    public void HideMainGame()
    {
        StartCoroutine(ieMoveUpMain(mainGame.gameObject));
    }

    public void ShowPopUpWin()
    {
        iwin.transform.position = new Vector3(iwin.transform.position.x, showPositionYIwin, 10f);
    }

    public void HidePopUpWin()
    {
        iwin.transform.position = new Vector3(iwin.transform.position.x, hidePostionYKhanGia, 10f);
    }


    public void ShowPopUpNguoiThan()
    {
        nguoithan.transform.position = new Vector3(nguoithan.transform.position.x, showPositionYNguoiThan, 10f);
    }

    public void HidePopupNguoiThan()
    {
        StartCoroutine(ieMoveUpKG(nguoithan.gameObject));

    }



    public void HidePopupKhanGia()
    {
        StartCoroutine(ieMoveUpKG(khangia.gameObject));

    }

    public void ShowPopupKhanGia()
    {
        khangia.setPhanTram();
        khangia.transform.position = new Vector3(khangia.transform.position.x, showPositionYKhanGia, 10f);
    }



    public void HidePopupGameOver()
    {
        StartCoroutine(ieMoveUp(gameOver.gameObject));
 
    }

    public void ShowPopupGameOver(int level,int maxlevel)
    {
        gameOver.setlevel(level, maxlevel);
        StartCoroutine(ieMoveDown(gameOver.gameObject));
        HidePopupKhanGia();
        HidePopupNguoiThan();
        nguoithan.resetNguoiThan();
       
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
