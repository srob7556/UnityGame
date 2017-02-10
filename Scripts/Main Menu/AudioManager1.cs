using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AudioManager1 : MonoBehaviour 
{   

	//Mainly the main camera contains the music player source
	public AudioSource musicPlayer;

	//The effect player usually atached to the canvas
	public AudioSource effectPlayer;
	
	//public AudioClip menuClickClip,clasamentClip,playClip,levelClick;

	//Audio enabled and disabled sprites
	public Image[] audioButtons;
	public Sprite[] audioSprites;  



	//Check if the audio is on or off
	public bool audioEnabled;
	private int audio;

	
	// Use this for initialization
	void Start () 
	{   

		//If first time the audio always set to on
		int firsttime=PlayerPrefs.GetInt("firsttime");
		//PlayerPrefs: audioEnabled and firsttime 
		if (firsttime == 0) {
			PlayerPrefs.SetInt ("audioEnabled", 1);
			PlayerPrefs.SetInt("firsttime",1);
			PlayerPrefs.Save();
		}

		//Get the audio state: 0 or 1
		audio = PlayerPrefs.GetInt ("audioEnabled");

		//If Audio enabled
		if (audio == 1)
		{
			audioEnabled = true;
			
			if (musicPlayer)
		     	musicPlayer.mute = false;
			if(effectPlayer)
				effectPlayer.mute=false;
		}
		else
		{  //If Audio  disabled: mute everything
			audioEnabled = false;
			musicPlayer.mute=true;
			effectPlayer.mute=true;

		}
		//Update the audio sprites to either on or off
		UpdateAudioButtons ();
	}


	/**
	 * Change the audio state from on to off and viceversa
	 * */
	public void ChangeAudioState()
	{   
		if (audioEnabled)
		{
			audioEnabled = false;

			PlayerPrefs.SetInt("audioEnabled",0);
			if (musicPlayer)
				musicPlayer.mute=true;
			
			if (effectPlayer)
				effectPlayer.mute=true;
		}
		else
		{
			audioEnabled = true;
			PlayerPrefs.SetInt("audioEnabled",1);
			
			if (musicPlayer)
				musicPlayer.mute=false;
			if (effectPlayer)
				effectPlayer.mute=false;

		}
		//Save the changes
		PlayerPrefs.Save ();

		//Update audio buttons
		UpdateAudioButtons ();
	}

	//Updates the sprite of the audio buttons
	private void UpdateAudioButtons()
	{
		
		Sprite s = audioEnabled == true ? audioSprites[0] : audioSprites[1];
		
		foreach (Image item in audioButtons)
			item.sprite = s;
	}



	/*
	public void PlayMenuClick()
	{
		if (menuClickClip && audioEnabled)
		{
			effectPlayer.clip = menuClickClip;
			effectPlayer.Play();
		}
	}
	public void PlayMissionComplete()
	{
		if (missionCompleteClip && audioEnabled)
		{
			effectPlayer.clip = missionCompleteClip;
			effectPlayer.Play();
		}
	}

	public void PlayExplosion()
	{
		if (explosionClip && audioEnabled)
		{
			effectPlayer.clip = explosionClip;
			effectPlayer.Play();
		}
	}
	public void PlayPowerupCollected()
	{
		if (powerupCollectedClip && audioEnabled)
		{
			effectPlayer.clip = powerupCollectedClip;
			effectPlayer.Play();
		}
	}
	public void PlayPowerupUsed()
	{
		if (powerupUsedClip && audioEnabled)
		{
			effectPlayer.clip = powerupUsedClip;
			effectPlayer.Play();
		}
	}
	public void PlayRevive()
	{
		if (reviveClip && audioEnabled)
		{
			effectPlayer.clip = reviveClip;
			effectPlayer.Play();
		}
	}*/
}
