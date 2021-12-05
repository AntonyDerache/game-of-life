using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private GridManager _gameData;
    [SerializeField] private GameObject _buttonContainer;
    [SerializeField] private GameObject _background;
    [SerializeField] private ShapeData _shapeData;
    private UIPauseTranslation UIHandler;

    private void Start() {
        this.UIHandler = this._buttonContainer.GetComponent<UIPauseTranslation>();
    }

    public void OnDrag(PointerEventData eventData) {
        if (!this._gameData.dragMode) {
            this._gameData.dragMode = true;
            Cursor.SetCursor(this._gameData.dragCursorTexture, Vector3.zero, CursorMode.ForceSoftware);
            if (this.UIHandler) {
                this._background.SetActive(false);
                this.UIHandler.TranslationOff();
            }
            this._gameData.hoveredCellOnDragging = null;
            this._gameData.draggingShapeData = this._shapeData.data;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this._gameData.dragMode = false;
        Cursor.SetCursor(null, Vector3.zero, CursorMode.ForceSoftware);
        if (this.UIHandler) {
            this._background.SetActive(true);
            this.UIHandler.translationOn();
        }
        this._gameData.hoveredCellOnDragging = null;
        this._gameData.draggingShapeData = null;
    }
}
