using UnityEngine;
using UnityEngine.UI;

public class CuttingProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCount _cuttingCount;
    [SerializeField] private Image _barImage;

    private void Start()
    {
        _cuttingCount.OnProgressChanged += CuttingCounter_OnProgressChanged;
        _barImage.fillAmount = 0f;
    }
    private void CuttingCounter_OnProgressChanged(object sender, CuttingCount.OnProgressChangedEventArgs e)
    {
        _barImage.fillAmount = e.progressNormalized;
    }
}
