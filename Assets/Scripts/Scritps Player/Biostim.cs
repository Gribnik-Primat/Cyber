using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Biostim : MonoBehaviour {

    public float biostim;
    public bool stels;
    //   public GameObject sliderPrefabB;

    public Slider biostimSlider;
  //  RectTransform biostimTrans;

    void Start ()
    {
        biostim = 100f;
        stels = false;

        //GameObject slidB = Instantiate(sliderPrefabB, transform.position, Quaternion.identity) as GameObject;
        //slidB.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        //biostimSlider = GetComponent<Slider>();
        //biostimTrans = slidB.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update ()
    {
        //Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        //biostimTrans.transform.position = screenPoint;
        if(biostim > 100)
        {
            biostim = 100;
        }

        if (stels)
        {
            biostim = biostim -= 10f *Time.deltaTime;
            biostimSlider.value = biostim;
        }
             
	}

	public void setBiostim(float value)
	{
		biostim += value;
	}

    public void Stels()
    {
        stels = !stels;
    } 
}
