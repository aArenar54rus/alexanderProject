using System.Collections;
using UnityEngine;


public class CharacterAnimator : MonoBehaviour
{
	private const float STANDART_SPEED = 1f;



	[SerializeField] private Animator _characterAnimator = default;

	[SerializeField] private SpriteRenderer spriteRenderer = default;

	private readonly string isMoveParameterName = "isMove";
	private readonly string jumpTriggerName = "jump";
	private readonly string doubleJumpTriggerName = "doubleJump";
	private readonly string jumpEndTriggerName = "jumpEnd";
	private readonly string takeDamageTriggerName = "TakeDamage";
	private readonly string deathTriggerName = "Death";

	private bool isRight = default;
	private bool isMove = default;



	public void TurnLeft()
	{
		spriteRenderer.flipX = true;
		SetMoveAnimation();
	}


	public void TurnRight()
	{
		spriteRenderer.flipX = false;
		SetMoveAnimation();
	}


	public void SetIdleAnimation()
	{
		_characterAnimator.SetBool(isMoveParameterName, false);
	}


	public void SetMoveAnimation()
	{
		_characterAnimator.SetBool(isMoveParameterName, true);
	}


	public void SetJumpAnimation()
	{
		_characterAnimator.SetTrigger(jumpTriggerName);
	}


	public void SetDoubleJumpAnimation()
	{
		_characterAnimator.SetTrigger(doubleJumpTriggerName);
	}


	public void SetJumpEndAnimation()
	{
		_characterAnimator.SetTrigger(jumpEndTriggerName);

		StartCoroutine(nameof(ResetJumpEndTrigger));
	}


	public void SetTakeDamageAnimation()
	{
		_characterAnimator.SetTrigger(takeDamageTriggerName);
	}


	public void SetDeathAnimation()
	{
		_characterAnimator.SetTrigger(deathTriggerName);
	}


	private IEnumerable ResetJumpEndTrigger()
	{
		yield return null;
		_characterAnimator.ResetTrigger(jumpEndTriggerName);
	}
}
