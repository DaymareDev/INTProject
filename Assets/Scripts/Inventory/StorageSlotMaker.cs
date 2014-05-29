using UnityEngine;
using System.Collections;

public class StorageSlotMaker : MonoBehaviour {

	public UIGrid StorageGrid;
	public UILabel TitleLabel;

	public void BuildSlots(int SlotAmount, ItemStorage storage, string windowTitle)
	{
		for(int a = 0; a < SlotAmount; a++)
		{
			TitleLabel.text = windowTitle;

			GameObject slot = NGUITools.AddChild(StorageGrid.gameObject, GameManager.Instance.StorageSlotTemplatePrefab);
			slot.transform.name = a.ToString("000");
			StorageSlot s = slot.GetComponent<StorageSlot>();
			s.SlotID = a;
			s.inventory = storage;

		}
	}

}
