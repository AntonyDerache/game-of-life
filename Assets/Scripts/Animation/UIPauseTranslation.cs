using UnityEngine;

public class UIPauseTranslation : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private GameObject _background;
    private Vector3 _initialPos;

    private void Start() {
        this._initialPos = transform.position;
    }

    public void translationOn()
    {
        Cursor.SetCursor(null, Vector3.zero, CursorMode.ForceSoftware);
        transform.position = _endPoint.position;
        _background.SetActive(true);
    }

    public void TranslationOff()
    {
        transform.position = this._initialPos;
        _background.SetActive(false);
    }
}
