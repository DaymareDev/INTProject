﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class LegacyWeapon : Weapon {

	public float ReloadTime;

	public LegacyWeapon() : base(){}

	protected LegacyWeapon(LegacyWeapon other) : base(other)
	{
		this.ReloadTime = other.ReloadTime;
	}

	public override Item Clone ()
	{
		return new LegacyWeapon(this);
	}
}