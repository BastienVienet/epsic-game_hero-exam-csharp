using ConsoleTables;

class Hero : IMarketCustomer, ICanFight
{
    public string Name { get; set; }
    public string NickName { get => Name + " le " + Class.Name; }
    public HeroClass Class { get; private set; }

    public int Money { get; set; }
    public string Stats
    {
        get
        {
            return "PV: " + Health + " | "
                + "Vitesse: " + Speed + " | " 
                + "Force: " + Force + " | "
                + "Agility: " + Agility;
        }
    }
    public string? CustomerInformation { get => Stats; }

    private int _baseHealth;
    private int _baseSpeed;
    private int _baseForce;
    private int _baseAgility;
    public int Health
    { 
        get
        {
            double computed = _baseHealth;
            List<IHeroModifier> modifiers = new List<IHeroModifier>();
            modifiers.AddRange(Weapons);
            modifiers.AddRange(Equipments);
            modifiers.ForEach(modifier => computed += modifier.HealthModifierInt);
            modifiers.ForEach(modifier => computed *= modifier.HealthModifierFloat);

            if ((int)Math.Round(computed * Class.HealthModifierFloat) < 1)
            {
                return 1;
            }
            return (int)Math.Round(computed * Class.HealthModifierFloat);
        }
    }
    public int Speed
    {
        get
        {
            double computed = _baseSpeed;
            List<IHeroModifier> modifiers = new List<IHeroModifier>();
            modifiers.AddRange(Weapons);
            modifiers.AddRange(Equipments);
            modifiers.ForEach(modifier => computed += modifier.SpeedModifierInt);
            modifiers.ForEach(modifier => computed *= modifier.SpeedModifierFloat);

            if ((int)Math.Round(computed * Class.SpeedModifierFloat) < 1)
            {
                return 1;
            }
            return (int)Math.Round(computed * Class.SpeedModifierFloat);
        }
    }
    public int Force
    {
        get
        {
            double computed = _baseForce;
            List<IHeroModifier> modifiers = new List<IHeroModifier>();
            modifiers.AddRange(Weapons);
            modifiers.AddRange(Equipments);
            modifiers.ForEach(modifier => computed += modifier.ForceModifierInt);
            modifiers.ForEach(modifier => computed *= modifier.ForceModifierFloat);

            if ((int)Math.Round(computed * Class.ForceModifierFloat) < 1)
            {
                return 1;
            }
            return (int)Math.Round(computed * Class.ForceModifierFloat);
        }
    }
    public int Agility
    {
        get
        {
            double computed = _baseAgility;
            List<IHeroModifier> modifiers = new List<IHeroModifier>();
            modifiers.AddRange(Weapons);
            modifiers.AddRange(Equipments);
            modifiers.ForEach(modifier => computed += modifier.AgilityModifierInt);
            modifiers.ForEach(modifier => computed *= modifier.AgilityModifierFloat);

            if ((int)Math.Round(computed * Class.AgilityModifierFloat) < 1)
            {
                return 1;
            }

            return (int)Math.Round(computed * Class.AgilityModifierFloat);
        }
    }
    public List<IWeapon> Weapons { get; private set; } = new List<IWeapon>();
    public List<Equipment> Equipments { get; private set; }  = new List<Equipment>();
    public Hero(
        string name,
        int baseHealth,
        int baseSpeed,
        int baseForce,
        int baseAgility,
        HeroClass heroClass,
        int money)
    {
        Name = name;
        _baseHealth = baseHealth;
        _baseSpeed = baseSpeed;
        _baseForce = baseForce;
        _baseAgility = baseAgility;
        Class = heroClass;
        Money = money;
        Weapons.Add(Class.BaseWeapon);
        Class.BaseWeapon.Owner = this;
    }

    public void Show()
    {
        Console.Clear();
        
        ConsoleTable table = new ConsoleTable("Nom du h??ro", Name, "");
        table.AddRow("Classe", Class.Name, Class.Description);
        table.Write(Format.Alternative);
        
        table = new ConsoleTable("Equipment", "Description");
        Equipments.ForEach(equipment => table.AddRow(
            equipment.Name,
            equipment.Description));
        table.Write(Format.Alternative);

        table = new ConsoleTable("Armes", "Description", "Min", "Max", "Coups");
        Weapons.ForEach(weapon => table.AddRow(
            weapon.Name,
            weapon.Description,
            weapon.MinDamage,
            weapon.MaxDamage,
            weapon.MaxUses));
        table.Write(Format.Alternative);

        table = new ConsoleTable("Caract??ristiques", "Valeur", "Description");
        table.AddRow("Points de vie", Health, "Repr??sente les d??gats que peut encaisser le h??ro avant de mourir.");
        table.AddRow("Vitesse", Speed, "Repr??sente le nombre point ajout?? ?? la barre de vitesse ?? la fin de chaque tour. Le h??ro en ayant le plus joue le tour suivant.");
        table.AddRow("Force", Force, "Les d??gats inflig??s par l'arme du h??ros sont multipli??s par la force en pourcent.");
        table.AddRow("Agilit??", Agility, "Repr??sente la probabilit?? d'esquiver le coup de l'adversaire en pourmille.");
        table.Write(Format.Alternative);
    }

    public void OnItemBought(MarketItem item, MarketItemCategory category)
    {
        switch (category.Name)
        {
            case Game.MARKET_CATEGORY_WEAPONS:
                Weapon weapon = (Weapon)item.Article;
                weapon.Owner = this;
                Weapons.Add(weapon);
                break;
            case Game.MARKET_CATEGORY_EQUIPMENTS:
                Equipments.Add((Equipment) item.Article);
                break;
        }
    }
}