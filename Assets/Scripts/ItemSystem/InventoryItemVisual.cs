using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemVisual : MonoBehaviour {

	public void Init(Item item){
		GetComponent<Image> ().sprite = item.ItemSprite;
	}
}
