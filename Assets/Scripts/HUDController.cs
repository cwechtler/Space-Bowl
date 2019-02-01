using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	[SerializeField] private GameObject bumpers;
	[SerializeField] private Text bumperText;

	private ScoreDisplay scoreDisplay;
	private SoundManager soundManager;
	private Animator animator;
	private GameObject doubleText;

	private bool active = false;
	private int strikeCount = 0;

	private void Update(){
		SpecialAction();
	}

	private void Start(){
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
		soundManager = GameObject.FindObjectOfType<SoundManager>();
		doubleText = GameObject.Find("Double Text");
		animator = GetComponent<Animator>();
	}

	public void Bumpers(){ // Called from button in Inspector
		if (!active){
			bumpers.SetActive(true);
			active = true;
			bumperText.text = "Bumpers On";
		} else{
			bumpers.SetActive(false);
			active = false;
			bumperText.text = "Bumpers Off";
		}
		soundManager.SetButtonClip();
	}

	private void SpecialAction(){
		if (scoreDisplay.IsStrike == true) {
			strikeCount++;
		}
		if (scoreDisplay.IsStrike == true && strikeCount == 3) {
			strikeCount = 0;
			animator.SetTrigger("Turkey Trigger");
			soundManager.SetTurkeyClip();
			scoreDisplay.IsStrike = false;
			
		} else if (scoreDisplay.IsStrike == true){
			doubleText.SetActive(false);
			animator.SetTrigger("Strike Trigger");
			soundManager.SetStrikeClip();
			scoreDisplay.IsStrike = false;
			if (strikeCount == 2){
				doubleText.SetActive(true);
				soundManager.SetDoubleStrikeClip();
			}
		}
		if (scoreDisplay.IsSpare == true){
			animator.SetTrigger("Spare Trigger");
			soundManager.SetSpareClip();
			scoreDisplay.IsSpare = false;
		}
	}
}
