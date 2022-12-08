class Equipment : IHeroModifier, IBuyable
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public float HealthModifierFloat { get; private set; }
    public float SpeedModifierFloat { get; private set; }
    public float ForceModifierFloat { get; private set; }
    public float AgilityModifierFloat { get; private set; }
    public int HealthModifierInt { get; private set; }
    public int SpeedModifierInt { get; private set; }
    public int ForceModifierInt { get; private set; }
    public int AgilityModifierInt { get; private set; }

    public Equipment(
        string name,
        string description,
        float healthModifierFloat,
        float speedModifierFloat,
        float forceModifierFloat,
        float agilityModifierFloat,
        int healthModifierInt,
        int speedModifierInt,
        int forceModifierInt,
        int agilityModifierInt
    )
    {
        Name = name;
        Description = description;
        HealthModifierFloat = healthModifierFloat;
        SpeedModifierFloat = speedModifierFloat;
        ForceModifierFloat = forceModifierFloat;
        AgilityModifierFloat = agilityModifierFloat;
        HealthModifierInt = healthModifierInt;
        SpeedModifierInt = speedModifierInt;
        ForceModifierInt = forceModifierInt;
        AgilityModifierInt = agilityModifierInt;
    }

    public IBuyable Clone()
    {
        return new Equipment(
            Name,
            Description,
            HealthModifierFloat,
            SpeedModifierFloat,
            ForceModifierFloat,
            AgilityModifierFloat,
            HealthModifierInt,
            SpeedModifierInt,
            ForceModifierInt,
            AgilityModifierInt
        );
    }
}