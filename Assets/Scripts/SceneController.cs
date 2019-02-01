using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	[SerializeField] private Text WarningText;
	[SerializeField] private Text playerNameText;

	private SoundManager soundManager;
	private PlayerNameController playerNameController;


	private void Start(){
		soundManager = GameObject.FindObjectOfType<SoundManager>();
		playerNameController = GameObject.FindObjectOfType<PlayerNameController>();
	}

	public void LoadLevel(string name) {
		if (PlayerNameController.playerName == null || PlayerNameController.playerName == ""){
			playerNameController.WarningAnimate();
		} else{          
			soundManager.SetButtonClip();
			SceneManager.LoadScene(name);
		}      
	}

	public void LoadNextLevel(){
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void OnApplicationQuit(){
		Debug.Log("Quit Request");
		soundManager.SetButtonClip();
		Application.Quit();
	}
}
