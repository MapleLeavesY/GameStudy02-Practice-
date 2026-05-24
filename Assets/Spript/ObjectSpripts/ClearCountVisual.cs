using UnityEngine;

public class ClearCountVisual : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.OnSelectedCountChangeed += Player_OnSelectedCounterChanged;
    }
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCountChangeedEventArgs e)
    {
        
    }
}