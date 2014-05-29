using UnityEngine;
using System.Collections;

public class StorageSlot : ItemSlot {

	public int SlotID;
	public Storage inventory;

	protected override Item observedItem {
		get {
				return (inventory != null) ? inventory.GetItem(SlotID) : null;
			}
	}

	protected override bool Replace (Item item)
	{
		return inventory.Add(SlotID, item);
	}

	protected override bool PLayersInventoryCheck ()
	{
		return inventory.PlayersInventory ? true : false;
	}

	protected override bool AddToPlayersInventory (Item item)
	{
		if(GameManager.Instance.PlayerInventory.Additem(item))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}