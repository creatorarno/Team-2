﻿using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    #region Defenitions

    public CharacterStats_SO stats_Template;
    public CharacterStats_SO stats;

    #endregion

    private void Start()
    {
        if(stats_Template != null)
        {
            stats = Instantiate(stats_Template);
        }
    }
    #region Increasers
    public void GiveHealth(int amount)
    {
        stats.GiveHealth(amount);
    }
    public void GiveShield(int amount)
    {
        stats.GiveShield(amount);
    }
    public void GiveCredit(int amount)
    {
        stats.GiveCredit(amount);
    }
    #endregion

    #region Decreasers
    public void TakeDamage(int amount)
    {
        if(stats.currentShield > 0)
        {
            LoseShield(amount);
        }
        else
        {
            stats.TakeDamage(amount);
        }
    }
    public void LoseShield(int amount)
    {
        int leftOverAmount;

        if (stats.currentShield - amount < 0)
        {
            leftOverAmount = amount - stats.currentShield;
            stats.LoseShield(stats.currentShield);
            stats.TakeDamage(leftOverAmount);
        }
        else
        {
            stats.TakeDamage(amount);
        }
    }
    public void TakeCredit(int amount)
    {
        stats.TakeCredit(amount);
        //update inventory event
    }
    #endregion

    #region Getters

    public int GetDamage()
    {
        return stats.currentDamage;
    }
    public int GetArmor()
    {
        return stats.currentArmor;
    }
    
    public float GetCriticalChance()
    {
        return stats.criticalChance;
    }
    #endregion
}