using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Advertisements;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GlobalGameClass : MonoBehaviour {
    public static GlobalGameClass GGC;

//    public GameObject soundManager;
    public int score = 100;
	private bool IsBlured = false;
	private double StartBlurTime1;


	void Start () {
		
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().RequestServerAuthCode(false).RequestIdToken().Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
		Social.localUser.Authenticate((bool success) => {			Debug.Log("Social.localUser.Authenticate = "+success.ToString());			});
	}

	public void PGC_rew(string ptype){
		if(ptype == "go"){
			Social.ReportProgress ("CgkIkOLWp8QQEAIQAQ", 100.0f, (bool success) => {
			});
			PlayGamesPlatform.Instance.IncrementAchievement("CgkIkOLWp8QQEAIQAQ", 5, (bool success) => {			Debug.Log("ReportProgress");		});
		}
	}

	void Update () { 

	}

    void Awake()
    {
        
        if (GGC != null)
        {
//            GameObject.Destroy(GGC);
        }
        else
        {
            GGC = this;
        }
        //DontDestroyOnLoad(this);
        DontDestroyOnLoad(GGC);
    }

    public void StartSendData(string strAction) {
        StartCoroutine(SendData(strAction));
    }

    public IEnumerator SendData(string strAction)
    {
        Debug.Log(strAction);
        WWWForm form = new WWWForm();
        form.AddField("DevId", SystemInfo.deviceUniqueIdentifier);
        form.AddField("DevModel", SystemInfo.deviceModel);
        form.AddField("strAction", strAction);
        form.AddField("strDateTime", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        form.AddField("strDateTimeUTC", System.DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
        form.AddField("strDateTimeTZOffset", System.TimeZone.CurrentTimeZone.GetUtcOffset(System.DateTime.Now).ToString());
        form.AddField("strAppVer", Application.version);

        UnityWebRequest www = UnityWebRequest.Post("http://provr.club/ajaxdata/api.php", form);

        yield return www.Send();
    }



    public void GetAdsBonus(string strAdsBonusName)
    {
		Debug.Log("GetAdsBonus");
/*
        double unixTime = (double)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1)).TotalSeconds + Time.deltaTime;
        double tmp_rand;
        double.TryParse(PlayerPrefs.GetString(strAdsBonusName), out tmp_rand);
		if (Advertisement.isInitialized == false) {
			Advertisement.Initialize ("1694233");
		}
        switch (strAdsBonusName) {
            case "cr200AdsBonus":
                if ((unixTime - (double)tmp_rand) > 10 * 60)
                {
                    if (Advertisement.IsReady("rewardedVideo"))
                    {
                        var options = new ShowOptions { resultCallback = HandleShowResultGGC };
						Debug.Log("ADS start");
                        StartSendData("ADS start");
                        Advertisement.Show("rewardedVideo", options);
                    } else {
						Debug.Log("ADS not ready");
                        StartSendData("ADS not ready");
                    }
                }else { Debug.Log("cr200AdsBonus no time"); }
                break;
        }
 */
    }

	private void HandleShowResultGGC(ShowResult result)
    {
		
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");

                StartSendData("ADS successfully shown");
                PlayerPrefs.SetString("cr200AdsBonus", ((double)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1)).TotalSeconds + Time.deltaTime).ToString());
                PlayerPrefs.Save();
                Destroy(GameObject.Find("200cr"));
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }

    }
    

}
