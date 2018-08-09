using UnityEngine;
using System.Collections;
using admob;
public class admobdemo : MonoBehaviour {
	Admob ad;
	string appID="";
	string bannerID="";
	string interstitialID="";
	string videoID="";
	string nativeBannerID = "";
	
	void Start () {
        Debug.Log("start unity demo-------------");
         initAdmob();
	}
	
	void Update () {
	    if (Input.GetKeyUp (KeyCode.Escape)) {
            Debug.Log(KeyCode.Escape+"-----------------");
	    }
    }
   
    void initAdmob()
    {
        	#if UNITY_IOS
        		 appID="ca-app-pub-3940256099942544~1458002511";
				 bannerID="ca-app-pub-3940256099942544/2934735716";
				 interstitialID="ca-app-pub-3940256099942544/4411468910";
				 videoID="ca-app-pub-3940256099942544/1712485313";
				 nativeBannerID = "ca-app-pub-3940256099942544/3986624511";
        	#elif UNITY_ANDROID
        		 appID="ca-app-pub-3940256099942544~3347511713";
				 bannerID="ca-app-pub-3940256099942544/6300978111";
				 interstitialID="ca-app-pub-3940256099942544/1033173712";
				 videoID="ca-app-pub-3940256099942544/5224354917";
				 nativeBannerID = "ca-app-pub-3940256099942544/2247696110";
			#endif
			
            ad = Admob.Instance();
            ad.bannerEventHandler += onBannerEvent;
            ad.interstitialEventHandler += onInterstitialEvent;
            ad.rewardedVideoEventHandler += onRewardedVideoEvent;
            ad.nativeBannerEventHandler += onNativeBannerEvent;
            ad.initSDK(appID);//optional
            ad.initAdmob(bannerID,interstitialID );//all id are admob test id,change those to your
                                                                                                             //ad.setTesting(true);//show test ad
            //ad.setNonPersonalized(true);//if want load NonPersonalized only,set true
           // ad.setIsDesignedForFamilies(true);//if is Is Designed For Families set true
           // ad.setGender(AdmobGender.MALE);
   		   //  string[] keywords = { "game","crash","male game"};
          //  ad.setKeywords(keywords);//set keywords for ad
            Debug.Log("admob inited -------------"+appID);
        
    }
	void OnGUI(){
        if (GUI.Button(new Rect(120, 0, 100, 60), "showInterstitial"))
        {
           Debug.Log("touch inst button -------------");
            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial();
            }
        }
        if (GUI.Button(new Rect(240, 0, 100, 60), "showRewardVideo"))
        {
            Debug.Log("touch video button -------------");
            if (ad.isRewardedVideoReady())
            {
                ad.showRewardedVideo();
            }
            else
            {
            	ad.loadRewardedVideo(videoID);
            }
        }
        if (GUI.Button(new Rect(0, 100, 100, 60), "showbanner"))
        {
            Admob.Instance().showBannerRelative(AdSize.SmartBanner, AdPosition.BOTTOM_CENTER, 0);
        }
        if (GUI.Button(new Rect(120, 100, 100, 60), "showbannerABS"))
        {
            Admob.Instance().showBannerAbsolute(AdSize.Banner, 20, 300);
        }
        if (GUI.Button(new Rect(240, 100, 100, 60), "removebanner"))
        {
            Admob.Instance().removeBanner();
        }
        
        if (GUI.Button(new Rect(0, 200, 100, 60), "showNative"))
        {
            Admob.Instance().showNativeBannerRelative(new AdSize(320,100), AdPosition.BOTTOM_CENTER, 0,nativeBannerID);
        }
        if (GUI.Button(new Rect(120, 200, 100, 60), "showNativeABS"))
        {
            Admob.Instance().showNativeBannerAbsolute(new AdSize(-1,132), 20, 300, nativeBannerID);
        }
        if (GUI.Button(new Rect(240, 200, 100, 60), "removeNative"))
        {
            Admob.Instance().removeNativeBanner();
        }
	}
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
    }
    void onRewardedVideoEvent(string eventName, string msg)
    {
        Debug.Log("handler onRewardedVideoEvent---" + eventName + "  rewarded: " + msg);
    }
    void onNativeBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobNativeBannerEvent---" + eventName + "   " + msg);
    }
}
