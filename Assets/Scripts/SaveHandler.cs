using System.Collections.Generic;
using CI.QuickSave;
using UnityEngine;


public class SaveHandler : MonoBehaviour
{
    //string test;
    List<ItemSlot> slots;
    Item item;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    public void Save()
    {
        Inventory.instance.Save();
        ItemAdder.instance.Save();
        EquipHandler.instance.Save();
    }

    public void Load()
    {
        Inventory.instance.Load();
        ItemAdder.instance.Load();
        EquipHandler.instance.Load();
    }
}

