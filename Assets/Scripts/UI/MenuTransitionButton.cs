using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuTransitionButton : MonoBehaviour
{
    [SerializeField]
    private MenuTransitionData _data;

    private MenuTransitionManager _manager;
    private Button _button;

    private void Awake()
    {
        _manager = MenuTransitionManager.GetInstance();
        _button = GetComponent<Button>();

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => Transition(_data));
    }

    private void Transition(MenuTransitionData data)
    {
        _manager.Transition(data);
    }
}
