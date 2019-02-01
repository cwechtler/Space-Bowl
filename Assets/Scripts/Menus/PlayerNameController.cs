using UnityEngine;
using UnityEngine.UI;

public class PlayerNameController : MonoBehaviour {

	public static string playerName;

	[SerializeField] private InputField iField;
	[SerializeField] private Toggle toggle;
	[SerializeField] private Text welcomeText;
	[SerializeField] private Text optionsText;
	[SerializeField] private Text WarningText;
	[SerializeField] private Text playerNameText;

	private Animator optionsAnimator;
	private Animator warningAnimator;

	private void Start(){     
		optionsAnimator = optionsText.GetComponent<Animator>();
		warningAnimator = playerNameText.GetComponent<Animator>();
		if (PlayerPrefsManager.GetPlayerRememberName() == "Yes"){
			playerName = PlayerPrefsManager.GetPlayerName();
			iField.text = playerName;
			toggle.isOn = true;
			welcomeText.text = "Welcome back " + playerName + " Good Luck!";
		} else {
			iField.text = playerName;
			toggle.isOn = false;
		}
	}

	private void Update(){
		if (iField.text == ""){
			toggle.isOn = false;
		}
	}

	public void MyName(string myName){ // called from player input Field in Inspector
		playerName = myName;
		if (playerName == "") {
			WarningAnimate();
		} else{
			if (myName == PlayerPrefsManager.GetPlayerName()) {
				welcomeText.text = "Welcome back " + myName + " Good Luck!";
			} else {
				welcomeText.text = "Hello " + myName + "! Please check out the options for some customizing.";
				optionsAnimator.SetTrigger("Blink Trigger");
			}
			if (playerName != null) {
				WarningText.text = "";
				warningAnimator.SetTrigger("Idle Trigger");
			}
			PlayerPrefsManager.SetPlayerName(playerName);
		}
	}

	public void RememberMe(bool remember){ // called from Remember me toggle in inspector
		if (remember == true && playerName != null) {
			PlayerPrefsManager.SetPlayerRememberName("Yes");
		}
		if(remember == false){
			PlayerPrefsManager.SetPlayerRememberName("No");
		}
	}

	public void WarningAnimate(){
		WarningText.text = "Please Enter Player Name";
		warningAnimator.SetTrigger("Blink Trigger");
	}
}
