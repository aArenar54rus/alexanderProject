using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor {
	public void OnInspectorGUI(){
		GUILayout.Label ("Item la la");

		Item currentItem = (Item)target;

		string newItemName = EditorGUILayout.TextField("Item name", currentItem.ItemName);
		currentItem.ItemName = newItemName;

		string newItemDescription = EditorGUILayout.TextField ("Item Description", currentItem.ItemDescription);
		currentItem.ItemDescription = newItemDescription;

		currentItem.ItemSprite = (Sprite)EditorGUILayout.ObjectField(currentItem.ItemSprite, typeof(Sprite), GUILayout.Width(100), GUILayout.Height(100));

		currentItem.itemType = (Item.ItemType)EditorGUILayout.EnumPopup ("Item type", currentItem.itemType);

		if(currentItem.itemType == Item.ItemType.WeaponItem){
			currentItem.weaponType = (Item.WeaponType)EditorGUILayout.EnumPopup ("Weapon type", currentItem.weaponType);
		}

		if(currentItem.itemType == Item.ItemType.ArmorItem){
			currentItem.armorType = (Item.ArmorType)EditorGUILayout.EnumPopup ("Armor type", currentItem.armorType);
		}
	}

}
