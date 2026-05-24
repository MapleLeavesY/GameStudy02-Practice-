using UnityEngine;

public class ClearCountVisual : MonoBehaviour
{
    [SerializeField] private ClearCount _clearCount;
    [SerializeField] private GameObject _visualGameObject;
    private void Start()
    {
        Player.Instance.OnSelectedCountChangeed += Player_OnSelectedCounterChanged;
    }
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCountChangeedEventArgs e)
    {
        if(e.selectedCounter == _clearCount) Show();
        else Hide();
    }
    private void Show()
    {
        _visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        _visualGameObject.SetActive(false);
    }


}