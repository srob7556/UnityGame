using UnityEngine;
using System.Collections;
//This scripts controls the speed of circles and cubes.
public class Mover : MonoBehaviour {
	float speed;
	// Use this for initialization
	void Start () {
		//it derives the value of speed from the GameController.
		//GameObject go = GameObject.Find ("GameController");
		//GameController speedController = go.GetComponent <GameController> ();
		speed =GameController.speed; //speedController.speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//it moves the circles and cubes.
		if (GameManager.state == GameManager.PLAYING)
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, speed);
		else
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			
	}
}
