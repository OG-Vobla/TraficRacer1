using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataScript : MonoBehaviour
{
	public static string LevelName = "Desert";
	[SerializeField] List<Sprite> Cars;
	[SerializeField] List<string> CarNames;
	[SerializeField] SpriteRenderer CarSkinTra;
	[SerializeField] Transform SelectLevelTra;
	[SerializeField] Transform SelectCarTra;
	[SerializeField] Transform PlayBtn;
	[SerializeField] Text SpeedText;
	[SerializeField] Text MaxSpeedText;
	[SerializeField] Text Money;
	[SerializeField] Text CostText;
	[SerializeField] Text NameText;
	[SerializeField] Text BuyText;
	public static Sprite Car;
	public static CarClass SelectingCar;
	int count;

	private void Start()
	{
		/*		List<CarClass> NewCars = new List<CarClass>();
				foreach (var i in CarNames)
				{
					NewCars.Add(new CarClass(i, Random.Range(1, 10) * 100, Random.Range(8, 14) * 10, Random.Range(1f, 8f) / 10f, 1));
					Debug.Log(NewCars[NewCars.Count - 1].Cost);
					Debug.Log(NewCars[NewCars.Count - 1].Speed);
					Debug.Log(NewCars[NewCars.Count - 1].MaxSpeed);
				}
				CarClass.SaveCar(NewCars);*//*
		CarClass.BuyCar("Стандартная");
		PlayerPrefs.SetInt("Money", 1000);*/

	}
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
		CarSkinTra.sprite = Cars[count];
		NameText.text = CarNames[count];
		var newCar = CarClass.GetCar(CarNames[count]);
		SpeedText.text = newCar.Speed.ToString();
		MaxSpeedText.text = newCar.MaxSpeed.ToString();
		Money.text = PlayerPrefs.GetInt("Money").ToString();
		if (newCar.IsBuy)
		{
			BuyText.text = "Машина куплена";
		}
		else
		{
			BuyText.text = "Машина не куплена";
			CostText.text = newCar.Cost.ToString();
		}
		SelectingCar = newCar;
	}
	public void NextCarBtn()
	{
		if (count + 1 != Cars.Count- 1)
		{
			count++;
			CarSkinTra.sprite = Cars[count];
			NameText.text = CarNames[count];
			var newCar = CarClass.GetCar(CarNames[count]);
			SpeedText.text = newCar.Speed.ToString();
			MaxSpeedText.text = newCar.MaxSpeed.ToString();
			if (newCar.IsBuy)
			{
				BuyText.text = "Машина куплена";
				CostText.text = "0";
			}
			else
			{
				BuyText.text = "Машина не куплена";
				CostText.text = newCar.Cost.ToString();
			}
			SelectingCar = newCar;
		}
	}
	public void BackCarBtn()
	{
		if (count - 1 > -1)
		{
			count--;
			CarSkinTra.sprite = Cars[count];
			NameText.text = CarNames[count];
			var newCar = CarClass.GetCar(CarNames[count]);
			SpeedText.text = newCar.Speed.ToString();
			MaxSpeedText.text = newCar.MaxSpeed.ToString();
			if (newCar.IsBuy)
			{
				BuyText.text = "Машина куплена";
				CostText.text = "0";
			}
			else
			{
				BuyText.text = "Машина не куплена";
				CostText.text = newCar.Cost.ToString();
			}
			SelectingCar = newCar;
		}
	}
	public void GoMenu()
	{
		SceneManager.LoadScene("Menu");
	}
	public void RefrechCarInfo() {
		var newCar = CarClass.GetCar(CarNames[count]);
		SpeedText.text = newCar.Speed.ToString();
		MaxSpeedText.text = newCar.MaxSpeed.ToString();
		if (newCar.IsBuy)
		{
			BuyText.text = "Машина куплена";
			CostText.text = "0";
		}
		else
		{
			BuyText.text = "Машина не куплена";
			CostText.text = newCar.Cost.ToString();
		}
		SelectingCar = newCar;
	}
	public void SelectCar()
	{
		if (SelectingCar.IsBuy)
		{
			Car = Cars[count];
			SceneManager.LoadScene("SampleScene");
		}
		else
		{
			if (PlayerPrefs.GetInt("Money") >= SelectingCar.Cost)
			{
				Car = Cars[count];
				PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - SelectingCar.Cost);
				Money.text = PlayerPrefs.GetInt("Money").ToString();
				CarClass.BuyCar(SelectingCar.Name);

				Debug.Log(PlayerPrefs.GetInt("Money").ToString());
				RefrechCarInfo();
				SceneManager.LoadScene("SampleScene");
			}
		}
		
		
	}
}
