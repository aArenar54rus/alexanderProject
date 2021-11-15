using Interface.Player;
using UnityEngine;


public class PlayerController : CharacterController
{
	[SerializeField] private PlayerInformationInterfaceManager _playerInformationInterface = default;

	[SerializeField] private float _immortalSecondsTime = default;

	[Space(10)]
	[SerializeField] private float failedScreenLoadTime = 1f;

	[Space(10)]
	[SerializeField] private ProgressController progressController = default;

	private float _immortalProgress = default;

	private bool _isImmortal = default;

	private float _blockedControlAfterDamageTimeMax = default;



	protected override void Start()
	{
		base.Start();

		_playerInformationInterface.InitializeHealthbar(CharacterParameters.MaxHealthPoints, CharacterParameters.HealthPoints);
		_playerInformationInterface.InitializeEndurancebar(CharacterParameters.MaxEndurancePoints, CharacterParameters.EndurancePoints, RealMoveLimiter);

		_immortalProgress = 0;
		_blockedControlAfterDamageTimeMax = 0;
		_isImmortal = false;
	}


	protected override void Update()
	{
		CheckImmortalAfterDamage();

		if (isDeath || isControlBlocked)
			return;

		if (Input.GetButton("Horizontal"))
		{
			Vector3 moveDirection = transform.right * Input.GetAxis("Horizontal");

			if (Input.GetKey(KeyCode.LeftShift))
			{
				CharacterRun(moveDirection);
			}
			else
			{
				CharacterWalk(moveDirection);
			}

			if (moveDirection.x < 0)
				CharacterAnimator.TurnLeft();
			else
				CharacterAnimator.TurnRight();
		}
		else
		{
			CharacterAnimator.SetIdleAnimation();
		}

		if (Input.GetButtonDown("Jump"))
		{
			CharacterJump();
		}

		if (!isRun)
			CharacterParameters.EnduranceRegeneration(enduranceRegenerationForce);

		_playerInformationInterface.UpdateEnduranceVisual(CharacterParameters.EndurancePoints);
	}


	public override void GetDamage(int damage)
	{
		if (_isImmortal)
			return;

		CharacterParameters.HealthPoints -= damage;
		_playerInformationInterface.UpdateHealthVisual(CharacterParameters.HealthPoints);
		isControlBlocked = true;

		if (CharacterParameters.HealthPoints <= 0)
		{
			MakeCharacterDead();
			Invoke(nameof(LoadFailedScreen), failedScreenLoadTime);
		}
		else
		{
			CharacterAnimator.SetTakeDamageAnimation();
			_isImmortal = true;
		}
	}


	public override void GetHealth(int addedHealth)
	{
		base.GetHealth(addedHealth);

		_playerInformationInterface.UpdateHealthVisual(CharacterParameters.HealthPoints);
	}


	private void LoadFailedScreen()
	{
		progressController.SetFailed();
	}


	private void CheckImmortalAfterDamage()
	{
		if (!_isImmortal || isDeath)
			return;

		_immortalProgress += Time.deltaTime;

		if (_immortalProgress >= _blockedControlAfterDamageTimeMax && isControlBlocked)
			isControlBlocked = false;

		if (_immortalProgress >= _immortalSecondsTime)
		{
			_isImmortal = false;
			_immortalProgress = 0;
		}
	}
}
