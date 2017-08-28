using UnityEngine;
using System.Collections;

public class PauseMenu4 : MonoBehaviour {
	
	public bool paused=false;
	
	public GUIStyle style1;
	public GUIStyle style2;
	public GUIStyle style3;
	public GUIStyle style4;
	public Transform right;
	public Transform left;
	public Transform top;
	public Transform bottom;

	void Awake()
	{
		/*if(iPhone.generation==iPhoneGeneration.iPhone5)
		{
			right.position=new Vector3(2.5f, right.position.y,0);
			left.position=new Vector3(-2.52f, left.position.y,0);
		}
		if(iPhone.generation==iPhoneGeneration.iPadMini1Gen)      
		{
			right.position=new Vector3(3.31f, right.position.y,0);
			left.position= new Vector3(-3.35f, right.position.y,0);
			top.localScale=new Vector3(3.9f, top.localScale.y,1);
			bottom.localScale=new Vector3(3.9f, top.localScale.y,1);
			PlayerPrefs.SetFloat("right", 2.65f);
			PlayerPrefs.Save();
		}*/
		if(Screen.width==480 && Screen.height==800)
		{
			right.position=new Vector3(2.66f, right.position.y,0);
			left.position= new Vector3(-2.685f, right.position.y,0);
			//top.localScale=new Vector3(3.9f, top.localScale.y,1);
			//bottom.localScale=new Vector3(3.9f, top.localScale.y,1);
			PlayerPrefs.SetFloat("right", 2f);
			PlayerPrefs.Save();
		}
		if(Screen.width==480 && Screen.height==854)
		{
			right.position=new Vector3(2.49f, right.position.y,0);
			left.position= new Vector3(-2.515f, right.position.y,0);
			//top.localScale=new Vector3(3.9f, top.localScale.y,1);
			//bottom.localScale=new Vector3(3.9f, top.localScale.y,1);
			PlayerPrefs.SetFloat("right", 1.83f);
			PlayerPrefs.Save();
		}
		if(Screen.width==600 && Screen.height==1024)
		{
			right.position=new Vector3(2.6f, right.position.y,0);
			left.position= new Vector3(-2.63f, right.position.y,0);
			//top.localScale=new Vector3(3.9f, top.localScale.y,1);
			//bottom.localScale=new Vector3(3.9f, top.localScale.y,1);
			PlayerPrefs.SetFloat("right", 1.98f);
			PlayerPrefs.Save();
		}
		if(Screen.width==800 && Screen.height==1280)
		{
			right.position=new Vector3(2.78f, right.position.y,0);
			left.position= new Vector3(-2.79f, right.position.y,0);
			//top.localScale=new Vector3(3.9f, top.localScale.y,1);
			//bottom.localScale=new Vector3(3.9f, top.localScale.y,1);
			PlayerPrefs.SetFloat("right", 2.15f);
			PlayerPrefs.Save();
		}
		if(Screen.width==720 && Screen.height==1280)
		{
			right.position=new Vector3(2.51f, right.position.y,0);
			left.position= new Vector3(-2.51f, right.position.y,0);
			//top.localScale=new Vector3(3.9f, top.localScale.y,1);
			//bottom.localScale=new Vector3(3.9f, top.localScale.y,1);
			PlayerPrefs.SetFloat("right", 1.82f);
			PlayerPrefs.Save();
		}
	}

	void Update()
	{
		
		if(paused)
		{
			Time.timeScale=0;
			
		}
		
		else
		{
			
			Time.timeScale=1;
			
			
		}
	}
	
	void OnGUI()
	{
		
		if(GUI.Button(new Rect(Screen.width*.1f,Screen.width*.1f,Screen.width*.15f, Screen.width*.15f),"",style1))
		{
			paused=!paused;
		}
		if(paused)
			Pause();
	}
	
	void Pause()
	{
		
		if(GUI.Button(new Rect(Screen.width*.3f,Screen.width*.1f,Screen.width*.15f, Screen.width*.15f),"",style2))
		{
			paused=!paused;
		}
		
		if(GUI.Button(new Rect(Screen.width*.5f,Screen.width*.1f,Screen.width*.15f, Screen.width*.15f),"",style3))
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
		
		
		if(GUI.Button(new Rect(Screen.width*.7f,Screen.width*.1f,Screen.width*.15f, Screen.width*.15f),"",style4))
		{
			PlayerPrefs.SetInt("score", 0);
			PlayerPrefs.SetInt("pscore", 0);
			Application.LoadLevel(0);
			
		}
		
	}
}
