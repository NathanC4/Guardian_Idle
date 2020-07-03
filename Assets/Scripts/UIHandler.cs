using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject invPanel;
    public GameObject equipPanel;

    private void Start()
    {
        invPanel.SetActive(false);
        equipPanel.SetActive(false);
    }

    void Update()
    {
        // toggle inventory window
        if (Input.GetButtonDown("Inventory"))
        {
            invPanel.SetActive(!invPanel.activeSelf);
        }

        if (Input.GetButtonDown("EquipPanel"))
        {
            equipPanel.SetActive(!equipPanel.activeSelf);
        }
    }
}
