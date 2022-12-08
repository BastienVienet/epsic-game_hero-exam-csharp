class Warrior : HeroClass
{
    public override string Name { get => "Guerrier"; }
    public override string Description { get; } = "PV -5%, force +30%, vitesse -5% et agilité -5%";
    public override float HealthModifierFloat { get => 0.95f; }
    public override float SpeedModifierFloat { get => 0.95f; }
    public override float ForceModifierFloat { get => 1.3f; }
    public override float AgilityModifierFloat { get => 0.95f; }
    public override Weapon BaseWeapon { get; } = new Weapon("Coup de poing", "Arme de base", 1, 2, 1000);

}