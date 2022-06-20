using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropAtom : MonoBehaviour {

	private Vector3 mOffset;

    private float mZCoordinate;

	private void OnMouseDown()
    {

        mZCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mZCoordinate;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
