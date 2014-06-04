using UnityEngine;
using System.Collections;

public interface ICommand
{
	void Execute();
}


/// <summary>
/// invoker class
/// </summary>
/// 
public class PlayerInputController : MonoBehaviour
{
	public ICommand IinputCommand;

	void Start()
	{
		IinputCommand = new OpenInventoryCommand(transform.gameObject);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I))
		{
			IinputCommand.Execute();
		}
	}
}

public class OpenInventoryCommand : ICommand
{
	public GameObject InventoryOwner;

	public OpenInventoryCommand(GameObject inventoryOwner)
	{
		InventoryOwner = inventoryOwner;
	}

	public void Execute()
	{
		InventoryOwner.GetComponent<ItemStorage>().ToggleMyGUI();
	}
}
