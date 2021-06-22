using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject TextPanel;

    public void OpenPanel()
    {
        if (TextPanel != null)
        {
            bool isActive = TextPanel.activeSelf;
            TextPanel.SetActive(!isActive);
        }
    }
}
