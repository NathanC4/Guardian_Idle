using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public Sprite icon; // = Resources.Load<Sprite>("DefaultIcon");

    //List<StatModifier> mods;
    
    public Item(int id, string name, string imagePath)
    {
        this.id = id;
        this.name = name;
        icon = Resources.Load<Sprite>(imagePath);
    }

    public virtual void ShowTooltip()
    {
        Tooltip.instance.Show(
            "ID: " + id +
            "\nName: " + name);
    }
}
