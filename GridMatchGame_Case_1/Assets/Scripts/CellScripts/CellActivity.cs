using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
public class CellActivity : MonoBehaviour, IClickable
{
    private bool isMarked;
    private int neighbourCount;
    private Color OriginalColor;
    public GameObject Mark;
    public SpriteRenderer Square;

    public int NeighbourCount
    {
        get => neighbourCount;
        set => neighbourCount = value;
    }

    private void Awake()
    {
        OriginalColor = Square.color;
    }

    public void Click()
    {
        if (!isMarked) MarkCell();
    }

    private void MarkCell()
    {
        isMarked = true;
        Mark.SetActive(true);
        Square.color = new Color(OriginalColor.r,OriginalColor.g,OriginalColor.b,OriginalColor.a / 2);
        // Isaretledigimiz hucrenin Griddeki pozisyonunu bul ve Listede tut.
        Vector2Int MarkedPosition = new Vector2Int((int)gameObject.transform.position.x, (int)gameObject.transform.position.y);
        GridManager.Instance.MarkPositions.Add(MarkedPosition);

        // Marklanan h�cre icin tarama yap.
        EventManager.OnMatchCheck?.Invoke(MarkedPosition);
    }

    public void UnMarkCell()
    {
        isMarked = false;
        Mark.SetActive(false);
        neighbourCount = 0;
        Square.color = new Color(OriginalColor.r, OriginalColor.g, OriginalColor.b, OriginalColor.a);

    }

}
