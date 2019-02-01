using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public bool SetterAction { get; private set; } = false;

	[SerializeField] private GameObject pinPrefab;
	[SerializeField] private Text waitIndicator;

	private Animator animator;
	private PinCounter pinCounter;
	private GameManager gameManager;
	private Animator waitAnimate;

	private void Start(){
		animator = GetComponent<Animator>();
		waitAnimate = waitIndicator.GetComponent<Animator>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
		waitAnimate.enabled = false;
	}

	public void PerformAction(ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy){
			animator.SetTrigger("TidyTrigger");
			SetterAction = true;
			Wait();
		} else if (action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset){
			animator.SetTrigger("ResetTrigger");
			pinCounter.Reset();
			SetterAction = true;
			Wait();
		} else if (action == ActionMaster.Action.EndGame){
			animator.SetTrigger("ClearTrigger");
			SetterAction = true;
			gameManager.IsGameOver = true;
		}
	}

	public void RaisePins(){ // Called from Animation
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding();
		}
	}

	public void LowerPins(){ // Called from Animation
		SetterAction = false;
		Bowl();
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower();
		}
	}

	public void RenewPins(){// Called from Animation
		GameObject oldPinsObject = GameObject.Find("Pins(Clone)");
		Instantiate(pinPrefab, new Vector3(0, 5, 1829), Quaternion.identity);
		Destroy(oldPinsObject);
		SetterAction = false;
		Bowl();
	}

	private void Wait() {
		waitIndicator.text = "Wait";
		waitAnimate.enabled = true;
	}

	private void Bowl() {
		waitIndicator.text = "";
		waitAnimate.enabled = false;
	}
}

