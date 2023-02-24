using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCarScript : MonoBehaviour
{
	// Start is called before the first frame update

	[SerializeField] List<Sprite> Cars;
	[SerializeField] GameObject CarPrefab;
	public bool isCar = false;
	private void Start()
	{
		StartCoroutine(SpawnCar());

	}
	public IEnumerator SpawnCar()
	{
		while (true)
		{
			if (!isCar)
			{
				var car = Instantiate(CarPrefab, transform);
				car.GetComponent<SpriteRenderer>().sprite = Cars[Random.Range(0, Cars.Count - 1)];
			}
			yield return new WaitForSeconds(Random.Range(0.5f,3.5f));
		}


	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "BotCar")
		{
			isCar = true;
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "BotCar")
		{
			isCar = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "BotCar")
		{
			isCar = false;
		}
	}
}
