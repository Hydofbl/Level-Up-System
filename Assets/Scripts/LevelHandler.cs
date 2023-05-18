using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private int currentExperience = 0;
    [SerializeField] private int maxExperience = 300;
    [SerializeField] private int maxExpIncreaseAmount = 150;
    [SerializeField] private int currentLevel = 1;

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

    private void HandlerExperienceChange(int newExperience)
    {
        currentExperience += newExperience;

        if(currentExperience >= maxExperience)
        {
            LevelUp();
        }
    }

    // Depends on what the game about
    private void LevelUp()
    {
        // Additional Changes
        ////

        // Main Changes
        currentExperience = 0;
        currentLevel++;
        maxExperience += maxExpIncreaseAmount;
    }
}
