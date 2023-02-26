using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusScript : MonoBehaviour
{
	// Start is called before the first frame update
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(collision.gameObject.tag);
		if (collision.gameObject.tag == "Player" && PlayerControl.speedY > 6)
		{
			PlayerControl.BonusActive = true;
		}

	}
}
