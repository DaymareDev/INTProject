using UnityEngine;
using System.Collections;

public abstract class ItemSlot : MonoBehaviour {

	public Item item;
	public UISprite Icon;
	public UILabel StackLabel;

	public static Item DraggedItem;
	public static ItemSlot DraggedFromSlot;

	abstract protected Item observedItem{get;}
	abstract protected bool Replace (Item ritem);

	abstract protected bool PLayersInventoryCheck();
	abstract protected bool AddToPlayersInventory(Item item);

	void OnHover(bool isOver)
	{

	}

	void OnDragEnd ()
	{
		OnDragDropRelease(UICamera.hoveredObject);
	}

	void OnDragDropRelease (GameObject surface)
	{
		if(DraggedItem == null)
			return;

		if(surface == null)
		{
			///destroy item dropped
			/// 
			DraggedFromSlot.Replace (null);
			ClearDraggedItem();
			UpdateCursor();
		}
		else
		if(surface.name == "BackCollider")
		{
			DraggedFromSlot.Replace(DraggedItem);
			ClearDraggedItem();
			UpdateCursor();
		}
		else
		{
			///run the check for itemslot
			ItemSlot s = surface.GetComponent<ItemSlot>();

			if(s == null)
			{
				DraggedFromSlot.Replace(DraggedItem);
				ClearDraggedItem();
				UpdateCursor();
			}
			else
			{
				///same slot
				if(DraggedFromSlot == s)
				{
					OnDrop();
				}
			}
		}
	}

//
//	void OnClick()
//	{
//		if (DraggedItem != null)
//		{
//			OnDragDropRelease(UICamera.hoveredObject);
//			OnDrop(null);
//		}
//		else if (item != null)
//		{
//			DraggedItem = Replace(null);
//			UpdateCursor();
//		}
//
//		UpdateCursor();
//	}

	void OnDoubleClick()
	{
		if(!PLayersInventoryCheck())
		{
			if(AddToPlayersInventory(item) == true)
			{
				Replace(null);
			}
		}
	}

	void OnDrag(Vector2 delta)
	{
		if (item != null)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			DraggedItem = item;
			Replace(null);
			DraggedFromSlot = this;
			UpdateCursor();
		}
	}

	void OnDrop()
	{
		if(!Replace(DraggedItem))
		{
			DraggedFromSlot.Replace(DraggedItem);
		}

		ClearDraggedItem();
		UpdateCursor();
	}

	void OnTooptip(bool show)
	{

	}

	void ClearDraggedItem()
	{
		DraggedItem = null;
		DraggedFromSlot = null;
	}

	void UpdateCursor ()
	{
			if (DraggedItem != null)
			{
				UIAtlas atlas = Resources.Load <UIAtlas>(DraggedItem.Atlas);

				if(DraggedItem.Stackable)
				{
					string stackAmount = DraggedItem.StackAmount.ToString();
					UICursorWithLabel.Set (atlas, DraggedItem.ItemSprite, stackAmount);
				}
				else
				{
					UICursorWithLabel.Set(atlas, DraggedItem.ItemSprite);
				}
			}
			else
			{
				UICursorWithLabel.Clear();
			}
	}

	void Update()
	{
		item = observedItem;

		if(item != null)
		{
			Icon.enabled = true;
			Icon.spriteName = item.ItemSprite;
			CheckStackLabel();
		}
		else
		{
			Icon.enabled = false;
			CheckStackLabel();
		}
	
	}

	void CheckStackLabel()
	{
		if(item == null)
		{
			StackLabel.enabled = false;
		}
		else
		{
			if(item.Stackable)
			{
				StackLabel.enabled = true;
				StackLabel.text = item.StackAmount.ToString();
			}
			else
			{
				StackLabel.enabled = false;
			}
		}
	}
}
