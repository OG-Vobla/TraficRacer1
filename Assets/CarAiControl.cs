using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAiControl : MonoBehaviour
{
	// Start is called before the first frame update
	// Update is called once per frame
	[SerializeField] float speedY;
	private void Start()
	{
		StartCoroutine(SpeedCreateCar());
	}
	void Update()
    {

		transform.Translate(Vector2.left * Time.deltaTime * (PlayerControl.speedY -  5 - speedY));
	}
	public IEnumerator SpeedCreateCar()
	{
		while (true)
		{

			speedY = Random.Range(10, 200) / 100;
			yield return new WaitForSeconds(4);
		}
	}

}
