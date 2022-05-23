using AlonDorn.Messaging;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace AlonDorn.PolygonDraw
{
    public class PointsCollector : MonoBehaviour
    {
        [SerializeField] InputActionReference _leftClickAction;
        [SerializeField] Camera _camera;
        [SerializeField] Material _polygonMaterial;
        
        MeshFilter _currentMeshFilter;

        List<Vector3> _pointList = new List<Vector3>();

        [SerializeField] Marker _markerPlacer;
        IPlacable _placableMarker;
        List<GameObject> _markers = new List<GameObject>();



        private void Awake()
        {
            _placableMarker = _markerPlacer.GetComponent<IPlacable>();
        }

        private void OnEnable()
        {
            _leftClickAction.action.performed += OnMouseClick;
        }

        private void OnDisable()
        {
            _leftClickAction.action.performed -= OnMouseClick;
        }



        public void StartDrawing()
        {
            _leftClickAction.action.Enable();
            Messanger.Execute(AppEvents.ON_START_EDITING);
        }

        public void StopDrawing()
        {
            _leftClickAction.action.Disable();
            _pointList.Clear();
            ClearMarkers();
            _currentMeshFilter = null;
            Messanger.Execute(AppEvents.ON_FINISH_EDITING);
        }



        void OnMouseClick(InputAction.CallbackContext callbackContext)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            AddPointToMesh(mousePosition);
        }


        public bool AddPointToMesh(Vector3 mousePos)
        {
            mousePos.z = 10;
            Vector3 worldPoint = _camera.ScreenToWorldPoint(mousePos);
            if (_pointList.Count == 0)
            {
                Debug.Log("creating new object");
                GameObject newPolygon = new GameObject("New Polygon");
                _currentMeshFilter = newPolygon.AddComponent<MeshFilter>();
                newPolygon.AddComponent<MeshRenderer>().sharedMaterial = _polygonMaterial;
            }
            _pointList.Add(worldPoint);
            _markers.Add(_placableMarker.PlaceInScene(worldPoint));
            Mesh newMesh = MeshGenerator.GetMesh(_pointList.ToArray());
            if (newMesh != null)
            {
                _currentMeshFilter.sharedMesh = newMesh;
                return true;
            }
            else
            {
                return false;
            }
        }



        void ClearMarkers()
        {
            int count = _markers.Count;
            for (int i = 0; i < count; i++)
            {
                Destroy(_markers[i]);
            }
            _markers.Clear();
        }


    }
}

