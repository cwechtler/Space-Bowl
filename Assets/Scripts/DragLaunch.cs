using UnityEngine;

[RequireComponent (typeof (Ball))]
public class DragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;
	private PinSetter pinSetter;

	void Start () {
		ball = GetComponent<Ball>();
		pinSetter = GameObject.FindObjectOfType<PinSetter>();	
	}

	public void MoveStart(float xNudge){
		if (!ball.InPlay) {
			float xPos = Mathf.Clamp(ball.transform.position.x + xNudge, -40f, 40f); ;
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			ball.transform.position = new Vector3(xPos, yPos, zPos);
		}
	}

	public void DragStart(){
		// Capture time & position of drag start
		if (!ball.InPlay){
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd() {
		//Launch the ball
		if (!ball.InPlay){
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;
			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ );
			if (launchSpeedZ >= 20 && pinSetter.SetterAction == false) {
				ball.Launch(launchVelocity);
			}
		}
	}
}
