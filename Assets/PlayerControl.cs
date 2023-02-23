using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
	[SerializeField] Transform LeftWall;
	[SerializeField] Transform RightWall;
	[SerializeField] Transform Ground1Spawn;
	[SerializeField] Transform GroundSpawn;
	[SerializeField] Transform LoseWin;
	[SerializeField] Transform PauseWin;
	[SerializeField] Grid Ground;
	[SerializeField] Grid Ground1;
	[SerializeField] float speedX;
	public static  float speedY;
	[SerializeField] List<Grid> TileMaps;
	[SerializeField] List<Transform> Spawners;
	static public bool isGame = true;
	public int Points = 0;
	public static float HorizontalMove = 0f;
	public float tilt = 0f;
	public float GroundLenght;
	public bool WPress = false; 
	public bool SPress = false;
	private void Start()
	{
		StartLevel();
	}
	// Update is called once per frame
	public void LevelStart()
	{
		Time.timeScale = 1f;
		PauseWin.gameObject.SetActive(false);
		isGame = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +0 );
	}
	public void StartLevel()
	{
		WPress = false; 
		SPress = false;
		speedX = 3;
		Points = 0;
		tilt = 6;
		speedY = 0.5f;
		LoseWin.gameObject.SetActive(false);
		GroundLenght = 1.9f;
		gameObject.SetActive(true);
		foreach (var i in Spawners)
		{
			if (i.GetChildCount() != 0)
			{
				for (int a = 0; a < i.GetChildCount() ; a++)
				{
					Destroy(i.GetChild(a).gameObject);
				}
			}	
			
		}
		if (Ground1Spawn.GetChildCount() != 0)
		{
			for (int a = 0; a < Ground1Spawn.GetChildCount() ; a++)
			{
				Destroy(Ground1Spawn.GetChild(a).gameObject);
			}
		}
		if (GroundSpawn.GetChildCount() != 0)
		{
			for (int a = 0; a < GroundSpawn.GetChildCount() ; a++)
			{
				Destroy(GroundSpawn.GetChild(a).gameObject);
			}
		}
		transform.GetComponent<SpriteRenderer>().sprite = DataScript.Car;
		
			var tile = TileMaps[UnityEngine.Random.Range(0, TileMaps.Count)];
			while (tile.tag != DataScript.LevelName)
			{
				tile = TileMaps[UnityEngine.Random.Range(0, TileMaps.Count)];
			}
			Ground = tile;
			while (tile.tag != DataScript.LevelName)
			{
				tile = TileMaps[UnityEngine.Random.Range(0, TileMaps.Count)];
			}
			Ground1 = tile;
		Ground = Instantiate(Ground, GroundSpawn);
		Ground1 = Instantiate(Ground1, Ground1Spawn);
		StartCoroutine(GroundScroll());
	}
	
	void Update()
    {
		if (isGame)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (Time.timeScale == 0)
				{
					Time.timeScale = 1f;
					PauseWin.gameObject.SetActive(false);
				}
				else
				{
					Time.timeScale = 0f;
					PauseWin.gameObject.SetActive(true);
				}
			}
			HorizontalMove = Input.GetAxisRaw("Horizontal") * speedX;
			transform.rotation = Quaternion.Euler(0, 0, HorizontalMove / speedX * -tilt + 90);
			//transform.position  = new Vector2(transform.position.x , transform.position.y + speedY * Time.deltaTime);
			if (Input.GetKeyDown(KeyCode.W))
			{
				WPress = true;

			}
			if (Input.GetKeyUp(KeyCode.W))
			{
				WPress = false;
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				SPress = true;

			}
			if (Input.GetKeyUp(KeyCode.S))
			{
				SPress = false;
			}
			if (speedY < 0.5f)
			{
				speedY = 0.5f;
			}
			//Ground.position = new Vector2(Ground.position.x, Mathf.Repeat(-Time.time * speedY, GroundLenght));
			if (Ground.transform.position.y < -40.3)
			{
				Destroy(Ground.gameObject);
					var tile = TileMaps[UnityEngine.Random.Range(0, TileMaps.Count)];
					while (tile.tag != DataScript.LevelName)
					{
						tile = TileMaps[UnityEngine.Random.Range(0, TileMaps.Count)];
					}
					Ground = tile;

				Ground = Instantiate(Ground, Ground1Spawn);
			}
			if (Ground1.transform.position.y < -40.3)
			{
				Destroy(Ground1.gameObject);
					var tile = TileMaps[UnityEngine.Random.Range(0, TileMaps.Count)];
					while (tile.tag != DataScript.LevelName)
					{
						tile = TileMaps[UnityEngine.Random.Range(0, TileMaps.Count)];
					}
					Ground1 = tile;
				Ground1 = Instantiate(Ground1, Ground1Spawn);
			}

			Ground.transform.Translate(Vector2.down * speedY * Time.deltaTime);
			Ground1.transform.Translate(Vector2.down * speedY * Time.deltaTime);
			transform.position = new Vector2(Mathf.Clamp(transform.position.x + HorizontalMove * Time.deltaTime, LeftWall.position.x + transform.localScale.x / 1.8f, RightWall.position.x - transform.localScale.x / 1.8f), transform.position.y);

		}

	}
	private void FixedUpdate()
	{

		
	}
	public IEnumerator GroundScroll() {
		while (isGame)
		{
			if (WPress)
			{
				speedY += 0.2f;
			}
			else
			{
				speedY -= speedY / 100 * 20;
			}
			if (SPress)
			{
				speedY -= speedY/100 * 40;
			}
			if (speedY < 3)
			{
				Points += 1;
			}
			else
			{
				Points += 2;
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.GetChild(0).gameObject.tag == "LoseZone")
		{
			gameObject.SetActive(false);
			LoseWin.gameObject.SetActive(true);
			isGame = false;
		}
	}

}
