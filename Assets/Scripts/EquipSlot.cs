using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot : ItemSlot
{
    public WearSlot wearSlot;

    public WearSlot GetWearSlot()
    {
        return wearSlot;
    }
}
