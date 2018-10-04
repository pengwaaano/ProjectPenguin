using System;
using Classes;
using UnityEngine;
using UnityEngine.UI;

public class PenguinProgressSlider : MonoBehaviour
{
	private float FillTime = 1.0f;
	private bool started = false;

	private Slider _slider;
	
	void Start ()
	{
		_slider = GetComponent<Slider>();
		Reset();
	}
	
	public void startTimer(Penguin p)
	{
		if (!started)
		{
			FillTime = p.getTimeToComplete();
			Reset();
			started = true;
		}
	}

	public void finishTimer()
	{
		if (started)
		{
			started = false;
			Reset();
		}
	}

	public void Reset()
	{
		_slider.minValue = Time.time;
		_slider.maxValue = Time.time + FillTime;
		_slider.value = Time.time;
	}
	
	void Update ()
	{
		if (started)
		{
			_slider.value = Time.time;
			if (Math.Abs(_slider.value - _slider.maxValue) < 0)
			{
				started = false;
			}
		}
	}
}