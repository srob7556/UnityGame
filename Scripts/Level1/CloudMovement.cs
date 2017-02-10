using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	public Vector2 speed = new Vector2 (-2, 0);
	private Vector2 startposition = new Vector2 (4.6f, 3.7f);
		private float ypos;
	private float xpos;
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D> ().velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.state == GameManager.PLAYING)
			this.GetComponent<Rigidbody2D> ().velocity = speed;
		else
			this.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Wall") {
			ypos = Random.Range (0.5f, 3.8f);
			startposition.y = ypos;
			this.GetComponent<Rigidbody2D> ().transform.position = startposition;
		} else if (col.tag == "Wall1") {
			xpos = -4.4f;
			ypos = 3;
			startposition.x = xpos;
			startposition.y = ypos;
			this.GetComponent<Rigidbody2D> ().transform.position = startposition;
		}

		Debug.Log ("Cloud trigger");
	}
}
