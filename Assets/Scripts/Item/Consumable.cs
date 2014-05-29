using UnityEngine;
using System.Collections;

[System.Serializable]
public class Consumable : Item {

	public Consumable() : base() {}

	protected Consumable(Consumable other) : base(other){}
	
	public override Item Clone ()
	{
		return new Consumable(this);
	}

	public override void Use(){}
}
