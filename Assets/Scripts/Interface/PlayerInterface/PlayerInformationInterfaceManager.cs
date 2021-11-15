using UnityEngine;


namespace Interface.Player
{
	public class PlayerInformationInterfaceManager : MonoBehaviour
	{
		[SerializeField] private HealthScrollbar _healthScrollbar = default;

		[SerializeField] private EnduranceScrollbar _enduranceScrollbar = default;



		public void InitializeHealthbar(int healthMax, int health) =>
			_healthScrollbar.InitializeHeathbar(healthMax, health);


		public void InitializeEndurancebar(float enduranceMax, float endurance, float moveLimiter) =>
			_enduranceScrollbar.InitializeEnduranceScrollbar(enduranceMax, endurance, moveLimiter);


		public void UpdateHealthVisual(int health)
		{
			_healthScrollbar.UpdateHealth(health);
		}


		public void UpdateEnduranceVisual(float endurance)
		{
			_enduranceScrollbar.UpdateEnduranceValue(endurance);
		}
	}
}
