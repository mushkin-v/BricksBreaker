using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public Transform ball;
	public Rigidbody2D laser;
	bool flag=false;
	float nextlaunch = 0f;
	public bool gameover=false;
	public GUIStyle style1;
	Transform big;
	public Rigidbody2D balls;
	public GUIStyle replay;
	public GUIStyle home;
	public GUIStyle finish;
	public GUIStyle score;

	void Awake()
	{
		PlayerPrefs.GetInt("speed", 3);
		PlayerPrefs.SetInt("count",0);
		PlayerPrefs.Save();
	}
	// Use this for initialization
	void Start () 
	{
		big=GameObject.FindWithTag("ball").GetComponent<Transform>();
		balls=GameObject.FindWithTag("ball").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.y==-3f)
		{
			//player movement
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			if(ray.GetPoint(1).x<PlayerPrefs.GetFloat("right") && ray.GetPoint(1).x>(-1)*PlayerPrefs.GetFloat("right") && ray.GetPoint(1).y<=-2)
			{
				transform.position= new Vector2(ray.GetPoint(1).x, transform.position.y);
			}
		}

		//paddle scaling
		if(transform.localScale.x==.25f || transform.localScale.x==.45f)
		{
			Invoke("scaling", 8);
		}

		//ball scaling
		if(big.localScale.x==.6f)
		{
			Invoke("ballscaling", 8);
		}

		//laser instantiation
		if(flag && Time.time>=nextlaunch)
		{
			nextlaunch=Time.time+.2f;
//			audio.Play();
			Rigidbody2D laserclone=(Rigidbody2D)Instantiate(laser, new Vector3(transform.position.x+.5f, -2.8f), Quaternion.identity);
			laserclone.velocity=new Vector2(transform.position.x+.5f, 10)*3;
			Rigidbody2D laserclone1=(Rigidbody2D)Instantiate(laser, new Vector3(transform.position.x-.5f, -2.8f), Quaternion.identity);
			laserclone1.velocity=new Vector2(transform.position.x-.5f, 10)*3; 
			Invoke("flagcheck", 5);
		}

	}

	void ballscaling()
	{
		big.localScale= new Vector2(.2f, .2f);

	}

	void scaling()
	{
		transform.localScale= new Vector2(.35f, transform.localScale.y);
	}

	void flagcheck()
	{
		flag=false;
//		audio.Stop();
	}

	//diversion ball in random direction when hit the paddle(player)
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag=="ball")
		{
			col.gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(Random.Range(-2f,2f), Random.Range(1,4f)).normalized*PlayerPrefs.GetInt("speed");
		}
	}


	//power functionalities
	void OnTriggerEnter2D(Collider2D col)
	{
			if(col.gameObject.tag=="ballsbrick")
			{
				Destroy(col.gameObject);
				Instantiate(ball, new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity);
				PlayerPrefs.SetInt("ballcount", PlayerPrefs.GetInt("ballcount")+1);
				PlayerPrefs.Save();
			}
			if(col.gameObject.tag=="laserbrick")
			{
				Destroy(col.gameObject);
				flag=true;
			}
			if(col.gameObject.tag=="fastbrick")
			{
				Destroy(col.gameObject);
				PlayerPrefs.SetInt("speed", 10);
				PlayerPrefs.Save();
				Rigidbody2D ballclone = GameObject.Find("ball").GetComponent<Rigidbody2D>();
				ballclone.velocity=ballclone.velocity.normalized*PlayerPrefs.GetInt("speed");
			}
			if(col.gameObject.tag=="slowbrick")
			{
				Destroy(col.gameObject);
				PlayerPrefs.SetInt("speed", 4);
				PlayerPrefs.Save();
				Rigidbody2D ballclone = GameObject.Find("ball").GetComponent<Rigidbody2D>();
				ballclone.velocity=ballclone.velocity.normalized*PlayerPrefs.GetInt("speed");
			}
		if(col.gameObject.tag=="death")
		{
			gameover=true;
			Destroy(col.gameObject);

		}
		if(col.gameObject.tag=="expand")
		{
			transform.localScale= new Vector2(.45f, transform.localScale.y);
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag=="shrink")
		{
			transform.localScale= new Vector2(.25f, transform.localScale.y);
			Destroy(col.gameObject);
		}
		if(col.gameObject.tag=="bigball")
		{
			big.localScale=new Vector2(big.localScale.x * 6/2, big.localScale.y * 6/2);
			Destroy(col.gameObject);
		}
	}


	//gameover gui (also attached on bottom script)
	void OnGUI()
	{
		if(gameover)
		{

		if(GUI.Button(new Rect(Screen.width*.1f, Screen.height*.6f, Screen.width*.38f, Screen.height*.08f), "", replay))
		{
				Time.timeScale=1;
				PlayerPrefs.SetInt("level", 1);
				Application.LoadLevel(Application.loadedLevel);
				PlayerPrefs.SetInt("ballcount", 0);
				PlayerPrefs.SetInt("count", 0);
				PlayerPrefs.SetInt("score", 0);
				PlayerPrefs.SetInt("pscore", 0);
				PlayerPrefs.Save();
		}
		if(GUI.Button(new Rect(Screen.width*.52f, Screen.height*.6f, Screen.width*.38f, Screen.height*.08f), "", home))
		{
				PlayerPrefs.SetInt("score", 0);
				PlayerPrefs.SetInt("pscore", 0);
				PlayerPrefs.Save();
				Application.LoadLevel(0);
		}
			GUI.Box(new Rect(Screen.width*.1f, Screen.height*.2f, Screen.width*.8f, Screen.height*.35f), "", finish);

		GUI.Label(new Rect(Screen.width*.45f, Screen.height*.43f, Screen.width*.1f, Screen.height*.08f), PlayerPrefs.GetInt("pscore").ToString(), score);
				balls.velocity=Vector2.zero.normalized;
				
		}

	}
	
}
