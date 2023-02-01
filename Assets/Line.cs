using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Line : MonoBehaviour, IPointerClickHandler
{
    public LineRenderer lineRenderer;

    public EdgeCollider2D edgeCollider;

    private List<Vector2> points = new();

    private int _pointsCount = 0;

    private float _pointsMinDistance = 0.1f;

    public int PointsCount => _pointsCount;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click on me");
    }

    public void AddPoint(Vector2 newPoint)
    {
        if (PointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < _pointsMinDistance) return;
        
        points.Add(newPoint);
        _pointsCount = PointsCount + 1;

        lineRenderer.positionCount = PointsCount;
        lineRenderer.SetPosition(PointsCount-1, newPoint);

        if (points.Count > 1)
            edgeCollider.points = points.ToArray();
    }

    public Vector2 GetLastPoint() => lineRenderer.GetPosition(PointsCount - 1);

    public void SetLineColor(Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        edgeCollider.edgeRadius = width / 2f;
    }

    public void SetPointsMinDistance(float pointsMinDistance)
    {
        _pointsMinDistance = pointsMinDistance;
    }
}