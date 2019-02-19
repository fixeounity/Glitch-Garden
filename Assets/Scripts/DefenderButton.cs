using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour {

    [SerializeField] Defender defenderPrefab;

    private void ChangeButtonStyle()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void AssignDefender()
    {
        var defenderSpawner = FindObjectOfType<DefenderSpawner>();
        if (!defenderSpawner) return;
        defenderSpawner.SetSelectedDefender(defenderPrefab);
    }

    private void OnMouseDown()
    {
        ChangeButtonStyle();
        AssignDefender();
    }

}
