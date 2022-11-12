using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beans2022;
using EnumCollection;
using TMPro;

public class SleepManager : MonoBehaviour
{
    #region Fields

    private int _sleepTimer;
    private bool timerOn;
    [SerializeField] private TextMeshProUGUI timerText;

    #endregion



    #region Private Functions

    // Start is called before the first frame update
    void Start()
    {
        _sleepTimer = GameManager.Instance.SleepTimer;
    }

    // Update is called once per frame
    void Update()
    {
        _sleepTimer = GameManager.Instance.SleepTimer;

        if (!timerOn)
        {
            StartCoroutine(nameof(SleepCountdown));
        }

        if (_sleepTimer <= 0)
        {
            GameManager.Instance.SwitchState(GameState.GameOver);
        }

        timerText.text = _sleepTimer.ToString();
    }
    #endregion


    #region IEnumerators

    private IEnumerator SleepCountdown()
    {
        timerOn = true;
        yield return new WaitForSeconds(1);
        GameManager.Instance.SleepTimer -= 1;
        timerOn = false;
    }



    #endregion

}
