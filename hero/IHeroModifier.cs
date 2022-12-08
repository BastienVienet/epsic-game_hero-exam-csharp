interface IHeroModifier
{
    public float HealthModifierFloat { get; }
    public float SpeedModifierFloat { get; }
    public float ForceModifierFloat { get; }
    public float AgilityModifierFloat { get; }
    
    public int HealthModifierInt { get; }
    public int SpeedModifierInt { get; }
    public int ForceModifierInt { get; }
    public int AgilityModifierInt { get; }
}