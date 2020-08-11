using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public string imagePath;
    public Sprite icon;
    
    public Item(int id, string name, string imagePath)
    {
        this.id = id;
        this.name = name;
        SetIcon(imagePath);
    }

    public virtual void ShowTooltip()
    {
        Tooltip.instance.Show(
            "ID: " + id +
            "\nName: " + name);
    }

    public void SetIcon(string imagePath)
    {
        this.imagePath = imagePath;
        icon = Resources.Load<Sprite>(imagePath);
    }
}
