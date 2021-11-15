using UnityEngine;

public class SecretChestController : MonoBehaviour
{
	[SerializeField] private ProgressController progressController = default;

	[Space(10)]
	[SerializeField] private SpriteRenderer chestVisual = default;

	[SerializeField] private Sprite openChestSprite = default;


	private bool isOpened = false;



	private void OnTriggerEnter2D(Collider2D col)
	{
		Debug.LogError("Chest");
		if (isOpened)
			return;

		if (col.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
		{
			progressController.AddFindSecretChest();
			chestVisual.sprite = openChestSprite;
			isOpened = true;
		}
	}
}
