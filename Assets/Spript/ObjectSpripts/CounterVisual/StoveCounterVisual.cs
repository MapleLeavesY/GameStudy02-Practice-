using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject _stoveOnGameObject;
    [SerializeField] private GameObject _particleGameObject;
    [SerializeField] private StoveCount _stoveCount;

    private void Start()
    {
        _stoveCount.OnStateChanged += StoveCount_OnStateChanged;
    }

    private void StoveCount_OnStateChanged(object sender, StoveCount.OnStateChangedEventArgs e)
    {
        bool showVisual = (e.state == StoveCount.State.Frying) || (e.state == StoveCount.State.Fried);
        _stoveOnGameObject.SetActive(showVisual);
        _particleGameObject.SetActive(showVisual);
    }

}
