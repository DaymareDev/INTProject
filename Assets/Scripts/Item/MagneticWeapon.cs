using UnityEngine;
using System.Collections;

[System.Serializable]
public class MagneticWeapon : Weapon {
	

	public float BatteryRecharge;

	public MagneticWeapon() : base(){}

	protected MagneticWeapon(MagneticWeapon other) : base(other)
	{
		this.BatteryRecharge = other.BatteryRecharge;
	}

	public override Item Clone ()
	{
		return new MagneticWeapon(this);
	}
}
