using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProgressController : MonoBehaviour
{
	[SerializeField] private GameOverManager gameOverManager = default;


	private int findSecretChestsCount = default;



	private void Awake()
	{
		findSecretChestsCount = 0;
	}


	public void AddFindSecretChest() =>
		findSecretChestsCount++;


	public void SetFailed()
	{
		gameOverManager.OpenGameOverMenu();
	}
}
