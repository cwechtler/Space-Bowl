using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
	static SoundManager instance = null;

	public static int musicPlaying;
	public static float clipLength;
	public static int clipPlayed;

	public AudioSource MusicAudioSource { get { return musicAudioSource; } }

	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private AudioSource musicAudioSource;
	[SerializeField] private AudioSource SFXAudioSource;

	[SerializeField] private AudioClip[] musicArray;
	[SerializeField] private AudioClip headPinHit;
	[SerializeField] private AudioClip strikeClip;
	[SerializeField] private AudioClip doubleStrikeClip;
	[SerializeField] private AudioClip turkeyClip;
	[SerializeField] private AudioClip spareClip;
	[SerializeField] private AudioClip buttonClick;

	private void Awake(){
		if (instance != null){
			Destroy(gameObject);
		} else{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start () {
		SetPrefsVolume();
		musicPlaying = Random.Range(0, musicArray.Length);
		musicAudioSource.clip = musicArray[musicPlaying] ;
		musicAudioSource.PlayDelayed(1);
		clipLength = musicAudioSource.clip.length + 1;
		clipPlayed = musicPlaying;
	}

	private void Update(){
		ShuffleMusic();
	}

	public void SetButtonClip(){
		SFXAudioSource.PlayOneShot(buttonClick, .6f);
	}
	public void SetHeadPinHitClip(){
		SFXAudioSource.clip = headPinHit;
		SFXAudioSource.Play();
	}
	public void SetStrikeClip() {
		SFXAudioSource.clip = strikeClip;
		SFXAudioSource.Play();
	}
	public void SetDoubleStrikeClip(){
		SFXAudioSource.clip = doubleStrikeClip;
		SFXAudioSource.Play();
	}
	public void SetTurkeyClip(){
		SFXAudioSource.clip = turkeyClip;
		SFXAudioSource.Play();
	}
	public void SetSpareClip(){
		SFXAudioSource.clip = spareClip;
		SFXAudioSource.Play();
	}

	public void ChangeMasterVolume(float volume) {
		audioMixer.SetFloat("MasterVolume", volume);
		if (volume == -40f){
			audioMixer.SetFloat("MasterVolume", -80f);
		}
	}

	public void ChangeMusicVolume(float volume){
		audioMixer.SetFloat("MusicVolume", volume);
		if (volume == -40f){
			audioMixer.SetFloat("MusicVolume", -80f);
		}
	}

	public void ChangeSFXVolume(float volume){
		audioMixer.SetFloat("SFXVolume", volume);
		if (volume == -40f){
			audioMixer.SetFloat("SFXVolume", -80f);
		}
	}

	public void MusicChanger(int musicChoice){
		musicPlaying = musicChoice;
		musicAudioSource.clip = musicArray[musicPlaying];
		clipPlayed = musicPlaying;
		if (!musicAudioSource.isPlaying) {
			musicAudioSource.Stop();
			musicAudioSource.PlayDelayed(.5f);
			clipLength = musicAudioSource.clip.length + .5f;
		}
	}

	private void ShuffleMusic(){
		clipLength -= Time.deltaTime;
		if (OptionsController.random) {
			musicAudioSource.loop = false;
			if (clipLength <= 0) {
				musicPlaying = Random.Range(0, musicArray.Length);
				if (clipPlayed == musicPlaying) {
					musicPlaying = Random.Range(0, musicArray.Length);
				}
				else {
					musicAudioSource.clip = musicArray[musicPlaying];
					clipLength = musicAudioSource.clip.length + 2;
					musicAudioSource.PlayDelayed(2);
					clipPlayed = musicPlaying;
				}
			}
		}
		if (!OptionsController.random) {
			musicAudioSource.loop = true;
		}
	}

	private void SetPrefsVolume() {
		if (PlayerPrefs.HasKey("master_volume")){
			audioMixer.SetFloat("MasterVolume", PlayerPrefsManager.GetMasterVolume());
		} else{
			audioMixer.SetFloat("MasterVolume", 0f);
		}
		if (PlayerPrefs.HasKey("music_volume")){
			audioMixer.SetFloat("MusicVolume", PlayerPrefsManager.GetMusicVolume());
		} else{
			audioMixer.SetFloat("MusicVolume", -20f);
		}
		if (PlayerPrefs.HasKey("sfx_volume")){
			audioMixer.SetFloat("SFXVolume", PlayerPrefsManager.GetSFXVolume());
		} else{
			audioMixer.SetFloat("SFXVolume", -20f);
		}
	}
}
