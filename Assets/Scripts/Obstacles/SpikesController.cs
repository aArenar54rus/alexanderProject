using UnityEngine;


public class SpikesController : MonoBehaviour
{
	[SerializeField] private int damage = 20;


	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
			playerController.GetDamage(damage);
	}
}
