using UnityEngine;
using UnityEngine.UI;


namespace Interface.Player
{
	public class EnduranceScrollbar : MonoBehaviour
	{
		[SerializeField] private Slider _enduranceSlider = default;
		[SerializeField] private Image _enduranceLine = default;

		[Space(10)]
		[SerializeField] private Color _enduranceColor = default;
		[SerializeField] private Color _enduranceBLockedColor = default;


		private bool _isblocked = default;
		private float _enduranceLimiter = default;



		public void InitializeEnduranceScrollbar(float enduranceMax, float endurance, float moveLimiter)
		{
			_enduranceSlider.maxValue = enduranceMax;
			UpdateEnduranceLineColor(endurance);

			_enduranceLimiter = moveLimiter;
			_isblocked = false;
			SetLineColor(_enduranceColor);
		}


		public void UpdateEnduranceValue(float endurance)
		{
			_enduranceSlider.value = endurance;
			UpdateEnduranceLineColor(endurance);
		}


		private void UpdateEnduranceLineColor(float endurance)
		{
			if (endurance >= _enduranceLimiter)
			{
				if (!_isblocked)
					return;

				_isblocked = false;
				SetLineColor(_enduranceColor);
			}
			else
			{
				if (_isblocked)
					return;

				_isblocked = true;
				SetLineColor(_enduranceBLockedColor);
			}
		}


		private void SetLineColor(Color color)
		{
			_enduranceLine.color = color;
		}
	}
}
