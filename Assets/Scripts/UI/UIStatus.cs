using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] Button closeButton;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text moveSpeedText;
    [SerializeField] private TMP_Text attackRangeText;
    [SerializeField] private TMP_Text detectRangeText;

    public void SetStatus(PlayerStat playerStat)
    {
        hpText.text = playerStat.MaxHP.ToString();
        attackText.text = playerStat.BonusAttackDamage > 0
            ? $"{playerStat.BaseAttackDamage} (+{playerStat.BonusAttackDamage})"
            : playerStat.AttackDamage.ToString();
        moveSpeedText.text = playerStat.BonusMoveSpeed > 0
            ? $"{playerStat.BaseMoveSpeed} (+{playerStat.BonusMoveSpeed})"
            : playerStat.MoveSpeed.ToString();
        attackRangeText.text = playerStat.BonusAttackRange > 0
            ? $"{playerStat.BaseAttackRange} (+{playerStat.BonusAttackRange})"
            : playerStat.AttackRange.ToString();
        detectRangeText.text = playerStat.BonusDetectRange > 0
            ? $"{playerStat.BaseDetectRange} (+{playerStat.BonusDetectRange})"
            : playerStat.DetectRange.ToString();

    }
    private void Start()
    {
        closeButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
    }

}
