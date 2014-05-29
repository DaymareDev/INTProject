﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public ItemDataBase itemDatabase;
	public GameObject GUIRoot;
	public GameObject StoragePrefab;
	public GameObject StorageSlotTemplatePrefab;
	public Storage PlayerInventory;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		if(itemDatabase == null)
		{
			Debug.LogError("Please attach the Item Database!!");
		}
	}
}