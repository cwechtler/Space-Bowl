using UnityEngine;

public class Pin : MonoBehaviour{

	[SerializeField] private float standingThreshold = 3f;
	[SerializeField] private float distanceToRaise = 8f;

	private Rigidbody rigidBody;
	private Ball ball;
	private int ballHit = 0;

	void Start(){
		rigidBody = GetComponent<Rigidbody>();
		ball = GameObject.FindObjectOfType<Ball>();
		ballHit = 0;
	}

	public void RaiseIfStanding(){
		if (IsStanding()){
			rigidBody.useGravity = false;
			transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
			transform.rotation = Quaternion.Euler(270f, 0, 0);
		}
	}

	public void Lower(){
		if (IsStanding()){
			transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
			rigidBody.useGravity = true;
		}
	}

	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold){
			return true;
		} else{
			return false;
		}
	}

	private void OnCollisionEnter(Collision collision){
		AudioSource pinHit = GetComponent<AudioSource>();
		GameObject objectHit = collision.collider.gameObject;
		if (objectHit.GetComponent<Ball>()){
			if (ball.HeadPinHit == false  && ball.InPlay == true) {
				if (objectHit.GetComponent<Ball>() && ballHit == 0){
					ballHit++;
					pinHit.Play();
				}
			}
		}
		if (objectHit.GetComponent<Pin>()) {
			if (ball.HeadPinHit == false && ball.InPlay == true){
				pinHit.Play();
			}
		}
	}
}

