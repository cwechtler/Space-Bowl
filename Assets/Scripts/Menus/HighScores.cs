using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

	[SerializeField] private Text[] highScoreText;
	[SerializeField] private Text[] highScoreNameText;

	private int[] highScore = new int[5];
	private string[] playerName = new string[5];

	private void Start(){
		GetHighScores();
	}

	private void Update(){
		UpdateHighScores();
	}

	private void GetHighScores(){
		for (int i = 0; i < 5; i++){
			highScore[i] = PlayerPrefs.GetInt(i + "high_score");
			playerName[i] = PlayerPrefs.GetString(i + "high_score_name");
		}
	}

	private void UpdateHighScores() {
		for (int i = 0; i < 5; i++){
			highScoreText[i].text = highScore[i].ToString();
			highScoreNameText[i].text = playerName[i];
		}
	}
}
