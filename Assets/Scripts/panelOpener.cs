using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class panelOpener : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;

            panel.SetActive(!isActive);
        }
    }
}
