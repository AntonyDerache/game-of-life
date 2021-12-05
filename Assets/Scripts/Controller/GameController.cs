using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GridManager _gameData;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GameObject _gridContainer;
    [SerializeField] private Camera _cam;
    private CellController[,] _gridArray;
    private int _height;
    private int _width;
    private bool _ready = false;

    void Start()
    {
        this._gameData.color = new Color(
            Random.Range(.3f, 1f),
            Random.Range(.3f, 1f),
            Random.Range(.3f, 1f)
        );
        this._gameData.drawMode = false;
        this._gameData.dragMode = false;
        this._width = this._gameData.width;
        this._height = this._gameData.height;
        this._gridArray = new CellController[this._height, this._width];
        this.GenerateGrid();
        this._ready = true;
    }

    private void Update() {
        if (this._ready) {
            int maxY = this._gridArray.GetLength(0);
            int maxX = this._gridArray.GetLength(1);

            for (int y = 0; y < maxY; y++) {
                for (int x = 0; x < maxX; x++) {
                    int neighbours = CountLivingNeighbours(x, y, maxX, maxY);
                    if (this._gridArray[y, x]._isAlive) {
                        if (neighbours < 2) {
                            this._gridArray[y, x].SetNextState(false);
                        } else if (neighbours > 3) {
                            this._gridArray[y, x].SetNextState(false);
                        }
                    } else {
                        if (neighbours == 3) {
                            this._gridArray[y, x].SetNextState(true);
                        }
                    }
                }
            }
            for (int y = 0; y < maxY; y++) {
                for (int x = 0; x < maxX; x++) {
                    this._gridArray[y, x].Apply();
                }
            }
            float endtime = Time.deltaTime;
        }
    }

    private int CountLivingNeighbours(int x, int y, int maxX, int maxY)
    {
        int count = 0;

        if ((x - 1 >= 0 && y - 1 >= 0) && this._gridArray[y - 1, x - 1]._isAlive)
            count++;
        if (x - 1 >= 0 && this._gridArray[y, x - 1]._isAlive)
            count++;
        if ((x - 1 >= 0 && y + 1 < maxY) && this._gridArray[y + 1, x - 1]._isAlive)
            count++;
        if (y - 1 >= 0 && this._gridArray[y - 1, x]._isAlive)
            count++;
        if (y + 1 < maxY && this._gridArray[y + 1, x]._isAlive)
            count++;
        if ((x + 1 < maxX && y - 1 >= 0) && this._gridArray[y - 1, x + 1]._isAlive)
            count++;
        if (x + 1 < maxX && this._gridArray[y, x + 1]._isAlive)
            count++;
        if ((x + 1 < maxX && y + 1 < maxY) && this._gridArray[y + 1, x + 1]._isAlive)
            count++;
        return count;
    }

    public void OnDrop()
    {
        if (this._gameData.hoveredCellOnDragging == null) {
            return;
        }
        int[] coordinates = this._gameData.hoveredCellOnDragging;
        bool[,] shapeData = this._gameData.draggingShapeData;
        int maxY = this._gridArray.GetLength(0);
        int maxX = this._gridArray.GetLength(1);

        for (int y = shapeData.GetLength(0) - 1; y >= 0 ; y--) {
            for (int x = 0; x < shapeData.GetLength(1); x++) {
                if ((coordinates[1] - y) >= 0 && (coordinates[0] + x) < maxX) {
                    this._gridArray[(coordinates[1] - y), (coordinates[0] + x)].SetNewValue(shapeData[y, x]);
                }
            }
        }
    }

    private void GenerateGrid()
    {
        for (int y = 0; y < this._height; y++) {
            for (int x = 0; x < this._width; x++) {
                GameObject cell = Instantiate(this._cellPrefab, this._gridContainer.transform);
                cell.transform.position = new Vector3((x + 1) - this._width / 2, (y + 1) - this._height / 2, 0);
                this._gridArray[y, x] = cell.GetComponent<CellController>();
                this._gridArray[y, x].SetCoordinates(x, y);
            }
        }
        if (this._width > this._height)
            this._cam.orthographicSize = this._width / this._cam.aspect;
        else
            this._cam.orthographicSize = this._height / this._cam.aspect;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ClearGame()
    {
        for (int y = 0; y < this._gridArray.GetLength(0); y++) {
            for (int x = 0; x < this._gridArray.GetLength(1); x++) {
                this._gridArray[y, x].SetNewValue(false);
            }
        }
    }

    public void StartDraw()
    {
        this._ready = false;
        this._gameData.drawMode = true;
        Cursor.SetCursor(this._gameData.drawCursorTexture, Vector3.zero, CursorMode.ForceSoftware);
    }

    public void PauseGame()
    {
        this._ready = false;
    }

    public void ResumeGame()
    {
        this._ready = true;
    }

    public void DisableDrawMode()
    {
        if (this._gameData.drawMode) {
            this._gameData.drawMode = false;
        }
    }
}
