using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 10f;

    bool triggerLevelFinished = false;

    private void UpdateSliderState()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
    }

    // Update is called once per frame
    void Update () {
        if (triggerLevelFinished) return;
        UpdateSliderState();

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggerLevelFinished = true;
        }
    }
}
