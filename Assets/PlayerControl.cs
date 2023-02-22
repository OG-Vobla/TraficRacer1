using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[SerializeField] Transform LeftWall;
	[SerializeField] Transform RightWall;
	[SerializeField] Transform Ground;
	[SerializeField] Transform Ground1;
	[SerializeField] float speedX;
	[SerializeField] float speedY;
	public static float HorizontalMove = 0f;
	public float tilt = 0f;
	public float GroundLenght;
	public bool WPress = false;
	// Update is called once per frame
	private void Start()
	{
		StartCoroutine(GroundScroll());
	}
	void Update()
    {
		HorizontalMove = Input.GetAxisRaw("Horizontal") * speedX;
		transform.rotation = Quaternion.Euler(0,0, HorizontalMove/speedX * -tilt + 90);
		//transform.position  = new Vector2(transform.position.x , transform.position.y + speedY * Time.deltaTime);
		if (Input.GetKeyDown(KeyCode.W))
		{
			WPress = true;
			
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			WPress = false;
		}
		//Ground.position = new Vector2(Ground.position.x, Mathf.Repeat(-Time.time * speedY, GroundLenght));
		if (Ground.position.y < -18.35)
		{

			Ground.transform.position = new Vector2(Ground.transform.position.x, 34.93f);
		}
		if (Ground1.position.y < -18.35)
		{

			Ground1.transform.position = new Vector2(Ground1.transform.position.x, 34.93f);
		}
		Ground.Translate(Vector2.down * speedY * Time.deltaTime);
		Ground1.Translate(Vector2.down * speedY * Time.deltaTime);
		transform.position = new Vector2(Mathf.Clamp(transform.position.x + HorizontalMove * Time.deltaTime, LeftWall.position.x + transform.localScale.x / 1.8f, RightWall.position.x - transform.localScale.x / 1.8f), transform.position.y);

	}
	private void FixedUpdate()
	{
		

	}
	public IEnumerator GroundScroll() {
		while (true)
		{
			if (WPress)
			{
				speedY += 0.2f;
			}
			else
			{
				speedY -= 0.2f;
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}
