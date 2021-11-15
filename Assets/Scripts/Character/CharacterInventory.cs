using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour {

	[SerializeField]
	private Item[] initialCharacterItems;
	public InventoryPanel inventoryPanel;

	private List<Item> inventoryItems = new List<Item>();

	// Use this for initialization
	void Start () {
		foreach (Item item in initialCharacterItems) {
			AddItemInInventory(item);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void AddItemInInventory(Item item){
		inventoryItems.Add (item);
		//InventoryPanel.AddItem(item);
	}

}
