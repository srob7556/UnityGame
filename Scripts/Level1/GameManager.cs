using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Cryptography;
public class GameManager : MonoBehaviour {
	//References
	public GameController gamecontroller;

	//Game States
	public static int INTRO=0;
	public static int PLAYING=1;
	public static int PAUSE=2;
	public static int OVER=3;
	public static int CONTINUE = 4;

	//Ads and info
	public LevelMenu levelmenu;
	public GoogleMobileAdsDemoScript interstitial;
	public ChartboostReward reward;

	//Current state of the game
	public static int state;
	private int count,count1;
	private int gems;
	private bool hasad;
	private int playcounter;

	//GUI Panels
	public GameObject mainPanel,pausePanel,overPanel;

	public GameObject gameOverTitle, retryButton,resumeButton,pausedTitle,revive1,revive2;

	// Use this for initialization
	void Start () {
		


		count=PlayerPrefs.GetInt("count");
		count1 = PlayerPrefs.GetInt ("count1");

		mainPanel.SetActive (true);
		pausePanel.SetActive (false);
		gameOverTitle.SetActive (false);
		retryButton.SetActive (false);
		revive1.SetActive (false);
		revive2.SetActive (false);
		SetPlay ();
	
	}
	



	public void SetPlay()
	{
		StartCoroutine (SetPlaying ());
	}
	IEnumerator SetPlaying(){
		
		//turn on main menu
		mainPanel.SetActive (true);
		pausePanel.SetActive (false);
		gameOverTitle.SetActive (false);
		retryButton.SetActive (false);
		resumeButton.SetActive (true);
		pausedTitle.SetActive (true);
		revive1.SetActive (false);
		revive2.SetActive (false);
		yield return new WaitForSeconds(0.5f);
		GameManager.state = GameManager.PLAYING;
		gamecontroller.StartGame ();
	}
	public void SetPause(){
		
		mainPanel.SetActive (false);
		//turn on pause panel
		resumeButton.SetActive (true);
		pausedTitle.SetActive (true);
		pausePanel.SetActive (true);
		gameOverTitle.SetActive (false);
		retryButton.SetActive (false);
		revive1.SetActive (false);
		revive2.SetActive (false);
		levelmenu.UpdateMainInformation ();

		GameManager.state = GameManager.PAUSE;
		gamecontroller.GameOver ();
	}

	public void SetOver(){
		StartCoroutine (SetGameOver ());
	}

	IEnumerator SetGameOver(){
		GameManager.state = GameManager.OVER;
		gamecontroller.GameOver();
		yield return new WaitForSeconds (0.9f);
		levelmenu.UpdateMainInformation ();
		mainPanel.SetActive (false);
		pausePanel.SetActive (true);
		gameOverTitle.SetActive (true);
		retryButton.SetActive (true);
		resumeButton.SetActive (false);
		pausedTitle.SetActive (false);
		count = count + 1;
		count1 += 1;
		PlayerPrefs.SetInt ("count", count);
		PlayerPrefs.SetInt ("count1", count1);
		PlayerPrefs.Save();
		gems = ZPlayerPrefs.GetInt ("totalgems");
		hasad = reward.HasAd ();
		Debug.Log (gems.ToString ());
		if (gems >= 10)
			revive1.SetActive (true);
		else
			revive1.SetActive (false);

		if (hasad == true&&count1>=4)
			revive2.SetActive (true);
		else
			revive2.SetActive (false);
		if (count >=3) {
			interstitial.ShowInterstitial ();
			PlayerPrefs.SetInt ("count",0);
			PlayerPrefs.Save ();
		} 
		playcounter = ZPlayerPrefs.GetInt ("playcounter");
		ZPlayerPrefs.SetInt ("playcounter", playcounter + 1);
		ZPlayerPrefs.Save ();



	}

	public void ContinueLevelFirst(){
		if (gems >= 10) {
			gems = gems - 10;
			ZPlayerPrefs.SetInt ("totalgems", gems);
			ZPlayerPrefs.Save ();
			SetPlay ();

			ScoreManager.gearsno = 0;
			ScoreManager.isgameover = false;
		}
	}
	public void ContinueLevelSecond(){

		PlayerPrefs.SetInt ("count1", 0);
		PlayerPrefs.Save ();
			SetPlay ();
			ScoreManager.gearsno = 0;
		    ScoreManager.isgameover = false;
	}


}
