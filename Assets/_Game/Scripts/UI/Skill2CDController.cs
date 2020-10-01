using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill2CDController : MonoBehaviour {
    public Image imageCooldown;
    bool isOnCooldown;
    private SkillBase skill;

    public void Start() {
        skill = GameManager.Instance.Player.GetComponent<PlayerController>().Skill2;
    }

    private void Update() {
        if (skill == null) {
            return;
        }

        float currentCooldown = skill.CurrentCooldown;
        if (currentCooldown > 0) {
            isOnCooldown = true;
        }

        if (isOnCooldown) {
            //Fill amount zwischen 0 und 1
            //1 = on CD 0= rdy
            float maxCooldown = skill.Cooldown;
            imageCooldown.fillAmount = 1 * (currentCooldown / maxCooldown);

            if (imageCooldown.fillAmount <= 0) {
                imageCooldown.fillAmount = 0;
                isOnCooldown = false;
            }
        }
    }
}