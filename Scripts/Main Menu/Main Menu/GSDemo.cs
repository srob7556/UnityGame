using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using System.Security.Cryptography;

public class GSDemo : MonoBehaviour
{
	/**
	 * This Class is used to add the leaderboard services for Google and Apple
	 * */
	//The score that will be submited
	public int score = 10;
	//Information
	public Text information,info2;
	public GameObject gamecentererror;
	public string googleleaderboard;
	public string appleleaderboard;
	void Start ()
	{
		//score = ZPlayerPrefs.GetInt ("playcounter");
		score = ZPlayerPrefs.GetInt ("highscore");
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;

		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();
	
	}


	private void CheckAndroid(){
		info2 .text= PlayerPrefs.GetString ("Android");

	}

	/// <summary>
	/// Login In Into Your Google+ Account
	/// Login In Into Your Apple Account
	/// </summary>
	public void LogIn ()
	{   //Ios login
		#if UNITY_IOS
		try
		{
		Social.localUser.Authenticate (ProcessAuthentication);
		OnAddScoreToLeaderBoard();
		}
		catch(Exception e)
		{
		Debug.Log("------ Authenticate - EXCEPTION : " + e.ToString());
		}
		#endif

		//Android Login
		#if UNITY_ANDROID
		Social.localUser.Authenticate ((bool success) =>
			{
				if (success) {
					Debug.Log ("Login Sucess");
					PlayerPrefs.SetString("Android","Success");
					PlayerPrefs.Save();
					OnAddScoreToLeaderBoard();

				} else {
					PlayerPrefs.SetString("Android","Not ready");
					PlayerPrefs.Save ();
					Debug.Log ("Login failed");
					gamecentererror.SetActive(true);
					information.text="Login Failed. Please try again!";
				}
			});
		#endif
	}

	/// <summary>
	/// Shows All Available Leaderborad
	/// </summary>
	public void OnShowLeaderBoard ()
	{
		#if UNITY_ANDROID
		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI (googleleaderboard); // Show current (Active) leaderboard
		#endif

		#if UNITY_IOS
		Social.ShowLeaderboardUI (appleleaderboard);
		#endif

	}

	/// <summary>
	/// Adds Score To leader board
	/// </summary>
	public void OnAddScoreToLeaderBoard ()
	{    //information.text="Posting "+score.ToString()+" points to leaderboard";

		#if UNITY_ANDROID
		if (Social.localUser.authenticated) {
			Social.ReportScore (score, googleleaderboard, (bool success) =>
				{
					if (success) {
						Debug.Log ("Update Score Success");
						PlayerPrefs.SetString("Android","Score updated");
						PlayerPrefs.Save();
						OnShowLeaderBoard();
					} else {
						Debug.Log ("Update Score Fail");
						PlayerPrefs.SetString("Android","Score failed");
						PlayerPrefs.Save();
						gamecentererror.SetActive(true);
						information.text="Score posting failed!";
					}
				});
		}
		#endif

		#if UNITY_IOS
		if (Social.localUser.authenticated) {		
		try
		{
		Social.ReportScore(score,appleleaderboard,(bool success) => {
		Debug.Log("succefully post score leaderboard ? " + success);
		OnShowLeaderboard();
		});
		}
		catch(Exception e)
		{
		Debug.Log("------ ReportScore - EXCEPTION : " + e.ToString());
		}
		catch(Exception e)
		{
		Debug.Log("------ IsInitialized - EXCEPTION : " + e.ToString());
		}
		}
		#endif
	}


	/// <summary>
	/// On Logout of your Google+ Account
	/// </summary>
	public void OnLogOut ()
	{
		((PlayGamesPlatform)Social.Active).SignOut ();
	}

}
