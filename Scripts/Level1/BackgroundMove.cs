using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour
{
	private float speed;

	// Use this for initialization
	void Start()
	{Application.targetFrameRate = 60;
		speed = GameController.speed;

	}
	
	// Update is called once per frame
	void FixedUpdate()
	{   
		if (transform.localPosition.y >=83.5f)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, -83.5f, transform.localPosition.z);
		}

		if (GameManager.state == GameManager.PLAYING)
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 1.5f);
		else
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
	}
	
	

}
