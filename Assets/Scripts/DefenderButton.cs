using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41,41,41,255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
