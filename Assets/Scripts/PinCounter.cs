using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public int LastSettledCount { get; private set; } = 10;

	[SerializeField] private Text pinCountDisplay;
	[SerializeField] private bool ballOutOfPlay = false;

	private int lastStandingCount = -1;
	private float lastChangeTime;

	private GameManager gameManager;

	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	void Update(){
		pinCountDisplay.text = CountStanding().ToString();
		if (ballOutOfPlay){
			pinCountDisplay.color = Color.red;
			CheckStanding();
		}
	}

	public void Reset() {
		LastSettledCount = 10;
	}

	public void PinsHaveSettled(){
		int pinFall = LastSettledCount - CountStanding();
		LastSettledCount = CountStanding();

		gameManager.Bowl(pinFall);

		lastStandingCount = -1; //Indicates pins have settled, and ball not back in box
		ballOutOfPlay = false;
		pinCountDisplay.color = Color.green;
	}

	private void OnTriggerExit(Collider collider){
		GameObject objectLeft = collider.gameObject;
		if (objectLeft.GetComponent<Ball>()){
			ballOutOfPlay = true;
		}
	}

	private void CheckStanding() {
		int currentStanding = CountStanding();
		if (currentStanding != lastStandingCount){
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		float settleTime = 3f; //How long to wait to consider pins settled
		if ((Time.time - lastChangeTime) > settleTime){ // If Last change >3s ago
			PinsHaveSettled();
		}
	}

	private int CountStanding(){
		int standing = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding()){
				standing++;
			}
		}
		return standing;
	}
}
