using UnityEngine;
using System.Collections;

public class bricktrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag=="laser")
		{
			Destroy(col.gameObject);
			PlayerPrefs.SetInt("count", PlayerPrefs.GetInt("count")+1);
			PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score")+100);
			PlayerPrefs.Save();
			Destroy(gameObject);
		}
	}
}
