using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    [SerializeField] GameObject defenderPrefab;


    private void OnMouseDown()
    {
        CreateDefender();
    }
    
    private void CreateDefender()
    {
        if (!defenderPrefab) return;
        var spawn3DPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var spawn2DPosition = new Vector2(spawn3DPosition.x, spawn3DPosition.y);
        var defender = Instantiate(defenderPrefab, spawn2DPosition, Quaternion.identity);
    }
}
