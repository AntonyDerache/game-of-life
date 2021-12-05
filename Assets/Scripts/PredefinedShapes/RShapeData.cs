using UnityEngine;

[CreateAssetMenu(fileName = "RShapeData", menuName = "GameOfLife/RShapeData", order = 0)]
public class RShapeData : ShapeData
{
    public RShapeData()
    {
        data = new bool[3, 3] {
            {false, true, true},
            {true, true, false},
            {false, true, false}
        };
    }
}