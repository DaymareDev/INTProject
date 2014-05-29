using UnityEngine;
using System.Collections;

[System.Serializable]
public class Melee : Weapon {

	public float Exhaustion;

	public Melee() : base(){}

	protected Melee (Melee other) : base(other)
	{
		this.Exhaustion = other.Exhaustion;
	}

	public override Item Clone ()
	{
		return new Melee(this);
	}

	public override string GetItemDescription ()
	{
		return ("Armor");
	}
}
