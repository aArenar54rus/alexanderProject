using UnityEngine;



public class CharacterParameters
{
	private int _maxHealthPoints = default;

	private int _healthPoints = default;

	private float _maxEndurancePoints = default;

	private float _endurancePoints = default;


	public CharacterParameters(int maxHealthPoints, float maxEndurancePoints)
	{
		_maxHealthPoints = _healthPoints = maxHealthPoints;
		_maxEndurancePoints = _endurancePoints = maxEndurancePoints;
	}



	public int MaxHealthPoints
	{
		get => _maxHealthPoints;
		set
		{
			_maxHealthPoints = value;
			if (_maxHealthPoints < 0)
				_maxHealthPoints = 0;
		}
	}


	public int HealthPoints
	{
		get => _healthPoints;
		set
		{
			_healthPoints = value;
			Mathf.Clamp(_healthPoints, 0, _maxHealthPoints);
		}
	}


	public float MaxEndurancePoints
	{
		get => _maxEndurancePoints;
		set
		{
			_maxEndurancePoints = value;
			if (_maxEndurancePoints < 0)
				_maxEndurancePoints = 0;
		}
	}


	public float EndurancePoints
	{
		get => _endurancePoints;
		set
		{
			_endurancePoints = value;
			Mathf.Clamp(_endurancePoints, 0, _maxEndurancePoints);
		}
	}


	public void EnduranceRegeneration(float endurance) {
		if (_endurancePoints < _maxEndurancePoints)
			_endurancePoints += endurance * Time.deltaTime;
		if (_endurancePoints > _maxEndurancePoints)
			_endurancePoints = _maxEndurancePoints;
	}


	public void EnduranceConsumption(){
		_endurancePoints -= 50 * Time.deltaTime;
		if (_endurancePoints < 0) {
			_endurancePoints = 0;
		}
		Debug.Log ("Endurance = " + _endurancePoints);
	}
}
