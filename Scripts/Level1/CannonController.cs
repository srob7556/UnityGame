using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CannonController : MonoBehaviour {
	public GameObject ball;
	public Transform ballposition;


	public GameObject buttonLeft, buttonRight;
	private Vector3 startPos;
	public static float angle;

	private bool isPressedLeft;
	private bool isPressedRight;

	private int extra;
	// Use this for initialization
	void Start () {
		isPressedLeft = false;
		isPressedRight = false;
		//extra=PlayerPrefs.GetInt("extraballs");

	}
	protected virtual void OnEnable()
	{
		
		// Hook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap += OnFingerTap;
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
	}

	protected virtual void OnDisable()
	{
		
		// Unhook into the OnFingerTap event
		Lean.LeanTouch.OnFingerTap -= OnFingerTap;
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
	}

	public void OnFingerTap(Lean.LeanFinger finger)
	{
		
		if (finger.IsOverGui == false&&GameManager.state==GameManager.PLAYING&&Lean.LeanTouch.GuiInUse==false)
			{
				
			isPressedLeft = false;
			isPressedRight = false;
			InstantiateBall ();
			}

	}
	public void OnFingerSwipe(Lean.LeanFinger finger)
	{

			// Store the swipe delta in a temp variable
			var swipe = finger.SwipeDelta;

			if (swipe.x < -Mathf.Abs(swipe.y))
			{
			isPressedLeft = true;
			isPressedRight = false;
			}

			if (swipe.x > Mathf.Abs(swipe.y))
			{
			isPressedRight = true;
			isPressedLeft = false;
			}



	}
	void Update(){
		
			
		if (isPressedLeft && transform.rotation.eulerAngles.z > 280 && transform.rotation.eulerAngles.z < 330)
				this.gameObject.transform.Rotate (0, 0, 0.3f);
		else 
			if (isPressedRight && transform.rotation.eulerAngles.z > 280 && transform.rotation.eulerAngles.z < 330) {

				this.gameObject.transform.Rotate (0, 0, -0.3f);
		    
			}
		
		if (transform.rotation.eulerAngles.z <= 280) {
			this.gameObject.transform.Rotate (0, 0, 1f);
			isPressedLeft = false;
			isPressedRight = false;
		} else if (transform.rotation.eulerAngles.z >= 330) {
			isPressedLeft = false;
			isPressedRight = false;
			this.gameObject.transform.Rotate (0, 0, -1f);
		}
	}

	public void InstantiateBall(){
		//Instantiate (ball);
		if (ScoreManager.balls > 0 && GameManager.state == GameManager.PLAYING) {
			CannonController.angle=transform.rotation.eulerAngles.z;
			 
			startPos=ballposition.transform.position;
			Instantiate(ball,startPos,Quaternion.Euler(new Vector3(0,0,0)));
			ScoreManager.currentballs++;
			ScoreManager.balls=ScoreManager.balls-1;
			Debug.Log ("current balls: " + ScoreManager.currentballs.ToString ());

			/*if(extra>0){
				extra=extra-1;
				PlayerPrefs.SetInt("extraballs",extra);
				PlayerPrefs.Save();
			}*/
		}
	}

	public void RotateRightTrue(){
		
		isPressedRight = true;

		Debug.Log (transform.rotation.eulerAngles.z);
		
		
	}
	public void RotateRightFalse(){
		isPressedRight = false;
	}

	public void RotateLeftTrue(){
		
		isPressedLeft = true;
	}

	public void RotateLeftFalse(){
		
		isPressedLeft = false;
	}


}
