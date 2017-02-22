using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using UnityEngine.UI;
using System.Security.Cryptography;
public class FacebookShare: MonoBehaviour {

	// Custom Share Link
	public string shareLink = "https://developers.facebook.com/";
	//public string shareTitle = "Link Title";
	//public string shareDescription = "Link Description";
	//public string shareImage = "http://i.imgur.com/j4M7vCO.jpg";

	//check how many times the player played the game, allow him to share only each 20 times they played
	private int playcounter;

	//The facebook component that holds facebook information
	public GameObject facebookNotAvailable,facebookPanel,facebookShared,facebookError;

	public LevelMenu levelmenu;

	void start(){
		
	}
	// Awake function from Unity's MonoBehavior
	void Awake ()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
			facebookError.SetActive (true);
			facebookPanel.SetActive (false);
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
}

	public void CheckCounter(){
		playcounter = ZPlayerPrefs.GetInt ("playcounter");
		if (playcounter >= 20)
			facebookPanel.SetActive (true);
		else
			facebookNotAvailable.SetActive (true);
			
	}
	public void ShareOnFacebook(){
		FB.ShareLink(new Uri(this.shareLink),callback: ShareCallback);
	}


	private void ShareCallback (IShareResult result) {
		if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink Error: "+result.Error);
			facebookError.SetActive (true);
			facebookPanel.SetActive (false);
		} else if (!String.IsNullOrEmpty(result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log(result.PostId);
			int gems = ZPlayerPrefs.GetInt ("totalgems");
			gems = gems + 50;
			ZPlayerPrefs.SetInt ("totalgems", gems);
			ZPlayerPrefs.SetInt ("playcounter", 0);
			ZPlayerPrefs.Save ();
			facebookShared.SetActive (true);
			facebookPanel.SetActive (false);
		} else {/*
			// Share succeeded without postID
			Debug.Log("ShareLink success!");
			int gems = ZPlayerPrefs.GetInt ("totalgems");
			gems = gems + 50;
			ZPlayerPrefs.SetInt ("totalgems", gems);
			ZPlayerPrefs.SetInt ("playcounter", 0);
			ZPlayerPrefs.Save ();
			facebookPanel.SetActive (false);
			facebookShared.SetActive (true);
			*/
			Debug.Log("ShareLink Error: "+result.Error);
			facebookError.SetActive (true);
			facebookPanel.SetActive (false);
		}
		levelmenu.UpdateMainInformation ();

	}
}