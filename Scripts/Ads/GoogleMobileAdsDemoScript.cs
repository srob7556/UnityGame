using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class GoogleMobileAdsDemoScript : MonoBehaviour
{
	
	private BannerView bannerView;
	private InterstitialAd interstitial;




	//Interstitial Ids

	private string interstitialadUnitId = "unused";
	public string appleUnitId="";
	public string googleUnitId="";


	//banner ids
	#if UNITY_EDITOR
	public string banneradUnitId = "unused";
	#elif UNITY_ANDROID
	public string banneradUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
	#elif UNITY_IPHONE
	string banneradUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
	#else
	string banneradUnitId = "unexpected_platform";
	#endif
	void Start(){
	#if UNITY_EDITOR
	interstitialadUnitId=googleUnitId;
	#elif UNITY_ANDROID
	interstitialadUnitId=googleUnitId;
	#elif UNITY_IPHONE
	interstitialadUnitId=appleUnitId;
	#else
	string interstitialadUnitId =googleUnitId;
	#endif
		RequestInterstitial ();
	    
		}

	public void ShowInterstitial()
	{
	if (interstitial.IsLoaded())
	{
	interstitial.Show();
	}
	else
	{
	print("Interstitial is not ready yet.");
	}

	}

	private void RequestBanner()
	{
		
		
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(banneradUnitId, AdSize.SmartBanner, AdPosition.Top);
	
		// Register for ad events.
		// Called when an ad request has successfully loaded.
		bannerView.OnAdLoaded += HandleOnAdLoaded;
		// Called when an ad request failed to load.
		bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
		// Called when an ad is clicked.
		bannerView.OnAdOpening += HandleOnAdOpened;
		// Called when the user returned from the app after an ad click.
		bannerView.OnAdClosed += HandleOnAdClosed;
		// Called when the ad click caused the user to leave the application.
		bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;
		// Load a banner ad.
		bannerView.LoadAd(createAdRequest());

		bannerView.Show();
	}


	private void RequestInterstitial()
	{
		
		
		// Create an interstitial.
	interstitial = new InterstitialAd(interstitialadUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
	interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
	}
	
	// Returns an ad request with custom ad targeting.
	private AdRequest createAdRequest()
	{
		return new AdRequest.Builder()
			.AddTestDevice(AdRequest.TestDeviceSimulator)
				.AddTestDevice("C957727644B691B4C9F8B2793EA40F95")
				.AddTestDevice("C48A9B2CA049DECB48D491B36F32EE94")
	            .AddTestDevice("115F0EB28525E0486CE78FF6FC1A8059")
				.AddKeyword("game")
				.SetGender(Gender.Male)
				.SetBirthday(new DateTime(1985, 1, 1))
				.TagForChildDirectedTreatment(false)
				.AddExtra("color_bg", "9B30FF")
				.Build();
		
	}
	





	#region Banner callback handlers
	
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		print("HandleAdLoaded event received.");
	}
	
	public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleFailedToReceiveAd event received with message: " + args.Message);
	}
	
	public void HandleOnAdOpened(object sender, EventArgs args)
	{
		print("HandleAdOpened event received");
	}
	
	
	
	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		print("HandleAdClosed event received");
	}
	
	public void HandleOnAdLeavingApplication(object sender, EventArgs args)
	{
		print("HandleAdLeftApplication event received");
	}
	
	#endregion
	
	#region Interstitial callback handlers
	
	public void HandleInterstitialLoaded(object sender, EventArgs args)
	{
		print("HandleInterstitialLoaded event received.");
	}
	
	public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
	{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}
	
	public void HandleInterstitialOpened(object sender, EventArgs args)
	{
		print("HandleInterstitialOpened event received");
	}
	
	public void HandleInterstitialClosing(object sender, EventArgs args)
	{
		print("HandleInterstitialClosing event received");
	}
	
	public void HandleInterstitialClosed(object sender, EventArgs args)
	{
		print("HandleInterstitialClosed event received");
	}
	
	public void HandleInterstitialLeftApplication(object sender, EventArgs args)
	{
		print("HandleInterstitialLeftApplication event received");
	}
	
	#endregion
}