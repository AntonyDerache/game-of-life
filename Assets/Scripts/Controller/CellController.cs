using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private GridManager _gameData;
    private SpriteRenderer _sprite;
    private bool _nextState;
    private int[] _coordinates = null;

    public bool _isAlive;

    private void Start()
    {
        this._sprite = gameObject.GetComponent<SpriteRenderer>();
        this._isAlive = (Random.Range(0, 2) == 1);
        if (this._isAlive) {
            this._sprite.color = this._gameData.color;
        }
    }

    public void SetCoordinates(int x, int y)
    {
        this._coordinates = new int[2] {x, y};
    }

    public void SetNextState(bool nextState)
    {
        this._nextState = nextState;
    }

    private void PreviewColor(bool value)
    {
        if (value) {
            this._sprite.color = this._gameData.color;
        } else {
            this._sprite.color = Color.black;
        }
    }

    public void Apply()
    {
        if (this._isAlive == this._nextState)
            return;
        this._isAlive = this._nextState;
        this.PreviewColor(this._nextState);
    }

    public void SetNewValue(bool value)
    {
        this._nextState = value;
        this._isAlive = value;
        this.PreviewColor(value);
    }

    private void OnMouseExit() {
        if (this._gameData.drawMode || this._gameData.dragMode) {
            this.PreviewColor(this._isAlive);
        }
        if (this._gameData.dragMode) {
            this._gameData.hoveredCellOnDragging = null;
        }
    }

    private void OnMouseEnter() {
        if (this._gameData.drawMode || this._gameData.dragMode) {
            this.PreviewColor(!this._isAlive);
        }
        if (this._gameData.dragMode) {
            this._gameData.hoveredCellOnDragging = this._coordinates;
        }
    }

    private void OnMouseDown() {
        if (this._gameData.drawMode) {
            this.SetNewValue(!this._isAlive);
        }
    }
}
