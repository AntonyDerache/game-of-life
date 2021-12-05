using UnityEngine;

[CreateAssetMenu(fileName = "GridManager", menuName = "GameOfLife/GridManager", order = 0)]
public class GridManager : ScriptableObject
{
    public int width = 100;
    public int height = 100;
    public Color color = Color.white;
    public bool drawMode = false;
    public bool dragMode = false;
    public Texture2D dragCursorTexture;
    public Texture2D drawCursorTexture;
    [HideInInspector] public int[] hoveredCellOnDragging = null;
    [HideInInspector] public bool[,] draggingShapeData = null;
}