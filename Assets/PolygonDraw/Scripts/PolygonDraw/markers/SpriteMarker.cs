using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlonDorn.PolygonDraw
{
    public class SpriteMarker : Marker, IPlacable 
    {

        [SerializeField] GameObject markerPrefab;

        

        public override GameObject CreateMatker()
        {
            GameObject newMarker = Instantiate(markerPrefab);
            return newMarker;
        }



        public GameObject PlaceInScene(Vector3 position, bool isLocalSpace = false)
        {
            GameObject newMarker = CreateMatker();
            if(isLocalSpace)
                newMarker.transform.localPosition = position;
            else
                newMarker.transform.position = position;
            return newMarker;
        }

    }
}
