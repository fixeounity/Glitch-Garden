using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    GameObject defenderParent;
    Defender defenderPrefab;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void AttachToParent(Defender newDefender)
    {
        newDefender.transform.parent = defenderParent.transform;
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        if (!defenderPrefab) return;
        var newDefender = Instantiate(defenderPrefab, roundedPos, defenderPrefab.transform.rotation) as Defender;
        AttachToParent(newDefender);
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        if (!defenderPrefab) return;
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defenderPrefab.GetStarCost();
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

}
