using System;
using UnityEngine;


public abstract class CharacterController : MonoBehaviour {
	[SerializeField] private int _baseHealthPoints = default;

	[Space(10)]
	[SerializeField] private float _baseEndurancePoints = default;
	[SerializeField] private int _enduranceConsumptionMoveForce = default;
	[SerializeField] private int _enduranceConsumptionAttackForce = default;
	[SerializeField] protected int enduranceRegenerationForce = default;

	[Range(0.01f, 1.0f)]
	[SerializeField] private float _moveLimiter = default;

	[Space(10)]
	[SerializeField] private float _moveSpeed = default;
	[SerializeField] private float _runMultiplier = default;

	[Space(10)]
	[SerializeField] private bool _isJumper = default;
	[SerializeField] private float _jumpForce = default;


	private CharacterParameters _characterParameters = default;
	private Rigidbody2D _rigidbody = default;
	private CharacterAnimator _characterAnimator = default;

	protected bool isDeath = default;
	protected bool isControlBlocked = default;
	protected bool isRun = default;
	protected bool isGrounded = default;




	protected CharacterParameters CharacterParameters => _characterParameters;
	protected CharacterAnimator CharacterAnimator => _characterAnimator;
	protected Rigidbody2D CharacterRigidbody2D => _rigidbody;

	protected float RealMoveLimiter => _moveLimiter * CharacterParameters.MaxEndurancePoints;


	private void Awake()
	{
		_characterParameters = new CharacterParameters(_baseHealthPoints, _baseEndurancePoints);
		_rigidbody = GetComponent<Rigidbody2D> ();
		_characterAnimator = GetComponent<CharacterAnimator> ();
	}


	protected virtual void Start()
	{
		isDeath = false;
	}


	private void FixedUpdate()
	{
		CheckGround();
	}


	protected virtual void Update()
	{
		if (isDeath)
			return;
	}


	public virtual void GetDamage(int damage)
	{
		CharacterParameters.HealthPoints -= damage;
		CharacterAnimator.SetTakeDamageAnimation();

		if (CharacterParameters.HealthPoints <= 0)
		{
			MakeCharacterDead();
		}
	}


	public virtual void GetHealth(int addedHealth)
	{
		CharacterParameters.HealthPoints += addedHealth;
	}


	protected void MakeCharacterDead()
	{
		isDeath = true;
		CharacterAnimator.SetDeathAnimation();
	}


	protected void CharacterWalk(Vector3 moveDirection)
	{
		isRun = false;

		transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection,  _moveSpeed * Time.deltaTime);
	}


	protected void CharacterRun(Vector3 moveDirection)
	{
		if (CharacterParameters.EndurancePoints < RealMoveLimiter && !isRun)
			return;

		isRun = true;

		transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection, _runMultiplier * _moveSpeed * Time.deltaTime);
		_characterParameters.EnduranceConsumption();
	}


	protected void CharacterJump()
	{
		if (CharacterParameters.EndurancePoints < RealMoveLimiter || !_isJumper)
			return;

		if (isGrounded)
		{
			CharacterAnimator.SetJumpAnimation();
			_rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
		}
	}


	private void CheckGround()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, 0.3F);

		bool lastGrounded = isGrounded;
		isGrounded = colliders.Length > 1;

		if (!lastGrounded && isGrounded)
			CharacterAnimator.SetJumpEndAnimation();
	}
}
