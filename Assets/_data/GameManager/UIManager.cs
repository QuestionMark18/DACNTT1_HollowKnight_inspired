using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private Image expBar;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI countdownText;

    private float countdownTime = 10f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        this.UpdateExpBar();
        currentTime = countdownTime;
        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateExpBar();
    }

    private void UpdateExpBar()
    {
        expBar.fillAmount = playerInfo.CurrentExp / playerInfo.MaxExp;
        level.text = "Lv." + playerInfo.Level;
    }

    IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            UpdateTimerDisplay();
            yield return new WaitForSeconds(1f);
            currentTime -= 1f;
        }
        UpdateTimerDisplay();
        Debug.Log("Time out");
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
