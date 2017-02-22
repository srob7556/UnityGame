using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
// This controls the action after cube or circle touches the car. 
public class PlayerController : MonoBehaviour {
	public AudioManager2 audiomanager;
	public GameManager gamemanager;



	private float xposition;
	public GameObject character;
	public Sprite[] characters;
	public bool teleporting=false;
	private int n;
	void Start(){
		ZPlayerPrefs.Initialize("group123", "happyapplications2016");
		teleporting = false;
		n = ZPlayerPrefs.GetInt ("CHARACTER");
		Debug.Log (n.ToString ());
		character.GetComponent<SpriteRenderer>().sprite = characters [n];
	}

	void OnTriggerEnter2D(Collider2D other) {
		//On circle touching the car, it will play scoreUp audio & send message to gamecontroller to add score .
	if(other.gameObject.tag == "Point"){
		Destroy(other.gameObject);
			audiomanager.PlayPoint ();
			ScoreManager.Score++;
	}
		//On cube touching the car, it will send message to gamecontroller to end the game.
	if(other.gameObject.tag == "Obstacle"){
			Destroy(other.gameObject);
			audiomanager.PlayGameOver ();

			ScoreManager.lives--;
			this.gameObject.SetActive (false);
	}
		if(other.gameObject.tag == "Gear"){
			Destroy(other.gameObject);
			audiomanager.PlayPoint ();
			ScoreManager.gearsno++;

		}
		//If touches the floor, reposition it to top
		if(other.gameObject.tag == "Floor"){
			
			this.gameObject.transform.position=new Vector3(this.transform.position.x,5.3f,0);
		}
		//Teleportation to left
		if (other.gameObject.tag == "BridgeLeft") {
			teleporting = true;
			xposition = this.GetComponent<Transform> ().position.x;
			float newpos = xposition - 2.1f;
			this.GetComponent<Transform> ().transform.DOMoveX (newpos, 1.6f);
			if (this.gameObject.tag == "Car1")
				GameController.Car1CurrentPosition = GameController.Car1CurrentPosition - 3;
			else if(this.gameObject.tag=="Car2")
				GameController.Car2CurrentPosition = GameController.Car2CurrentPosition - 3;
			StartCoroutine (ChangeTeleportation (1.6f));
		}
		//Teleportation to Right
		if (other.gameObject.tag == "BridgeRight") {
			teleporting = true;
			xposition = this.GetComponent<Transform> ().position.x;
			float newpos = xposition + 2.1f;
			this.GetComponent<Transform> ().transform.DOMoveX (newpos, 1.6f);
			if (this.gameObject.tag == "Car1")
				GameController.Car1CurrentPosition = GameController.Car1CurrentPosition + 3;
			else if(this.gameObject.tag=="Car2")
				GameController.Car2CurrentPosition = GameController.Car2CurrentPosition + 3;
			StartCoroutine (ChangeTeleportation (1.6f));
		}
}

	public bool GetTeleportState(){
		return teleporting;
	}
	public IEnumerator ChangeTeleportation(float teltime){
		yield return new WaitForSeconds(teltime);

		teleporting=false;
	}
}