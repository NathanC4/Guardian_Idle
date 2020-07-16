using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public GameObject panel;
    public Text text;
    public static Tooltip instance;

    public void Awake()
    {
        instance = this;
    }

    public void Show(string str)
    {
        if (!panel.activeSelf)
            panel.SetActive(true);

        text.text = str;
    }

    public void Hide()
    {
        if (panel.activeSelf)
            panel.SetActive(false);
    }
}
