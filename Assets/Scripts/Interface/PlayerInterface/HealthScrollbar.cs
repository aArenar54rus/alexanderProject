using UnityEngine;
using UnityEngine.UI;


namespace Interface.Player
{
	public class HealthScrollbar : MonoBehaviour
	{

		[SerializeField] private Slider healthSlider = default;



		public void InitializeHeathbar(int heathMax, int health)
		{
			healthSlider.maxValue = heathMax;
			healthSlider.value = health;
		}


		public void UpdateHealth(int health) =>
			healthSlider.value = health;
	}
}
