using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

	public Vector3 startPos;
	public Sprite[] circlesprites;

	private int currenthoop;
	// Use this for initialization
	void Start () {
		currenthoop = ZPlayerPrefs.GetInt ("CHARACTER");
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = circlesprites [currenthoop];
		startPos = new Vector3 (Random.Range (-2.5f, -0.2f), Random.Range (4.4f, -2.9f), 0);
	}
	
	void OnTriggerEnter2D(Collider2D col){
	
	if (col.tag == "Ball") {
			//Destroy(col.gameObject);
			ScoreManager.Score++;
			if(ScoreManager.balls<7)
			ScoreManager.balls++;
			ScoreManager.timer+=4;
			CircleAuto.startPosition=startPos;
			CircleAuto.isSpawn=true;
		

			Destroy(this.gameObject);
		
		}
	
	}
}
