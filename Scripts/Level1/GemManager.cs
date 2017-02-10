using UnityEngine;
using System.Collections;

public class GemManager : MonoBehaviour {

	public Vector3 startPos;



	// Use this for initialization
	void Start () {
		
		startPos = new Vector3 (Random.Range (-2.5f, -0.2f), Random.Range (4.4f, -2.9f), 0);
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.tag == "Ball") {
			ScoreManager.gemsno += 1;
			CircleAuto.startPosGem = startPos;
			CircleAuto.isGemSpawn = true;
			Destroy(this.gameObject);

		}

	}
}
