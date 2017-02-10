using UnityEngine;
using System.Collections;

public class CircleAuto : MonoBehaviour {
	public GameObject nextCircle;
	public GameObject nextGem;
	public static Vector3 startPosGem;
	public static bool isSpawn=false;
	public static bool isGemSpawn=false;
	public static Vector3 startPosition;
	// Use this for initialization
	void Start () {
		CircleAuto.isSpawn = false;
		CircleAuto.isGemSpawn = false;

		
		
	}

	void Update(){
	if (isSpawn&&GameManager.state==GameManager.PLAYING) {
			Instantiate(nextCircle, startPosition, Quaternion.identity);
			CircleAuto.isSpawn =false;

		}
		if (ScoreManager.balls <=4&&isGemSpawn&&GameManager.state==GameManager.PLAYING) {
			Instantiate (nextGem, startPosGem, Quaternion.identity);
			CircleAuto.isGemSpawn = false;
		}
	
	}
	

}
