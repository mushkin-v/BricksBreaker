using UnityEngine;
using System.Collections;

public class mainGUI : MonoBehaviour {



	public GUIStyle BG;
	public GUIStyle Play;
	public GUIStyle QuitGame;


	void Awake()
	{
		Time.timeScale = 1;
	}

	void OnGUI()
	{
		
		GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", BG);
		
		
		if (GUI.Button (new Rect (Screen.width * 0.2f, Screen.height * 0.4f, Screen.width * 0.6f, Screen.height * 0.1f), "", Play)) 
		{

			PlayerPrefs.SetInt("level" , 1);
			PlayerPrefs.SetInt("bricks", 33);
			PlayerPrefs.SetInt("count",0);
			PlayerPrefs.SetInt("game", 1);
			PlayerPrefs.SetInt("speed",6);
			PlayerPrefs.SetInt("ballcount", 0);
			PlayerPrefs.SetFloat("right", 2.3f);
			PlayerPrefs.SetInt("score", 0);
			PlayerPrefs.SetInt("pscore", 0);
			PlayerPrefs.Save();
			Application.LoadLevel(1);
		}
		

		
		if (GUI.Button (new Rect (Screen.width * 0.2f, Screen.height * 0.6f, Screen.width * 0.6f, Screen.height * 0.1f), "", QuitGame)) 
		{
			Application.Quit();
		}


	}

}
