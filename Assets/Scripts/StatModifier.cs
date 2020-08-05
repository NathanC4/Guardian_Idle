public enum ModifierType { Add, Percent, Multiply}
public enum Stat { MaxHealth, Attack, AttackSpeed, Accuracy, Armor, Evasion, CritChance, CritMulti}
public class StatModifier
{
    public ModifierType type;
    public Stat stat;
    public double value;

    public StatModifier(ModifierType type, Stat stat, double value)
    {
        this.type = type;
        this.stat = stat;
        this.value = value;
    }

    public override string ToString()
    {
        if (type == ModifierType.Add)
        {
            return string.Format("+{0:.##} {1}", value, stat);
        } 
        else if (type == ModifierType.Percent)
        {
            
        }
        return "er";
    }

    public void Add()
    {

    }
}