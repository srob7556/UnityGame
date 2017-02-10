using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Cryptography;
public class ScoreManager : MonoBehaviour {

	public static int Score;
	public static int gearsno;
	public static bool isgameover = false;
	public static int lives;
	public GameManager gamemanager;


	//User Interface
	//Score,gears,score info at the end
	public Text scoreText;
	public Text gears;
	public Text scoreInfo;

	//highscore variable
	private int highscore;

	// Use this for initialization
	void Start () {
		ZPlayerPrefs.Initialize("group123", "happyapplications2016");
		ScoreManager.isgameover = false;
		ScoreManager.Score = 0;
		ScoreManager.gearsno = 0;
		ScoreManager.lives = 2;

		scoreText.text = ScoreManager.Score.ToString ();
		gears.text = ScoreManager.gearsno.ToString ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.state == GameManager.PLAYING) {
			scoreText.text=ScoreManager.Score.ToString();
			scoreInfo.text = ScoreManager.Score.ToString ();
			gears.text = ScoreManager.gearsno.ToString ();

			if(ScoreManager.lives<=0){
				Debug.Log (highscore.ToString ()+"test");
				highscore = ZPlayerPrefs.GetInt ("highscore");

				if (ScoreManager.Score > highscore) {
					highscore = ScoreManager.Score;
					ZPlayerPrefs.SetInt ("highscore", highscore);
					Debug.Log (highscore.ToString ());
					ZPlayerPrefs.Save ();
				}
				int totalgems = ScoreManager.gearsno + ZPlayerPrefs.GetInt ("totalgems");
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				gamemanager.SetOver();
			}
		}
	
	}
}
