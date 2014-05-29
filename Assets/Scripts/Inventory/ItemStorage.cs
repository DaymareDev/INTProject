using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ItemStorage : MonoBehaviour {
	
	private bool _showGUI = false;

	public int MaxSlots;
	public string StorageName = "Inventory";
	public bool PlayersInventory;

	public Item[] Items;

	private GameObject _GUIRef;
	

	void Start()
	{
		///tell the gamemanager i am a player inventory
		if(PlayersInventory)
		{
			if(GameManager.Instance.PlayerInventory != null)
			{
				Debug.LogError("ERROR:You can only have 1 player inventory");
				return;
			}

			GameManager.Instance.PlayerInventory = this;
		}

		Items = new Item[MaxSlots];

		Items[1] = GameManager.Instance.itemDatabase.Get(ItemType.LegacyWeapon, 0);
		Items[2] = GameManager.Instance.itemDatabase.Get(ItemType.LaserWeapon, 0);

		Items[3] = GameManager.Instance.itemDatabase.Get(ItemType.Misc, 0);
		Items[4] = GameManager.Instance.itemDatabase.Get(ItemType.Misc, 0);
		Items[5] = GameManager.Instance.itemDatabase.Get(ItemType.Misc, 0);

		ToggleMyGUI();
	}

	void ToggleMyGUI ()
	{
		if(_showGUI)
		{
			NGUITools.Destroy(_GUIRef);
		}
		else
		{
			MakeGUI();
		}

		_showGUI =! _showGUI;
	}

	void MakeGUI ()
	{
		_GUIRef = NGUITools.AddChild(GameManager.Instance.GUIRoot, GameManager.Instance.StoragePrefab);
		StorageSlotMaker s = _GUIRef.GetComponent<StorageSlotMaker>();
		s.BuildSlots(MaxSlots, this, StorageName);
	}

//	public bool Add(int slot, Item item)
//	{
//	
//		///might need - 1 here slots gofrom 0
//		if(slot < Items.Length)
//		{
//			// add the current item to that slot
//			Items[slot] = item;
//
//			return true;
//		}
//
//		return false;
//	}


	public bool Additem(Item item)
	{
		for (int i = 0; i < Items.Length; i++) 
		{
			if(Items[i] == null)
			{
				Add(i, item);
				return true;
			}
		}
		
		return false;
	}
	
	
	public bool Add(int pos, Item item)
	{

		if(item == null)
		{
			Items[pos] = item;

			return true;
		}

		if(Items[pos] == null)
		{
			Items[pos] = item;
			
			return true;
		}
		//check to see if the item is stackable
		if(item.Stackable)
		{ 
			if(Items[pos].ItemName == item.ItemName && Items[pos].StackAmount < Items[pos].MaxStack)
			{
				if((Items[pos].StackAmount + item.StackAmount) > Items[pos].MaxStack)
				{
					int tempStackAmount = Items[pos].MaxStack - Items[pos].StackAmount;

					Items[pos].StackAmount += tempStackAmount;
					item.StackAmount -= tempStackAmount;

					return false;
				}

				Items[pos].StackAmount += item.StackAmount;
				
				return true;
			}
		}
		
		for (int i = 0; i < Items.Length; i++) 
		{
			if(Items[i] == item)
				return false;
		}

		///check if there is room
		int slotId = CheckForSpace(item);
		
		if(slotId == -1)
		{
			return false;
		}
		else
		{
			Add(slotId, item);
			
			
			return true;
		}
		
	}

	int CheckForSpace (Item item)
	{
		for (int a = 0; a < this.Items.Length; a++) 
		{
			if (Items[a] == null) 
			{
				
				return a;
			}
		}
		
		return -1;
	}


	public Item GetItem (int slot) { return (slot < Items.Length) ? Items[slot] : null; }
	
}
