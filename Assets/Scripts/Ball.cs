using UnityEngine;

public class Ball : MonoBehaviour {

	private bool inPlay = false;
	private bool headPinHit = false;

	private Vector3 ballStartPos;
	private Quaternion ballStartRotation;
	private Rigidbody rigidBody;
	private SoundManager soundManager;
	private PinCounter pinCounter;
	private Animator animator;
	private GameObject hud;
	private GameObject floor;
	private int playSoundDelay = 0;
	private int headPinSoundDelay = 0;
	private Vector3 ballVelocity;

	public bool InPlay{get {return inPlay;}}
	public bool HeadPinHit{get {return headPinHit;}}

	private void Start (){
		soundManager = GameObject.FindObjectOfType<SoundManager>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		hud = GameObject.Find("HUD");
		floor = GameObject.Find("Floor");
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity = false;
		ballStartPos = transform.position;
		ballStartRotation = transform.rotation;
	}

	public void Launch(Vector3 velocity){
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;       
	   
		hud.SetActive(false);
		ballVelocity = velocity;
	}

	public void Reset(){
		hud.SetActive(true);
		inPlay = false;       
		transform.position = ballStartPos;
		transform.rotation = ballStartRotation;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
		headPinHit = false;
		animator.SetTrigger("ResetTrigger");
		playSoundDelay = 0;
		headPinSoundDelay = 0;
	}

	private void OnCollisionEnter(Collision collision){
		AudioSource ballRoll = GetComponent<AudioSource>();
		GameObject objectHit = collision.collider.gameObject;
		GameObject headPin1 = GameObject.Find("Bowling Pin 1");
		if (objectHit == headPin1 && pinCounter.LastSettledCount >= 6 && headPinSoundDelay == 0 && ballVelocity.z >= 290){
			headPinSoundDelay++;
			headPinHit = true;
			soundManager.SetHeadPinHitClip();
		}
		if (objectHit == floor){
			playSoundDelay++;
			if (!ballRoll.isPlaying && playSoundDelay == 1){
				ballRoll.Play();             
			}
		}
	}
}