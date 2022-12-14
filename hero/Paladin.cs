class Paladin : HeroClass
{
    public override string Name { get; } = "Paladin";
    public override string Description { get; } = "PV +100%, force +20%, vitesse -40% et agilité -50%";
    public override float HealthModifierFloat { get => 2; }
    public override float SpeedModifierFloat { get => 0.6f; }
    public override float ForceModifierFloat { get => 1.2f; }
    public override float AgilityModifierFloat { get => 0.5f; }
    public override Weapon BaseWeapon { get; } = new Weapon("Martelet", "Arme de base", 1, 2, 1000);
}