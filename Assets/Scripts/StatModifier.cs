public enum ModifierType { Add, Percent, Multiply}
public enum Stat { Health, MaxHealth, Attack, AttackSpeed, Accuracy, Armor, Evasion, CritChance, CritMulti}
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
}