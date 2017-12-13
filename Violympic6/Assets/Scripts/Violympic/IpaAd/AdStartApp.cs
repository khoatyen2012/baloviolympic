using UnityEngine;
using System.Collections;
using StartApp;

public class AdStartApp : MonoBehaviour {


	#region Singleton
	private static AdStartApp _instance;

	public static AdStartApp instance
	{
		get
		{
			if (_instance == null)
				_instance = GameObject.FindObjectOfType<AdStartApp>();
			return _instance;
		}
	}
	#endregion

	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		StartAppWrapper.init();
		StartAppWrapper.loadAd();
		#endif
	}

	public void ShowFull()
	{
		#if UNITY_ANDROID
		StartAppWrapper.showAd();
		StartAppWrapper.loadAd();
		#endif
	}

	public void ShowBanner()
	{
		#if UNITY_ANDROID
		StartAppWrapper.addBanner( 
			StartAppWrapper.BannerType.AUTOMATIC,
			StartAppWrapper.BannerPosition.TOP);
		#endif
	}

	public void HideBanner()
	{
		#if UNITY_ANDROID
		StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.TOP);
		#endif
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
