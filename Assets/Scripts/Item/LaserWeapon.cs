using UnityEngine;
using System.Collections;

[System.Serializable]
public class LaserWeapon : Weapon {
	
	public float CoolDownTime; 

	public LaserWeapon() : base()
	{
	}

	protected LaserWeapon(LaserWeapon other) : base(other)
	{
		this.CoolDownTime = other.CoolDownTime;
	}

	public override Item Clone ()
	{
		return new LaserWeapon(this);
	}

	public override string GetItemDescription ()
	{
		return ("Armor");
	}
}
