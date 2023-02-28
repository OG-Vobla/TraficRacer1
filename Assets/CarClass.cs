using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarClass
{

	private string name;
	private int cost;
	private float maxSpeed;
	private float speed;
	private int isBuy;

	public CarClass(string name, int cost, float maxSpeed, float speed,int isBuy)
	{
		this.name = name;
		this.cost = cost;
		this.maxSpeed = maxSpeed;
		this.speed = speed;
		this.isBuy = isBuy;
	}
	static public void SaveCar(List<CarClass> cars)
	{
		foreach (var car in cars)
		{
			PlayerPrefs.SetInt(car.name + "Cost", car.cost);
			PlayerPrefs.SetFloat(car.name + "MaxSpeed", car.maxSpeed);
			PlayerPrefs.SetFloat(car.name + "Speed", car.speed);
			PlayerPrefs.SetInt(car.name + "IsBuy", car.isBuy);
		}
	}
	static public CarClass GetCar(string name)
	{
		if (PlayerPrefs.HasKey(name + "Cost"))
		{
			return new CarClass(name, PlayerPrefs.GetInt(name + "Cost"), PlayerPrefs.GetFloat(name + "MaxSpeed"), PlayerPrefs.GetFloat(name + "Speed"), PlayerPrefs.GetInt(name + "IsBuy"));
		}
		else
		{
			return null;
		}
	}
	static public void BuyCar(string name)
	{
		if (PlayerPrefs.HasKey(name + "Cost"))
		{
			PlayerPrefs.SetInt(name + "IsBuy", 0);
		}
	}
	public string Name { get => name; set => name = value; }
	public int Cost { get => cost; set => cost = value; }
	public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
	public float Speed { get => speed; set => speed = value; }
	public bool IsBuy
	{
		get
		{
			return (isBuy == 0);
		}

		set
		{
			if (value)
			{
				isBuy= 1;
			}
			else 
			{
				isBuy = 0;
			}
		}
	}
}
