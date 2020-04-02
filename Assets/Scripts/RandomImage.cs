using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomImage : MonoBehaviour {
public Image randomImage;
public Sprite s1;
public Sprite s2;
public Sprite s3;
private Sprite[] images;
int num;

 public void Start()
{
    images = new Sprite[3];
    images[0] = s1;
    images[1] = s2;
    images[2] = s3;
	StartCoroutine("ChangeSprite");
}


void ChangeSprite()
{
    num = UnityEngine.Random.Range(0,3);
	Debug.Log(num);
    randomImage.sprite = images[num];
	
}


}
