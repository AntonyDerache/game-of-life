using UnityEngine;

[CreateAssetMenu(fileName = "CrossShapeData", menuName = "GameOfLife/CrossShapeData", order = 0)]
public class CrossShapeData : ShapeData
{
    public CrossShapeData()
    {
        data = new bool[8, 8] {
            {false, false, true, true, true, true, false, false},
            {false, false, true, false, false, true, false, false},
            {true, true, true, false, false, true, true, true},
            {true, false, false, false, false, false, false, true},
            {true, false, false, false, false, false, false, true},
            {true, true, true, false, false, true, true, true},
            {false, false, true, false, false, true, false, false},
            {false, false, true, true, true, true, false, false},
        };
    }
}
