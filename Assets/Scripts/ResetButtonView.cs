using UnityEngine;

public class ResetButtonView : MonoBehaviour
{
    public void OnClick()
    {
        GameController.Instance.ResetCells();
    }
}
