using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Cryptography;
public class BackgroundShop : MonoBehaviour {

	public MainMenu mainmenu;
	public LevelMenu levelmenu;

	//Save the current theme selected
	private int THEME=0;

	//Keep  all the UI elements that needs to be updated
	public Button[] backgroundButton;
	public Sprite[] backgroundImages;
	public GameObject[] selectedBackground;
	public GameObject purchasePanel,purchaseSuccess;
	public Text gemInformation;
	public GameObject[] prices;
	public GameObject purchasePanelNoFunds;


	//Keep details about buttons if they have been bought or not
	private int[] themes=new int[10];
	private int numofbackgrounds=10;
	private int totalgems;
	private int selection;
	void Start () {
		//Initialize ZplayerPrefs
		ZPlayerPrefs.Initialize("group123", "happyapplications2016");
		//Get current theme id
		THEME = ZPlayerPrefs.GetInt ("THEME");
		//Activate the selected sign on the current theme
		selectedBackground [THEME].SetActive (true);

		//See which backgrounds have been already purchased
		for (int i = 0; i < numofbackgrounds; i++) {
			themes [i] = ZPlayerPrefs.GetInt ("backgrounds" + i);
		}
		//Update the shop UI
		UpdateBackgroundShop ();

	}

	//Each time user change the background update the background shop
	public void UpdateBackgroundShop(){
		//Set all selected signs to false
		for (int i = 0; i < numofbackgrounds; i++) {
			selectedBackground [i].SetActive (false);

			//if a theme has been purchased, deactivate the prices and buy buttons
			if (themes [i] == 1) {
				prices [i].SetActive (false);
				backgroundButton [i].image.sprite = backgroundImages [i];
			}
		}
		//Set the current theme in main menu and update the information
		switch (THEME) {
		case 0:
			selectedBackground [THEME].SetActive (true);
			mainmenu.SetTheme (THEME);
			levelmenu.UpdateMainInformation ();
			break;
		case 1:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		case 2:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		case 3:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		case 4:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		case 5:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		case 6:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		case 7:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		case 8:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		case 9:
			selectedBackground [THEME].SetActive (true);
			levelmenu.UpdateMainInformation ();
			mainmenu.SetTheme (THEME);
			break;
		}
		Debug.Log ("Store updated");
	}

	//Activate the purchase panel
	public void ShowPurchasePanel(int id){
		purchasePanel.SetActive (true);
		switch (id) {
		case 0:
			purchasePanel.SetActive (false);
			THEME = id;
			ZPlayerPrefs.SetInt ("THEME", id);
			ZPlayerPrefs.Save ();
			UpdateBackgroundShop ();
			break;
		case 1:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 100 gems?";
				selection = 1;

			} else {
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();
				Debug.Log ("background changed");

			}
			break;

		case 2:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 200 gems?";
				selection = 2;

			} else
			{
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();

			}
			break;
		case 3:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 300 gems?";
				selection = 3;
			} else
			{
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();
			}
			break;
		case 4:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 400 gems?";
				selection = 4;
			} else
			{
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();
			}
			break;
		case 5:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 500 gems?";
				selection = 5;

			} else {
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();
				Debug.Log ("background changed");

			}
			break;
		case 6:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 750 gems?";
				selection = 6;

			} else {
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();
				Debug.Log ("background changed");

			}
			break;
		case 7:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 1000 gems?";
				selection = 7;

			} else {
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();
				Debug.Log ("background changed");

			}
			break;
		case 8:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 1500 gems?";
				selection = 8;

			} else {
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();
				Debug.Log ("background changed");

			}
			break;
		case 9:
			if (themes [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 2000 gems?";
				selection = 9;

			} else {
				purchasePanel.SetActive (false);
				THEME = id;
				ZPlayerPrefs.SetInt ("THEME", id);
				ZPlayerPrefs.Save ();
				UpdateBackgroundShop ();
				Debug.Log ("background changed");

			}
			break;
		}
	}

	/**
	 * Depending on previous selection in on ShowPurchasePanel, now the user select either yes or no to buy selected background
	 * */
	public void BuyBackground(){
		//Get the total number of gems
		totalgems = ZPlayerPrefs.GetInt ("totalgems");
		Debug.Log (totalgems.ToString ());

		switch (selection) {
		case 1:
			if (totalgems >= 100) {
				totalgems = totalgems - 100;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds1", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
				Debug.Log ("Item purchased");
			} else {
				purchasePanelNoFunds.SetActive (true);
			}

			break;
		case 2:
			if (totalgems >= 200) {
				totalgems = totalgems - 200;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds2", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
				Debug.Log ("Item purchased");
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		case 3:
			if (totalgems >= 300) {
				totalgems = totalgems - 300;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds3", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
			}else 
				purchasePanelNoFunds.SetActive (true);
			break;  
		case 4:
			if (totalgems >= 400) {
				totalgems = totalgems - 400;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds4", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		case 5:
			if (totalgems >= 500) {
				totalgems = totalgems - 500;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds5", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		case 6:
			if (totalgems >= 750) {
				totalgems = totalgems - 750;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds6", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		case 7:
			if (totalgems >= 1000) {
				totalgems = totalgems - 1000;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds7", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		case 8:
			if (totalgems >= 1500) {
				totalgems = totalgems - 1500;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds8", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		case 9:
			if (totalgems >= 2000) {
				totalgems = totalgems - 2000;
				themes [selection] = 1;
				THEME = selection;
				ZPlayerPrefs.SetInt ("THEME", selection);
				ZPlayerPrefs.SetInt ("backgrounds9", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateBackgroundShop ();
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		}

		levelmenu.UpdateMainInformation();


	}
}
