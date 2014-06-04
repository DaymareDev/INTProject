using UnityEngine;
using System.Collections;

public class ToggleGUIWindow : MonoBehaviour , ICommand {

	IToggleGUI toggleWindow;

	public ToggleGUIWindow(IToggleGUI guiWindow)
	{
		toggleWindow = guiWindow;
	}

	public void execute()
	{
		toggleWindow.ToggleMyGUI();
	}

}
