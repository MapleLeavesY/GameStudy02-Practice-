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
        Hide();
    }
    private void CuttingCounter_OnProgressChanged(object sender, CuttingCount.OnProgressChangedEventArgs e)
    {
        _barImage.fillAmount = e.progressNormalized;
        if(e.progressNormalized == 0f || e.progressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
