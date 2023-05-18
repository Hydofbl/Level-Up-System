using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int currentExperience = 0;
    [SerializeField] private int maxExperience = 300;
    [SerializeField] private int maxExpIncreaseAmount = 150;

    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text expText;
    [SerializeField] private Slider expBar;

    private void OnEnable()
    {
        // Subscribe Event
        ExperienceManager.Instance.OnExperienceChannge += HandlerExperienceChange;
    }

    private void OnDisable()
    {
        // Unsubscribe Event
        ExperienceManager.Instance.OnExperienceChannge -= HandlerExperienceChange;
    }

    private void Awake()
    {
        levelText.text = "Level " + currentLevel;
        expText.text = currentExperience + "/" + maxExperience;
        expBar.maxValue = maxExperience;
        expBar.value = currentExperience;
    }

    private void HandlerExperienceChange(int newExperience)
    {
        // Update current experience and text
        currentExperience += newExperience;
        expText.text = currentExperience + "/" + maxExperience;
        expBar.value = currentExperience;

        if (currentExperience >= maxExperience)
        {
            LevelUp(newExperience);
        }
    }

    // Depends on what the game about
    private void LevelUp(int newExperience)
    {
        // Main Changes
        currentExperience = currentExperience - maxExperience;
        currentLevel++;
        maxExperience += maxExpIncreaseAmount;

        /*
            -Assume that, currentExperience is 200, maxExperience is 300 and newExperience is 200
            -=> we have to show additional (200+200 = 400 - 300 =) 100 exp 
            -So, first I updated the currentExperience as currentExperience - maxExperience above to find extra exp (400 - 300 = 100)
            -Then increased currentLevel and update the maxExperience needed
            -After that, I check if new currenExperience is greater than new maxExperience
        */

        if(currentExperience < 0)
        {
            currentExperience = 0;
        }
        else if (currentExperience >= maxExperience)
        {
            LevelUp(newExperience);
        }

        // Additional Changes
        levelText.text = "Level " + currentLevel;
        expText.text = currentExperience + "/" + maxExperience;
        expBar.maxValue = maxExperience;
        expBar.value = currentExperience;
    }
}
