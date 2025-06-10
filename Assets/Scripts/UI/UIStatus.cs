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
        attackText.text = playerStat.AttackDamage.ToString();
        moveSpeedText.text = playerStat.MoveSpeed.ToString();
        attackRangeText.text = playerStat.AttackRange.ToString();
        detectRangeText.text = playerStat.DetectRange.ToString();

    }
    private void Start()
    {
        closeButton.onClick.AddListener(() => UIManager.Instance.OpenMainMenu());
    }

}
