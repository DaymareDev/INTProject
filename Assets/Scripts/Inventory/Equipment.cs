using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour {

	public Item[] items;

	// Use this for initialization
	void Start () {
		items = new Item[4];
	}
	
	public Item GetItem (SlotType slot)
	{
		if (slot != SlotType.None)
		{
			int index = (int)slot - 1;
			
			if (items != null && index < items.Length)
			{
				return items[index];
			}
		}
		return null;
	}

	public bool Equip(Item item, SlotType slot)
	{
		int index = (int)slot - 1;

		if(item == null)
		{
			items[index] = item;
			return true;
		}


		if(item.Slot == slot)
		{
			if(items[index] != null)
				return false;

			items[index] = item;

			return true;
		}

		return false;
	}

}
