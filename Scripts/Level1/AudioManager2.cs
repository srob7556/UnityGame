using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AudioManager2 : MonoBehaviour 
{
	public AudioSource musicPlayer;
	public AudioSource effectPlayer;
	

	//Audio enabled and disabled sprites
	public Image[] audioButtons;
	public Sprite[] audioSprites;  

	public AudioClip gameover, obstacle, point;

	//Enabled and disabled states
	public bool audioEnabled;
	private int audio;
	// Use this for initialization
	void Start () 
	{    
		int firsttime=PlayerPrefs.GetInt("firsttime");
		if (firsttime == 0) {
			PlayerPrefs.SetInt ("audioEnabled", 1);
			PlayerPrefs.SetInt("firsttime",1);
			PlayerPrefs.Save();
		}

		audio = PlayerPrefs.GetInt ("audioEnabled");


		if (audio == 1)
		{
			audioEnabled = true;

			if (musicPlayer)
				musicPlayer.mute = false;
			if(effectPlayer)
				effectPlayer.mute=false;
		}
		else
		{
			audioEnabled = false;
			musicPlayer.mute=true;
			effectPlayer.mute=true;

		}
		UpdateAudioButtons ();
	}
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
				//musicPlayer.Play();
				musicPlayer.mute=false;
			if (effectPlayer)
				effectPlayer.mute = false;
		}

		PlayerPrefs.Save ();
		UpdateAudioButtons ();
	}

	//Updates the sprite of the audio buttons
	private void UpdateAudioButtons()
	{

		Sprite s = audioEnabled == true ? audioSprites[0] : audioSprites[1];

		foreach (Image item in audioButtons)
			item.sprite = s;
	}
	void Update(){

			
		     if (GameManager.state == GameManager.PAUSE) {
		       if(audioEnabled)
				musicPlayer.mute = true;
			} else  if (GameManager.state == GameManager.PLAYING) {
			if(audioEnabled)
				musicPlayer.mute = false;
			
			} else if (GameManager.state == GameManager.OVER) {
			if(audioEnabled)
				musicPlayer.mute = true;
			}

		
		
		}


	public void PlayGameOver()
	{
		if (gameover && audioEnabled)
		{
			effectPlayer.clip = gameover;
			effectPlayer.Play();
		}
	}

	public void PlayPoint()
	{
		if (point && audioEnabled)
		{
			effectPlayer.clip = point;
			effectPlayer.Play();
		}
	}

}
