
using ConsoleTables;
class Weapon : IBuyable, IWeapon
{
    public List<string> PromptHeader { get; } = new List<string>(){ "#", "Nom", "Dégats mininimum", "Dégats maximum", "Utilisations restantes" };
    public string Name  { get; private set; } 
    public ICanFight? Owner { get; set; }
    public string? Description  { get; private set; } 
    public float HealthModifierFloat  { get; private set; } 
    public float SpeedModifierFloat { get; private set; } 
    public float ForceModifierFloat { get; private set; } 
    public float AgilityModifierFloat { get; private set; }
    public int HealthModifierInt  { get; private set; } 
    public int SpeedModifierInt  { get; private set; } 
    public int ForceModifierInt  { get; private set; } 
    public int AgilityModifierInt  { get; private set; } 
    public int MinDamage  { get; private set; } 
    public int MaxDamage  { get; private set; } 
    public int ComputedMinDamage 
    {
        get =>  Owner == null ? MinDamage : (int)Math.Round(MinDamage * Owner.Force / 100f);
    }
    public int ComputedMaxDamage 
    {
        get =>  Owner == null ? MaxDamage : (int)Math.Round(MaxDamage * Owner.Force / 100f);
    }
    public int MaxUses  { get; private set; } 
    public int Uses  { get; private set; } 

    private Random _random = new Random();

    public Weapon(
        string name,
        string description,
        float healthModifierFloat,
        float speedModifierFloat,
        float forceModifierFloat,
        float agilityModifierFloat,
        int healthModifierInt,
        int speedModifierInt,
        int forceModifierInt,
        int agilityModifierInt,
        int minDamage,
        int maxDamage,
        int maxUses
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
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        MaxUses = maxUses;
    }

    public Weapon(
        string name,
        string description,
        int minDamage,
        int maxDamage,
        int maxUses
    ) : this(name, description, 1, 1, 1, 1, 0,0,0,0,minDamage, maxDamage, maxUses){ }

    public string Use(FighterSlot target)
    {
        int damage = 0;
        if (Owner != null && Uses < MaxUses)
        {
            damage = _random.Next(ComputedMinDamage, ComputedMaxDamage + 1);
            Uses++;
        }
        
        bool hasHit = target.Hit(damage);
        return BuildUsageMessage(target.Fighter, damage, !hasHit);
    }

    private string BuildUsageMessage(ICanFight target, int damage, bool dodged)
    {
        string message = 
            (Owner == null ? "Quelqu'un" : Owner.NickName) + 
            " frappe " + target.NickName +
            " avec " + Name;
        if (dodged) message += " mais " + target.NickName + " esquive le coup.";
        else message += " et lui inflige " + damage + " dégats.";
        
        return message;
    }

    public void FormatPrompt(int index, ConsoleTable table, string context)
    {
        table.AddRow(
            index,
            Name,
            ComputedMinDamage,
            ComputedMaxDamage,
            (MaxUses - Uses) + "/" + MaxUses);
    }

    public IBuyable Clone()
    {
        return new Weapon(
            Name,
            Description,
            HealthModifierFloat,
            SpeedModifierFloat,
            ForceModifierFloat,
            AgilityModifierFloat,
            HealthModifierInt,
            SpeedModifierInt,
            ForceModifierInt,
            AgilityModifierInt,
            MinDamage,
            MaxDamage,
            MaxUses
        );
    }
}