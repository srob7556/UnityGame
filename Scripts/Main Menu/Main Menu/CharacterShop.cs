using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Security.Cryptography;
public class CharacterShop : MonoBehaviour {

	//MainMenu information
	public LevelMenu main;

	//Save the current character selected
	private int CHARACTER=0;

	//Keep  all the UI elements that needs to be updated
	public Button[] characterButton;
	public Sprite[] characterImages;
	public GameObject[] selectedCharacter;
	public GameObject purchasePanel,purchaseSuccess;
	public Text gemInformation;
	public GameObject[] prices;
	public GameObject purchasePanelNoFunds;


	//Keep details about buttons if they have been bought or not
	//10 different characters
	private int[] characters=new int[10];
	private int numofcharacters=10;
	private int totalgems;
	private int selection;
	void Start () {
		//Initialize Zplayerprefs secure
		ZPlayerPrefs.Initialize("group123", "happyapplications2016");

		//Set current character
		CHARACTER = ZPlayerPrefs.GetInt ("CHARACTER");
		selectedCharacter [CHARACTER].SetActive (true);
		for (int i = 0; i < numofcharacters; i++) {
			characters [i] = ZPlayerPrefs.GetInt ("characters" + i);
		}
		UpdateCharacterShop ();
	
	}

	//Each time user change the character update the character shop
	public void UpdateCharacterShop(){
		for (int i = 0; i < numofcharacters; i++) {
			selectedCharacter [i].SetActive (false);
			Debug.Log (characters [i].ToString ());
			if (characters [i] == 1) {
				prices [i].SetActive (false);
				characterButton [i].image.sprite = characterImages [i];
			}
		}
		switch (CHARACTER) {
		case 0:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 1:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 2:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 3:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 4:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 5:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 6:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 7:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 8:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		case 9:
			selectedCharacter [CHARACTER].SetActive (true);
			break;
		
		
		}
		Debug.Log ("Store updated");
	}


	public void ShowPurchasePanel(int id){
		purchasePanel.SetActive (true);
		switch (id) {
		case 0:
			purchasePanel.SetActive (false);
			CHARACTER = id;
			ZPlayerPrefs.SetInt ("CHARACTER", id);
			ZPlayerPrefs.Save ();
			UpdateCharacterShop ();
			break;
		case 1:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 100 gems?";
				selection = 1;

			} else {
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();
				Debug.Log ("character changed");

			}
			break;

		case 2:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 150 gems?";
				selection = 2;

			} else
			{
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();

			}
			break;
		case 3:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 200 gems?";
				selection = 3;
			} else
			{
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();
			}
			break;
		case 4:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 250 gems?";
				selection = 4;
			} else
			{
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();
			}
			break;
		case 5:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 300 gems?";
				selection = 5;
			} else
			{
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();
			}
			break;
		case 6:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 350 gems?";
				selection = 6;
			} else
			{
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();
			}
			break;
		case 7:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 400 gems?";
				selection = 7;
			} else
			{
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();
			}
			break;
		case 8:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 450 gems?";
				selection = 8;
			} else
			{
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();
			}
			break;
		case 9:
			if (characters [id] == 0) {
				gemInformation.text = "Are you sure you want to make this purchase for 500 gems?";
				selection = 9;
			} else
			{
				purchasePanel.SetActive (false);
				CHARACTER = id;
				ZPlayerPrefs.SetInt ("CHARACTER", id);
				ZPlayerPrefs.Save ();
				UpdateCharacterShop ();
			}
			break;
		

		

		
		}
	}

	public void BuyCharacter(){
		totalgems = ZPlayerPrefs.GetInt ("totalgems");
		Debug.Log (totalgems.ToString ());
		switch (selection) {
		case 1:
			if (totalgems >= 100) {
				totalgems = totalgems - 100;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters1", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateCharacterShop ();
				Debug.Log ("Item purchased");
			} else {
				purchasePanelNoFunds.SetActive (true);
			}

			break;
		case 2:
			if (totalgems >= 200) {
				totalgems = totalgems - 200;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters2", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateCharacterShop ();
				Debug.Log ("Item purchased");
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		case 3:
			if (totalgems >= 250) {
				totalgems = totalgems - 250;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters3", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateCharacterShop ();
			}else 
				purchasePanelNoFunds.SetActive (true);
			break;  
		case 4:
			if (totalgems >= 300) {
				totalgems = totalgems - 300;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters4", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateCharacterShop ();
			}else
				purchasePanelNoFunds.SetActive (true);
			break;
		case 5:
			if (totalgems >= 500) {
				totalgems = totalgems - 500;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters5", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateCharacterShop ();
			}else 
				purchasePanelNoFunds.SetActive (true);
			break;
		case 6:
			if (totalgems >= 750) {
				totalgems = totalgems - 750;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters6", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateCharacterShop ();
			}else 
				purchasePanelNoFunds.SetActive (true);
			break;
		case 7:
			if (totalgems >= 1000) {
				totalgems = totalgems - 1000;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters7", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateCharacterShop ();
			}else 
				purchasePanelNoFunds.SetActive (true);
			break;
		case 8:
			if (totalgems >= 1500) {
				totalgems = totalgems - 1500;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters8", 1);
				ZPlayerPrefs.Save ();
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);
				UpdateCharacterShop ();
			}else 
				purchasePanelNoFunds.SetActive (true);
			break;
		case 9:
			if (totalgems >= 2000) {
				totalgems = totalgems - 2000;
				characters [selection] = 1;
				CHARACTER = selection;
				ZPlayerPrefs.SetInt ("CHARACTER", selection);
				ZPlayerPrefs.SetInt ("characters9", 1);
				ZPlayerPrefs.SetInt ("totalgems", totalgems);
				ZPlayerPrefs.Save ();
				purchaseSuccess.SetActive (true);

				UpdateCharacterShop ();
			}else 
				purchasePanelNoFunds.SetActive (true);
			break;
		
		}

		main.UpdateMainInformation ();
	
	
	}
}
