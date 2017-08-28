using UnityEngine;
using System.Collections;

public class bottom : MonoBehaviour {

	public GUIStyle replay;
	public GUIStyle home;
	public GUIStyle finish;
	public GUIStyle score;
	bool flag=false;
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag=="ball")
		{
			if(PlayerPrefs.GetInt("ballcount")<=0)
			{
				flag=true;
			}
			else
			{
				Destroy(col.gameObject);
				PlayerPrefs.SetInt("ballcount", PlayerPrefs.GetInt("ballcount")-1);
				PlayerPrefs.Save();
			}
		}
		Destroy(col.gameObject);
	}


	void OnGUI()
	{
		if(flag)
		{
			if(GUI.Button(new Rect(Screen.width*.1f, Screen.height*.6f, Screen.width*.38f, Screen.height*.08f), "", replay))
			{
				Time.timeScale=1;
				PlayerPrefs.SetInt("level", 1);
				PlayerPrefs.SetInt("ballcount", 0);
				PlayerPrefs.SetInt("count", 0);
				PlayerPrefs.SetInt("score", 0);
				PlayerPrefs.SetInt("pscore", 0);
				PlayerPrefs.Save();
				Application.LoadLevel(Application.loadedLevel);
			}
			if(GUI.Button(new Rect(Screen.width*.52f, Screen.height*.6f, Screen.width*.38f, Screen.height*.08f), "", home))
			{
				PlayerPrefs.SetInt("score", 0);
				PlayerPrefs.SetInt("pscore", 0);
				PlayerPrefs.Save();
				Application.LoadLevel(0);
			}
			if(GUI.Button(new Rect(Screen.width*.1f, Screen.height*.2f, Screen.width*.8f, Screen.height*.35f), "", finish))
			{
				
			}
			GUI.Label(new Rect(Screen.width*.45f, Screen.height*.42f, Screen.width*.1f, Screen.height*.08f), PlayerPrefs.GetInt("pscore").ToString(), score);

			//Invoke("gameover1", 2);
		}
	}
}
