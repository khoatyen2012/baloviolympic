using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSourceBGMusicPrefab;
    private AudioSource audioSourceBGMusicCreated;

    public AudioClip[] arrAudioClip;

    bool ok = true;

    #region Singleton
    private static SoundController _instance;

    public static SoundController Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<SoundController>();
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
      //  PlayBGMusic();
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if ((!CheckISPlay())&&(ok == false))
        {
           
            audioSourceBGMusicCreated.Play();
            ok = true;
        }
    }


   public void PlayBGMusic()
    {
        audioSourceBGMusicCreated =
            GameObject.Instantiate
            (
                audioSourceBGMusicPrefab
            ) as AudioSource;
        audioSourceBGMusicCreated.loop = true;
        audioSourceBGMusicCreated.Play();

        DontDestroyOnLoad
        (
            audioSourceBGMusicCreated
        );

      
    }

   public void StopBG()
   {
       audioSourceBGMusicCreated.Stop();
   }

    public void PlayBatDau()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[0]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi1()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[1]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi2()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[2]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }


    public void PlayHoi3()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[3]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }


    public void PlayHoi4()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[4]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi5()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[5]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi6()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[6]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi7()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[7]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi8()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[8]);
              audioSourceBGMusicCreated.Pause();
              ok = false;
    }

    public void PlayHoi9()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[9]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi10()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[10]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi11()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[11]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi12()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[12]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi13()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[13]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi14()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[14]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHoi15()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[15]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayChungTa()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[16]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayChonA()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[17]);
              audioSourceBGMusicCreated.Pause();
              ok = false;
    }

    public void PlayChonB()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[18]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayChonC()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[19]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayChonD()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[20]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayGoiNguoiThan()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[21]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayHetGio()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[22]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayKhanGia()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[23]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlaySaiA()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[24]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlaySaiB()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[25]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }
    public void PlaySaiC()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[26]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlaySaiD()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[27]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }
    public void PlayNamMuoi()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[28]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }


    public void PlayDuaRa1()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[29]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayDuaRa2()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[30]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }


    public void PlayVuotQua14()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[31]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }



    public void PlayVuotQua15()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[32]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }


    public void PlayCamXuc()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[33]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayQuanTrong()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[34]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayTamBiet()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[35]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayDungA()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[36]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayDungB()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[37]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayDungC()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[38]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayDungD()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[39]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayAB()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[40]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayAC()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[41]);
              audioSourceBGMusicCreated.Pause();
              ok = false;
    }

    public void PlayAD()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[42]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayBC()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[43]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayBD()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[44]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayCD()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[45]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayDuaRa3()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[46]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void PlayDuaRa4()
    {
        tk2dUIAudioManager.Instance.Play(arrAudioClip[47]);
        audioSourceBGMusicCreated.Pause();
        ok = false;
    }

    public void Stop()
    {
        tk2dUIAudioManager.Instance.curentStop();
    }

    public bool CheckISPlay()
    {
        return tk2dUIAudioManager.Instance.CheckPlay();
    }
}
