public class INTAttribute
{
    public float Base;
    public float Modifier;
    public float Multiplier = 1f;
    public float Total;

    /// <summary>
    /// takes the base, modifier and multiplier to compute the total attribute value. 
    /// </summary>
    public void CalculateTotal()
    {
        Total = (Base + Modifier)*Multiplier;
    }
}