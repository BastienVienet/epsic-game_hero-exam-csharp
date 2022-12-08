using ConsoleTables;

abstract class HeroClass : IHeroModifier, IPromptable
{
    public List<string> PromptHeader { get; } = new List<string>(){ "#", "Nom", "Description" };
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract IWeapon BaseWeapon { get; }
    public virtual float HealthModifierFloat { get => 1; }
    public virtual float SpeedModifierFloat { get => 1; }
    public virtual float ForceModifierFloat { get => 1; }
    public virtual float AgilityModifierFloat { get => 1; }
    
    public virtual int HealthModifierInt { get => 0; }
    public virtual int SpeedModifierInt { get => 0; }
    public virtual int ForceModifierInt { get => 0; }
    public virtual int AgilityModifierInt { get => 0; }


    public void FormatPrompt(int index, ConsoleTable table, string context)
    {
        table.AddRow(index, Name, Description);
    }

}