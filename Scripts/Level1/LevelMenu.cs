using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Security.Cryptography;
public class LevelMenu : MonoBehaviour {


	//Highscore and gems information
	public Text gemsInformation;
	private int totalgems;
	public Text highscoreInformation;

	private int highscore;

	// Use this for initialization
	void Start () {
		ZPlayerPrefs.Initialize("group123", "happyapplications2016");
		UpdateMainInformation ();
	}

	public void UpdateMainInformation(){
		totalgems = ZPlayerPrefs.GetInt ("totalgems");
		highscore = ZPlayerPrefs.GetInt ("highscore");
		gemsInformation.text = totalgems.ToString ();
		highscoreInformation.text = highscore.ToString ();


	}

	public void LoadHomeMenu(){
		SceneManager.LoadScene (0);
	}
	public void RestartLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
