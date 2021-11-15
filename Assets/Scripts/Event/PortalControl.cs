using UnityEngine;
using UnityEngine.Events;


public class PortalControl : MonoBehaviour
{
	[SerializeField] private UnityEvent portalEntryAction = default;


	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
		{
			portalEntryAction?.Invoke();
		}
	}
}
