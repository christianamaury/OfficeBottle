using UnityEngine;
using System.Collections;
using admob;

public class AdManager : MonoBehaviour 
{

	//VideoAd.
	private string videoAds = "ca-app-pub-3187572158588519/4937173089";
	private string bannerAds = "ca-app-pub-3187572158588519/1217010808"; 

	public static AdManager instance { set; get;}

	private void Start ()
	{
		instance = this;

		DontDestroyOnLoad (gameObject);

		//Since we're using the editor, we do not want to do this call..
		//InitAdmob method recibe de parametros un Banner ads, y un Video Ads
		#if UNITY_5
		Debug.Log("Currently using the editor");
		#elif UNITY_IPHONE
		Admob.Instance().initAdmob(bannerAds, videoAds);
		//We need to load the interestial video first, before attempting to display it
		Admob.Instance().loadInterstitial();
		#endif

	}

	public void ShowBanner()
	{
		#if UNITY_5
		Debug.Log("Currently using the editor");
		#elif UNITY_IPHONE
		Admob.Instance ().showBannerRelative (AdSize.Banner, AdPosition.TOP_CENTER, 5);
		#endif
	}


	public void showVideoBanner()
	{
		//If the video banner is ready to display, please show it..
		#if UNITY_5
		Debug.Log("Currently using the editor");
		#elif UNITY_IPHONE
		if (Admob.Instance ().isInterstitialReady ())
		{
			Admob.Instance ().showInterstitial ();
		}
		#endif
	}


}
