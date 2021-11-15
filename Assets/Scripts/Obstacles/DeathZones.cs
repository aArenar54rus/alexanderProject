using UnityEngine;


public class DeathZones : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
			playerController.GetDamage(10000);
	}
}
