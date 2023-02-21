using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[SerializeField] Transform LeftWall;
	[SerializeField] Transform RightWall;
	[SerializeField] float speedX;
	[SerializeField] float speedY;
	public static float HorizontalMove = 0f;
	public float tilt = 0f;
	// Update is called once per frame
	void Update()
    {
		HorizontalMove = Input.GetAxisRaw("Horizontal") * speedX;
		transform.rotation = Quaternion.Euler(0,0, HorizontalMove/speedX * -tilt + 90);
		transform.position  = new Vector2(transform.position.x , transform.position.y + speedY * Time.deltaTime);
		transform.position = new Vector2(Mathf.Clamp(transform.position.x + HorizontalMove * Time.deltaTime, LeftWall.position.x + transform.localScale.x / 1.8f, RightWall.position.x - transform.localScale.x / 1.8f), transform.position.y);
	}
}
