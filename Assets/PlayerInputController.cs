using UnityEngine;
using System.Collections;

public interface ICommand
{
	void execute();
}


/// <summary>
/// invoker class
/// </summary>
/// 
public class PlayerInputController : MonoBehaviour, ICommand 
{

	public void execute()
	{

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I))
		{
		}
	}
}
