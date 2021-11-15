using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowController : MonoBehaviour
{
	[SerializeField] private float _changeGrowTime = default;

	[SerializeField] private SpriteRenderer _grow = default;

	[SerializeField] private Sprite[] _growSprites = default;


	private float _changeGrowTimeProcess = default;

	private int _growSpritesCounter = default;
	private int _growSpritesCounterMax = default;



	private void Start()
	{
		_changeGrowTimeProcess = 0;
		_growSpritesCounter = 0;
		_growSpritesCounterMax = _growSprites.Length;
	}


	private void Update()
	{
		_changeGrowTimeProcess += Time.deltaTime;

		if (!(_changeGrowTimeProcess >= _changeGrowTime))
			return;

		_changeGrowTimeProcess = 0;

		_grow.sprite = _growSprites[_growSpritesCounter];

		_growSpritesCounter++;
		if (_growSpritesCounter >= _growSpritesCounterMax)
			_growSpritesCounter = 0;
	}
}
