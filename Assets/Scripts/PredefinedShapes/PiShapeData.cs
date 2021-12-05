using UnityEngine;

[CreateAssetMenu(fileName = "PiShapeData", menuName = "GameOfLife/PiShapeData", order = 0)]
public class PiShapeData : ShapeData
{
    public PiShapeData()
    {
        data = new bool[3, 3] {
            {true, true, true},
            {true, false, true},
            {true, false, true}
        };
    }
}
