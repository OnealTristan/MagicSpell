using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class AdManager : MonoBehaviour {
    /*public static AdManager instance;

    private static string ADBANNERUNIT_ID = "ca-app-pub-5735182625942530/2585099069";
    private static string adINTERSTITIALUNIT_ID = "ca-app-pub-5735182625942530/5036561064";

    //private BannerView bannerView;
   // private InterstitialAd interstitialAd;

    private Scene scene;
    private string sceneName;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        // Initialize the Google Mobile Ads SDK.
       // MobileAds.Initialize((InitializationStatus initStatus) => {
            // This callback is called once the MobileAds SDK is initialized.
        });

    }

    private void Update() {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        if (sceneName == "MainMenu" || sceneName == "LevelMenu") {
            if (bannerView == null) {
                LoadBannerAd();
            }
        } else {
            DestroyBannerAd();
        }
    }

    private void LoadBannerAd() {
        if (bannerView == null) {
            CreateBannerView();
        }

        var adRequest = new AdRequest();

        // send the request to load the ad.
        bannerView.LoadAd(adRequest);
    }

    private void CreateBannerView() {
        if (bannerView != null) {
            DestroyBannerAd();
        }

        bannerView = new BannerView(ADBANNERUNIT_ID, AdSize.SmartBanner, AdPosition.Top);
    }

    private void DestroyBannerAd() {
        if (bannerView != null) {
            bannerView.Destroy();
            bannerView = null;
        }
    }

    public void LoadInterstitialAd() {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null) {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(adINTERSTITIALUNIT_ID, adRequest,
            (InterstitialAd ad, LoadAdError error) => {
                // if error is not null, the load request failed.
                if (error != null || ad == null) {
                    Debug.LogError("interstitial ad failed to load an ad with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });

        ShowInterstitialAd();
    }

    private void ShowInterstitialAd() {
        if (interstitialAd != null && interstitialAd.CanShowAd()) {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        } else {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }*/
}
