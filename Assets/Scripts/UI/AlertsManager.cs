using TMPro;
using UnityEngine;

public class AlertsManager : StaticMonoBehaviour<AlertsManager>
{
    [SerializeField]
    private TMP_Text _gameOverText;

    public void SetGameOverAlertActive(bool active)
    {
        _gameOverText.gameObject.SetActive(active);
    }
}
