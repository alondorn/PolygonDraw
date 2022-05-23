using AlonDorn.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlonDorn.PolygonDraw
{
    public class UIManager : MonoBehaviour
    {


        [SerializeField] Text modeIndicationText;



        private void OnEnable()
        {
            Messanger.Subscribe(AppEvents.ON_START_EDITING, OnStartDrawing);
            Messanger.Subscribe(AppEvents.ON_FINISH_EDITING, OnFinishDrawing);
        }

        private void OnDisable()
        {
            Messanger.Unsubscribe(AppEvents.ON_START_EDITING, OnStartDrawing);
            Messanger.Unsubscribe(AppEvents.ON_FINISH_EDITING, OnFinishDrawing);
        }


        private void Start()
        {
            OnFinishDrawing();
        }

        void OnStartDrawing()
        {
            modeIndicationText.color = Color.red;
            modeIndicationText.text = "Polygon drawing mode";
        }


        void OnFinishDrawing()
        {
            modeIndicationText.color = Color.green;
            modeIndicationText.text = "Click on 'Start Drawing' Button to start drawing polygons.";
        }
    }
}
