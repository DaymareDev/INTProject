using UnityEngine;
using System.Collections;

public enum ArmorQuality
{
	LightArmor,
	MediumArmor,
	HeavyArmor
}

[System.Serializable]
public class Armor : Item {
	
	public ArmorQuality Category;

	public float ArmorValue;
	public float DefenseValue;

	public Armor() : base(){}

	protected Armor(Armor other) :base(other)
	{
		this.Category = other.Category;
		this.ArmorValue = other.ArmorValue;
		this.DefenseValue = other.DefenseValue;
	}

	public override Item Clone ()
	{
		return new Armor(this);
	}

	public override string GetItemDescription ()
	{
		return ("Armor");
	}

}
