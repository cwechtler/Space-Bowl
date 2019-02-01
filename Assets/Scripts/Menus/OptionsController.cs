using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public static bool random = false;

	[SerializeField] private Slider masterVolume;
	[SerializeField] private Slider musicVolume;
	[SerializeField] private Slider sfxVolume;
	[SerializeField] private Dropdown dropDown;
	[SerializeField] private Toggle loopToggle;
	[SerializeField] private Toggle shuffleToggle;

	private SoundManager soundManager;
	private SceneController sceneController;

	private void Start () {
		soundManager = GameObject.FindObjectOfType<SoundManager>();
		sceneController = GameObject.FindObjectOfType<SceneController>();
		SetVolumeSliders();
	}	

	private void Update () {
		soundManager.ChangeMasterVolume(masterVolume.value);
		soundManager.ChangeMusicVolume(musicVolume.value);
		soundManager.ChangeSFXVolume(sfxVolume.value);
		dropDown.value = SoundManager.musicPlaying;
		loopToggle.isOn = soundManager.MusicAudioSource.loop;
		shuffleToggle.isOn = random;
	}

	private void SetVolumeSliders() {
		if (PlayerPrefs.HasKey("master_volume")){
			masterVolume.value = PlayerPrefsManager.GetMasterVolume();
		} else{
			masterVolume.value = 0f;
		}
		if (PlayerPrefs.HasKey("music_volume")){
			musicVolume.value = PlayerPrefsManager.GetMusicVolume();
		} else{
			musicVolume.value = -20f;
		}
		if (PlayerPrefs.HasKey("sfx_volume")){
			sfxVolume.value = PlayerPrefsManager.GetSFXVolume();
		} else{
			sfxVolume.value = -20f;
		}
	}

	public void SaveVolumeSetingsOnExit(string name) { // Called in Inspector from all option menu exit buttons
		PlayerPrefsManager.SetMasterVolume(masterVolume.value);
		PlayerPrefsManager.SetMusicVolume(musicVolume.value);
		PlayerPrefsManager.SetSFXVolume(sfxVolume.value);
		sceneController.LoadLevel(name);

	}

	public void SetDefaults() { // Called from defaults button in Inspector
		masterVolume.value = 0f;
		musicVolume.value = -20f;
		sfxVolume.value = -20f;
		soundManager.MusicChanger(0);
		dropDown.value = 0;
		random = false;
	}

	public void MusicSelect(int musicChoice){  // Called from dropdown in inspector
		soundManager.MusicChanger(musicChoice);
	}

	public void Shuffle(bool shuffle){ // called from shuffle toggle in inspector
		random = shuffle;
	}
}
