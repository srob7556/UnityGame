using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
//This Script controls the complete game play.
public class GameController : MonoBehaviour {
	public AudioManager2 audiomanager;
	public GameObject Car1,Car2;
	public GameObject[] Objects;
	GameObject ObjectGO;
	public float spawnWait;
	public float startWait;
	public static float speed;
	public float IncreaseInTimeSpeed;
	float[] XPosition = new float[8] {-2.45f,-1.75f, -1.05f,-0.35f,0.35f,1.05f,1.75f,2.45f};
	bool IsGameOver;

	private float lasttime;
	public static int Car1CurrentPosition,Car2CurrentPosition;
	// Use this for initialization
	void Start () {
		GameController.speed = 1.5f;
		//this sets timescale to 1 at start.
		Time.timeScale = 1;
		lasttime = 1;
		//set currentposition to 0 i.e. center
		Car1CurrentPosition = 2;
		Car2CurrentPosition = 6;
	}
	//this starts the spawn wave of the cubes and circles.
	IEnumerator SpawnWaves ()
	{
		//wait of startWait(int) seconds
		yield return new WaitForSeconds (startWait);
		while (IsGameOver==false) {
			for (int i = 0; i < 100; i++) {
				//Setting Object Position randomly between XPositions.
				float XPos = XPosition[Random.Range(0, XPosition.Length)];
				Vector3 ObjectPosition = new Vector3 (XPos, -6.5f, 0);
				//Randomly choose between cube & circle.
				ObjectGO=Objects[Random.Range (0, Objects.Length)];

					//create object at ObjectPosition.
					Instantiate (ObjectGO, ObjectPosition, Quaternion.identity);
					//Increase TimeScale
					Time.timeScale += IncreaseInTimeSpeed;
					lasttime = Time.timeScale;
					//spawnWait = startWait;

				//wait between next drop
				yield return new WaitForSeconds (spawnWait);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (IsGameOver == false) {
			Car1.GetComponent<Rigidbody2D> ().isKinematic = false;
			Car2.GetComponent<Rigidbody2D> ().isKinematic = false;
			//Action on left key Pressed
			//Action on left key Pressed
			if (Input.GetKeyDown ("left")) {
				LeftButton ();
			}//Action on right key pressed 
		else if (Input.GetKeyDown ("right")) {
				RightButton ();
			}
		} else {
			Car1.GetComponent<Rigidbody2D> ().isKinematic = true;
			Car2.GetComponent<Rigidbody2D> ().isKinematic = true;
		}
}
	
	public void StartGame(){
		StartCoroutine ("SpawnWaves");
		//Time.timeScale = lasttime;
		IsGameOver = false;
	}

	//In CurrentPosiiton 0 represent center, -1 left and 1 right.
	public void LeftButton(){
		Debug.Log ("Left button");
		//If at center move to left
		if (Car1.GetComponent<PlayerController> ().teleporting == false&&Car1CurrentPosition-1!=Car2CurrentPosition) {
			if (Car1CurrentPosition == 2) {
				//animate movemenet to -2.1 i.e left
				Car1.transform.DOMoveX (-2.45f, 0.5f);
				//set current position to -1 i.e. left.
				Car1CurrentPosition = 1;
				//If at right move to center
			} else if (Car1CurrentPosition == 3) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (-1.75f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 2;
			} else if (Car1CurrentPosition == 4) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (-1.05f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 3;
			} else if (Car1CurrentPosition == 6) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (0.35f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 5;
			} else if (Car1CurrentPosition == 7) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (1.05f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 6;
			} else if (Car1CurrentPosition == 8) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (1.75f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 7;
			}
		} 

		//Second car
		//If at center move to left
		if (Car2.GetComponent<PlayerController> ().teleporting == false&&Car2CurrentPosition-1!=Car1CurrentPosition) {
			if (Car2CurrentPosition == 2) {
				//animate movemenet to -2.1 i.e left
				Car2.transform.DOMoveX (-2.45f, 0.5f);
				//set current position to -1 i.e. left.
				Car2CurrentPosition = 1;
				//If at right move to center
			} else if (Car2CurrentPosition == 3) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (-1.75f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 2;
			} else if (Car2CurrentPosition == 4) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (-1.05f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 3;
			} else if (Car2CurrentPosition == 6) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (0.35f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 5;
			} else if (Car2CurrentPosition == 7) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (1.05f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 6;
			} else if (Car2CurrentPosition == 8) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (1.75f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 7;
			}
		}
	}

	public void RightButton(){
		Debug.Log ("Right button");
		//If at center move to left
		if (Car1.GetComponent<PlayerController> ().teleporting == false&&Car1CurrentPosition+1!=Car2CurrentPosition) {
			if (Car1CurrentPosition == 2) {
				//animate movemenet to -2.1 i.e left
				Car1.transform.DOMoveX (-1.05f, 0.5f);
				//set current position to -1 i.e. left.
				Car1CurrentPosition = 3;
				//If at right move to center
			} else if (Car1CurrentPosition == 3) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (-0.35f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 4;
			} else if (Car1CurrentPosition == 1) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (-1.75f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 2;
			} else if (Car1CurrentPosition == 6) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (1.75f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 7;
			} else if (Car1CurrentPosition == 5) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (1.05f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 6;
			} else if (Car1CurrentPosition == 7) {
				//animate movemenet to 0 i.e center
				Car1.transform.DOMoveX (2.45f, 0.5f);
				//set current position to 0 i.e. center.
				Car1CurrentPosition = 8;
			}
		}
		//Second car
		//If at center move to left
		if (Car2.GetComponent<PlayerController> ().teleporting == false&&Car2CurrentPosition+1!=Car1CurrentPosition) {
			if (Car2CurrentPosition == 1) {
				//animate movemenet to -2.1 i.e left
				Car2.transform.DOMoveX (-1.75f, 0.5f);
				//set current position to -1 i.e. left.
				Car2CurrentPosition = 2;
				//If at right move to center
			} else if (Car2CurrentPosition == 2) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (-1.05f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 3;
			} else if (Car2CurrentPosition == 3) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (-0.35f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 4;
			} else if (Car2CurrentPosition == 5) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (1.05f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 6;
			} else if (Car2CurrentPosition == 6) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (1.75f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 7;
			} else if (Car2CurrentPosition == 7) {
				//animate movemenet to 0 i.e center
				Car2.transform.DOMoveX (2.45f, 0.5f);
				//set current position to 0 i.e. center.
				Car2CurrentPosition = 8;
			}
		}
	}

	public void GameOver(){
		//sets is isGameOver to true
		IsGameOver = true;


		//Pause the time
		//Time.timeScale = 0;

		//Stop creating obstacles
		Debug.Log("Stop creating obstacles");

		StopCoroutine("SpawnWaves");

	}
}
