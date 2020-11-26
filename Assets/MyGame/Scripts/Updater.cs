using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Updater : MonoBehaviour {

    [SerializeField] private Text randomText;
    [SerializeField] private GameObject circleColor;
    [SerializeField] private GameObject circleObjPosition, circPosLeft, circPosRight;
    [SerializeField] private GameObject[] circleSizeObjects;
    [SerializeField] private List<Image> colorImages;


    private List<Color> colorList;
    private System.Random rnd = new System.Random();
    private string[] stringArray = new string[5];
    private float circLeft, circRight;
    private Transform circTransform;

    private void Start()
    {
        circTransform = circleObjPosition.GetComponent<Transform>();
        Transform left = circPosLeft.GetComponent<Transform>();
        Transform right = circPosRight.GetComponent<Transform>();

        circLeft = left.localPosition.x;
        circRight = right.localPosition.x;


        stringArray = new string[] { "one", "two", "three", "four", "five" };

        colorList = new List<Color> {
            Color.red,
            Color.blue,
            Color.green,
            Color.magenta
        };

        for (int i = 0; i < colorImages.Count; i++)
        {
            colorImages[i].color = colorList[i];
        }
    }

    public void UpdateRandomText()
    {
        randomText.text = stringArray[rnd.Next(1,5)];
    }

    public void ShuffleCircleColor()
    {
        SpriteRenderer circRenderer = circleColor.GetComponent<SpriteRenderer>();
        byte r = (byte)rnd.Next(0, 255);
        byte g = (byte)rnd.Next(0, 255);
        byte b = (byte)rnd.Next(0, 255);
        byte a = (byte)rnd.Next(0, 255);

        circRenderer.color = new Color32(r, g, b, a);
    }
	
    public void ShuffleObjectPosition()
    {
        float randomPosX = UnityEngine.Random.Range(circLeft, circRight);
        circTransform.localPosition = new Vector3(randomPosX, circTransform.localPosition.y, circTransform.localPosition.z);
    }

    public void ShuffleCirclesSize()
    {
        int objIndex = rnd.Next(0, circleSizeObjects.Length);
        
        SetCircObjectActive(objIndex);
    }

    public void ShuffleImageColors()
    {
        colorList.Shuffle();

        for (int i = 0; i < colorImages.Count; i++)
        {
            colorImages[i].color = colorList[i];
        }
    }

    private void SetCircObjectActive(int index)
    {
        SetAllCircObjectsInactive();
        circleSizeObjects[index].SetActive(true);
    }

    private void SetAllCircObjectsInactive()
    {
        for(int i=0; i < circleSizeObjects.Length; i++)
        {
            circleSizeObjects[i].SetActive(false);
        }
    }
}
