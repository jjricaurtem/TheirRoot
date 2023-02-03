using UnityEngine;

namespace TheirRoot
{
    public class LinesDrawer : MonoBehaviour
    {
        public GameObject linePrefab;

        public Gradient lineColor;
        public float linePointsMinDistance;
        public float lineWidth;

        public float distanceFromMouse = 0.2f;
        private Camera _cam;

        private Line _currentLine;
        private Vector2 _lastPaintedPosition;

        private void Start()
        {
            _cam = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                BeginDraw();

            if (_currentLine != null)
                Draw();

            if (Input.GetMouseButtonUp(0))
                EndDraw();
        }

        private void Draw()
        {
            var mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePosition, _lastPaintedPosition) < distanceFromMouse) return;

            var rayStartPosition = Vector2.MoveTowards(_lastPaintedPosition, mousePosition, 0.3f);
            var hit = Physics2D.Raycast(rayStartPosition, mousePosition);
            Debug.DrawLine(rayStartPosition, mousePosition, hit.collider ? Color.red : Color.green);
            if (hit.collider is not null)
            {
                Debug.Log($"Está sobre :{hit.transform.name}");
            }
            else
            {
                var newPaintedPosition = Vector2.Lerp(mousePosition, _lastPaintedPosition, 0.5f);
                _lastPaintedPosition = newPaintedPosition;
                _currentLine.AddPoint(newPaintedPosition);
            }
        }

        private void BeginDraw()
        {
            _currentLine = Instantiate(linePrefab, transform).GetComponent<Line>();
            _currentLine.SetLineColor(lineColor);
            _currentLine.SetPointsMinDistance(linePointsMinDistance);
            _currentLine.SetLineWidth(lineWidth);

            var mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            _lastPaintedPosition = mousePosition;
        }

        private void EndDraw()
        {
            if (_currentLine is null) return;
            if (_currentLine.PointsCount < 2) Destroy(_currentLine.gameObject);
            else _currentLine = null;
        }
    }
}