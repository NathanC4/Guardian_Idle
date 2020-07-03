using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Affix
{
    public string name;
    public string description;
    public List<StatModifier> mods;

    public Affix(string name, string description, List<StatModifier> mods)
    {
        this.name = name;
        this.description = description;
        this.mods = mods;
    }
}
