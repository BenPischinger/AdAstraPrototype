using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("demokratie!")]
public class BaseCurrency  {


    public int BaseValue { get; set; }
    public string CurrencyName { get; set; }
    public string CurrencyDescription { get; set; }



    public BaseCurrency(int baseValue, string currencyName, string currencyDescirption)
    {
        this.BaseValue = baseValue;
        this.CurrencyName = currencyName;
        this.CurrencyDescription = currencyDescirption;
    }

    public void setBaseValue(int _bonusValue, BaseCurrency _baseCurrency)
    {
        _baseCurrency.BaseValue += _bonusValue;
    }
}
