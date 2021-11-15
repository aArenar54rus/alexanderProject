using UnityEngine;

public class HealthBufferControl : MonoBehaviour
{
	[SerializeField] private int addedHealth = default;


	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
		{
			playerController.GetHealth(addedHealth);
			Destroy(this.gameObject);
		}
	}
}
