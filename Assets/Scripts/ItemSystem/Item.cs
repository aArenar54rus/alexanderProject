using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="PlayerItem")]
public class Item : ScriptableObject{
	public enum ItemType{
		MoneyItem,
		HealItem,
		QuestItem,
		WeaponItem,
		ArmorItem,
		RingItem
	}

	public enum ArmorType{
		LightArmor,
		MediumArmor,
		HeavyArmor
	}

	public enum WeaponType{
		KniveWeapon,
		SwordWeapon,
		SpearWeapon,
		AxeWeapon
	}

	public string ItemName;
	public string ItemDescription;
	public Sprite ItemSprite;
	public ItemType itemType;
	public ArmorType armorType;
	public WeaponType weaponType;
}
