using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string MUSIC_VOLUME_KEY = "music_volume";
    const string SFX_VOLUME_KEY = "sfx_volume";
    const string HIGHSCORE_KEY = "high_score";
    const string HIGHSCORE_NAME_KEY = "high_score_name";
    const string PLAYER_NAME_KEY = "player_name";
    const string PLAYER_REMEMBER_NAME_KEY = "player_remember_name";

    public static void SetMasterVolume(float volume) {
        if (volume >= -40f && volume <= 1.000001f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume(){
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetMusicVolume(float volume){
        if (volume >= -40f && volume <= 1.000001f)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        } else{
            Debug.LogError("Music volume out of range");
        }
    }

    public static float GetMusicVolume(){
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
    }

    public static void SetSFXVolume(float volume){
        if (volume >= -40f && volume <= 1.000001f){
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        } else{
            Debug.LogError("SFX volume out of range");
        }
    }

    public static float GetSFXVolume(){
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY);
    }

    public static void SetHighScore(string name, int score){
        int newScore;
        int oldScore;
        string newName;
        string oldName;
        
        newScore = score;
        newName = name;

        for (int i = 0; i < 5; i++){
            if (PlayerPrefs.HasKey(i + "high_score")){
                if (PlayerPrefs.GetInt(i + "high_score") < newScore){
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(i + "high_score");
                    oldName = PlayerPrefs.GetString(i + "high_score_name");
                    PlayerPrefs.SetInt(i + "high_score", newScore);
                    PlayerPrefs.SetString(i + "high_score_name", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            } else{
                PlayerPrefs.SetInt(i + "high_score", newScore);
                PlayerPrefs.SetString(i + "high_score_name", newName);
                newScore = 0;
                newName = "";
            }
        }
    }

    public static void SetPlayerName(string playerName){
        PlayerPrefs.SetString(PLAYER_NAME_KEY, playerName);
    }

    public static string GetPlayerName(){
        return PlayerPrefs.GetString(PLAYER_NAME_KEY);
    }

    public static void SetPlayerRememberName(string playerRememberName){
        PlayerPrefs.SetString(PLAYER_REMEMBER_NAME_KEY, playerRememberName);
    }

    public static string GetPlayerRememberName()
    {
        return PlayerPrefs.GetString(PLAYER_REMEMBER_NAME_KEY);
    }

    public void DeleteAllPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

    public void DeletePlayerPrefsMusicKey(){
        PlayerPrefs.DeleteKey("music_choice");
    }
}
