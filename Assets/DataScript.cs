using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataScript : MonoBehaviour
{
	public static string LevelName = "Desert";
	[SerializeField] List<Sprite> Cars;
	[SerializeField] SpriteRenderer CarSkinTra;
	[SerializeField] Transform SelectLevelTra;
	[SerializeField] Transform SelectCarTra;
	[SerializeField] Transform PlayBtn;
	public static Sprite Car;
	int count;

	public void PlayPressBtn()
	{
		SelectLevelTra.gameObject.SetActive(true);
		PlayBtn.gameObject.SetActive(false);
	}
	public void SelectLevel(string newLevelName)
	{
		LevelName = newLevelName;
		SelectCarTra.gameObject.SetActive(true);
		SelectLevelTra.gameObject.SetActive(false);
		count = 0;
		CarSkinTra.sprite = Cars[0];
	}
	public void NextCarBtn()
	{
		if (count + 1 != Cars.Count- 1)
		{
			count++;
			CarSkinTra.sprite = Cars[count];

		}
	}
	public void BackCarBtn()
	{
		if (count - 1 > -1)
		{
			count--;
			CarSkinTra.sprite = Cars[count];
		}
	}
	public void GoMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	public void SelectCar()
	{
		Car = Cars[count];
		SceneManager.LoadScene("SampleScene");
	}
}
