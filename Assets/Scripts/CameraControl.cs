using UnityEngine;

public class CameraControl : MonoBehaviour {

	private Ball ball;
	private Vector3 offSet;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		offSet = transform.position - ball.transform.position;
	}
	
	void Update (){
		if (ball.transform.position.z <= 1650f){
			transform.position = ball.transform.position + offSet;
		}
	}
}
