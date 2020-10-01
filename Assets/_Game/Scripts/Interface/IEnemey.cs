using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemey
{
    void TakeDamage(int amount);
    void PerformAttack();
}
