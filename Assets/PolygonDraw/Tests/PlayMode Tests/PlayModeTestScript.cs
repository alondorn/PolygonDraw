using System.Collections;
using System.Collections.Generic;
using AlonDorn.PolygonDraw;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayModeTestScript
{

    private PointsCollector _piontsCollector;
    private int polygonsAmount = 20;
    private int pointsAmount = 10;
    private WaitForSeconds waitBetweenShapes = new WaitForSeconds(0.1f);
    private WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();


    [OneTimeSetUp]
    public void Setup()
    {
        SceneManager.LoadScene("PolygonDrawer", LoadSceneMode.Single);
    }



    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayModeTestEnumeratorPasses()
    {
        Debug.Log("Start of PlayModeTestEnumeratorPasses()");
        _piontsCollector = GameObject.FindObjectOfType<PointsCollector>();
        yield return null;
        if (_piontsCollector == null)
        {
            Debug.LogError("_piontsCollector == null !!!");
            yield break;
        }
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        for(int i = 0; i < polygonsAmount; i++)
        {
            _piontsCollector.StartDrawing();

            for (int j = 0; j < pointsAmount; j++)
            {
                bool added = _piontsCollector.AddPointToMesh(new Vector3(Random.Range(50, Screen.width - 50), Random.Range(50, Screen.height - 50), 0));
                if (j > 1 && !added)
                {
                    Debug.LogWarning("Failed to add point");
                    yield return new WaitForSeconds(10);
                }
                yield return _waitForEndOfFrame;
            }

            _piontsCollector.StopDrawing();

            yield return waitBetweenShapes;
        }
       
        yield return new WaitForSeconds(5);
    }



}
