using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BallController : MonoBehaviour {

	// Use this for initialization


	public float linearSpeed; // units / sec

	public float angle; // -90 .. 90  The trayectory angle ___\___
	private bool isMoving;
	private Vector3 moving;

	public Sprite[] ballsprites;

	private int currentball;

	void Start () {
		currentball = ZPlayerPrefs.GetInt ("CHARACTER");
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = ballsprites [currentball];
		angle = CannonController.angle;
		SetDirection (angle);

	}
	public void SetDirection(float ang){
		angle = ang+90;
		//transform.Rotate (new Vector3 (0, 0, angle));
		Debug.Log (angle);
		isMoving = true;
		moving = Vector3.right;
	}
	// Update is called once per frame
	void Update () {
		if (GameManager.state == GameManager.PLAYING&&isMoving) {

			this.transform.Translate (moving * this.linearSpeed * Mathf.Cos (Mathf.Deg2Rad * this.angle) * Time.deltaTime);
			this.transform.Translate (Vector3.up * this.linearSpeed * Mathf.Sin (Mathf.Deg2Rad * this.angle) * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "WallRight") {
			moving = Vector3.left;
			ContactPoint2D contact = other.contacts [0];
			Vector3 newDir = Vector3.zero;
			Vector3 curDir = transform.TransformDirection (Vector3.forward);
			newDir = Vector3.Reflect (curDir, contact.normal);
			transform.rotation = Quaternion.FromToRotation (Vector3.forward, newDir);
			this.angle = transform.rotation.eulerAngles.z + (angle - 360);	
		     
		}
		if (other.gameObject.tag == "WallLeft") {
			moving = Vector3.right;
			ContactPoint2D contact = other.contacts [0];
			Vector3 newDir = Vector3.zero;
			Vector3 curDir = transform.TransformDirection (Vector3.forward);
			newDir = Vector3.Reflect (curDir, contact.normal);
			transform.rotation = Quaternion.FromToRotation (Vector3.forward, newDir);
			this.angle = transform.rotation.eulerAngles.z + (angle - 360);	

		}
	}
}
