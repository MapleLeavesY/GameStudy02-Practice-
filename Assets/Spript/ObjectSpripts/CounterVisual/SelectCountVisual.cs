using UnityEngine;

public class SelectCountVisual : MonoBehaviour
{
    [SerializeField] private BaseCount _baseCount;
    [SerializeField] private GameObject[] _visualGameObjectArray;
    private void Start()
    {
        Player.Instance.OnSelectedCountChangeed += Player_OnSelectedCounterChanged;
    }
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCountChangeedEventArgs e)
    {
        if(e.selectedCounter == _baseCount) Show();
        else Hide();
    }
    private void Show()
    {
        foreach(GameObject gameObject in _visualGameObjectArray)
        {
            gameObject.SetActive(true);
        }
    }
    private void Hide()
    {
        foreach(GameObject gameObject in _visualGameObjectArray)
        {
            gameObject.SetActive(false);
        }
    }


}