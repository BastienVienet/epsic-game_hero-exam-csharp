class Voleur : HeroClass
{
    public override string Name { get; } = "Voleur";
    public override string Description { get; } = "PV -50%, force -20%, vitesse +60% et agilité +60%";
    public override float HealthModifierFloat { get => 0.5f; }
    public override float SpeedModifierFloat { get => 1.6f; }
    public override float ForceModifierFloat { get => 0.8f; }
    public override float AgilityModifierFloat { get => 1.6f; }
    public override Weapon BaseWeapon { get; } = new Weapon("Couteau de cuisine", "Arme de base", 1, 2, 1000);
}