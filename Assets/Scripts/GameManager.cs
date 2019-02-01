using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

	public bool IsGameOver { get; set; } = false;

	[SerializeField] private Text playerText;
	[SerializeField] private Text playTimer;
	[SerializeField] private GameObject[] playerBalls;

	private List<int> bowls = new List<int>();

	private PinSetter pinSetter;
	private PinCounter pinCounter;
	private Ball ball;
	private DragLaunch dragLaunch;
	private ScoreDisplay scoreDisplay;
	private GameObject gameOverPanel;

	private string playerName;
	private int finalScore;
	private float inPlayTime = 25f;

	private void Awake(){
		GetPlayerBall();
	}

	private void Start(){
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
		ball = GameObject.FindObjectOfType<Ball>();
		dragLaunch = GameObject.FindObjectOfType<DragLaunch>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
		gameOverPanel = GameObject.Find("GameOverPanel");
		gameOverPanel.SetActive(false);
		playerName = PlayerNameController.playerName;
		playerText.text = playerName;
		
	}
	private void Update(){
		if (ball.InPlay){
			inPlayTime -= Time.deltaTime;
			if (inPlayTime <= 0f){
				inPlayTime = 0f;
				pinCounter.PinsHaveSettled();
			}
		}
		int text = Mathf.RoundToInt(inPlayTime);
		playTimer.text = text.ToString();
	}

	public void Bowl(int pinFall){
		try{
			bowls.Add(pinFall);
			ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
			pinSetter.PerformAction(nextAction);
		} catch{
			Debug.LogWarning("Something went wrong in Bowl");
		} try{
			scoreDisplay.FillBowls(bowls);
			scoreDisplay.FillFrameScores(ScoreMaster.ScoreCumulative(bowls));           
		} catch{
			Debug.LogWarning("FillRollCard Failed");
		}
		ball.Reset();
		inPlayTime = 25f;
		GameOver();
	}

	public void GameOver(){
		if (IsGameOver){     
			finalScore = ScoreDisplay.score[9];
			gameOverPanel.SetActive(true);
			PlayerPrefsManager.SetHighScore(playerName, finalScore);
		}
	}

	public void DragStartLink() {
		dragLaunch.DragStart();
	}
	public void DragEndLink() {
		dragLaunch.DragEnd();
	}
	public void MoveStartLink(float Nudge_x) {
		dragLaunch.MoveStart(Nudge_x);
	}

	private void GetPlayerBall(){
		Vector3 startBallPos = new Vector3(0, 20, 30);
		int ballSelect = BallSelect.playerBall;
		for (int i = 0; i < playerBalls.Length; i++) {
			if (ballSelect == i) {
				GameObject.Instantiate(playerBalls[i], startBallPos, Quaternion.identity);
			}
		}
	}
}



