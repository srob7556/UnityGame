 using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	//This is used to know which theme was last configured
	public static int THEME = 0;



	//Highscore and gems information
	public Text gemsInformation;
	private int totalgems;

	// Use this for initialization
	void Start () {
		
		ZPlayerPrefs.Initialize("group123", "happyapplications2016");
		THEME = ZPlayerPrefs.GetInt ("THEME");
		SetTheme (THEME);

	}
	public void LoadScene(){
		THEME = ZPlayerPrefs.GetInt ("THEME");
		SceneManager.LoadScene (1);

	}

	public void SetTheme(int theme){
		switch(theme){
		case 0:
			//background.sprite = backgrounds [0];


		
			ZPlayerPrefs.SetInt ("THEME", 0);
			ZPlayerPrefs.Save ();
			break;
		case 1:
			//background.sprite = backgrounds [1];



			ZPlayerPrefs.SetInt ("THEME", 1);
			ZPlayerPrefs.Save ();
			break;
		case 2:
			//background.sprite = backgrounds [2];



			ZPlayerPrefs.SetInt ("THEME", 2);
			ZPlayerPrefs.Save ();
			break;
		case 3:
			//background.sprite = backgrounds [3];



			ZPlayerPrefs.SetInt ("THEME", 3);
			ZPlayerPrefs.Save ();
			break;
		case 4:
			//background.sprite = backgrounds [4];



			ZPlayerPrefs.SetInt ("THEME", 4);
			ZPlayerPrefs.Save ();
			break;
		case 5:
			//background.sprite = backgrounds [5];



			ZPlayerPrefs.SetInt ("THEME", 5);
			ZPlayerPrefs.Save ();
			break;
		case 6:
			//background.sprite = backgrounds [6];



			ZPlayerPrefs.SetInt ("THEME", 6);
			ZPlayerPrefs.Save ();
			break;
		case 7:
			//background.sprite = backgrounds [7];



			ZPlayerPrefs.SetInt ("THEME", 7);
			ZPlayerPrefs.Save ();
			break;
		case 8:
			//background.sprite = backgrounds [8];



			ZPlayerPrefs.SetInt ("THEME", 8);
			ZPlayerPrefs.Save ();
			break;
		case 9:
			//background.sprite = backgrounds [9];



			ZPlayerPrefs.SetInt ("THEME", 9);
			ZPlayerPrefs.Save ();
			break;
		default:
			//background.sprite = backgrounds [0];
			ZPlayerPrefs.SetInt ("THEME", 0);
			ZPlayerPrefs.Save ();
			break;
		}
	}

}
