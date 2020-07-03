using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
[System.Serializable]
public class Item //: ScriptableObject
{
    public string name = "New Item";
    public Sprite icon; // = Resources.Load<Sprite>("DefaultIcon");

    List<StatModifier> mods;
    
    public Item(string path)
    {
        icon = Resources.Load<Sprite>(path);
        mods = new List<StatModifier>();
    }

    public void Equip()
    {
        foreach (StatModifier sm in mods){
            sm.ToString();
        }
    }
}
