using UnityEngine;
using UnityEngine.UI;

public class BallSelect : MonoBehaviour {

	public static int playerBall = 3;

	[SerializeField] private RectTransform panel;                         // To hold the ScrollPanel
	[SerializeField] private RectTransform center;                        // Center to compare the distance for each button
	[SerializeField] private Button[] button;

	private SceneController sceneController;
	private float[] distance;                           // All buttons distance to center array
	private float[] distReposition;                     // For Endless scroll
	private bool dragging = false;                      // Will be true while we drag the panel
	private int buttonDistance;                         // Will hold the distance between the buttons
	private int buttonLength;
	private int minButtonNum;                           // To hold the number of the button with smallest distance to center

	private void Start(){
		sceneController = GameObject.FindObjectOfType<SceneController>();
		buttonLength = button.Length;
		distance = new float[buttonLength];
		distReposition = new float[buttonLength];

		// Get distance between buttons
		buttonDistance = (int)Mathf.Abs(button[1].GetComponent<RectTransform>().anchoredPosition.x - button[0].GetComponent<RectTransform>().anchoredPosition.x);
	}

	private void Update(){
		Debug.Log(dragging);
		for (int i = 0; i < button.Length; i++) {
			distReposition[i] = center.GetComponent<RectTransform>().position.x - button[i].GetComponent<RectTransform>().position.x;  // For Endless scroll
			distance[i] = Mathf.Abs(distReposition[i]);

			if (distReposition[i] > 1000) {       //For Endless forward scroll
				float currentX = button[i].GetComponent<RectTransform>().anchoredPosition.x;
				float currentY = button[i].GetComponent<RectTransform>().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2(currentX + (buttonLength * buttonDistance), currentY);
				button[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
			}
			if (distReposition[i] < -1000) {      //For Endless reverse scroll
				float currentX = button[i].GetComponent<RectTransform>().anchoredPosition.x;
				float currentY = button[i].GetComponent<RectTransform>().anchoredPosition.y;

				Vector2 newAnchoredPos = new Vector2(currentX - (buttonLength * buttonDistance), currentY);
				button[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
			}
		}

		float minDistance = Mathf.Min(distance);    

		for (int j = 0; j < button.Length; j++){
			if (minDistance == distance[j]) {
				minButtonNum = j;
			}
		}

		if (!dragging) {
			//LerpToButton(minButtonNum * -buttonDistance);  //Old Lerp for buttons exact distance appart 
			LerpToButton(-button[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);  //New Lerp allows buttons to be all different distances appart.
		}
	}

	private void LerpToButton(float position) {
		float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
		Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

		panel.anchoredPosition = newPosition;
	}

	public void StartDrag(){ //Called from Event Trigger in Inspector
		dragging = true;
	}

	public void EndDrag(){ //Called from Event Trigger in Inspector
		dragging = false;
	}

	public void SelectBall(int ballType){ //Called from each ball button in Inspector
		playerBall = ballType;
		sceneController.LoadLevel("Main Menu");
	}


}
