using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour {

	[SerializeField]
	private GameObject InventoryPanelVisual;
	public GameObject InventoryItemVisualPrefab;
	public CharacterInventory characterInventory;
	public Transform ItemsHab;

	void Update(){
		InventoryPanelActivate ();
	}

	public void InventoryPanelActivate(){
		if(Input.GetKeyDown(KeyCode.Tab)){
			Debug.Log ("Inventory active");
			InventoryPanelVisual.SetActive(!InventoryPanelVisual.activeInHierarchy);
		}
	}

	public void AddItem(Item item){
		GameObject newItem = Instantiate(InventoryItemVisualPrefab, Vector3.zero, Quaternion.identity, ItemsHab);
		newItem.GetComponent<InventoryItemVisual>().Init(item);
	}
}
