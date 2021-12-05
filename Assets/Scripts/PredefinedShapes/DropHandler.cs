using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    private GameController _gameController;

    void Start()
    {
        GameObject obj = GameObject.Find("GameManager");

        if (obj) {
            _gameController = obj.GetComponent<GameController>();
        }
    }

    public void OnDrop(PointerEventData data)
    {
        if (data.pointerDrag != null) {
            _gameController.OnDrop();
        }
    }
}
