using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon // Wir suchen hiermit die Waffenobjekte also egal ob Sword Staff oder Bow
{
    void PerformAttack();
    void PerfomAOEAttack();
}
