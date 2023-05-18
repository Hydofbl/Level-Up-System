using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager Instance;

    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChannge;

    // Singleton Check
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddExperience(int amount)
    {
        // ? is safeguard for nulls
        OnExperienceChannge?.Invoke(amount);
    }

    public void Add100Exp()
    {
        AddExperience(100);
    }

    public void Add250Exp()
    {
        AddExperience(250);
    }

    public void Add1000Exp()
    {
        AddExperience(1000);
    }
}
