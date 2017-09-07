using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to handle keyboard events for Spiders
public class SpiderKeybaordHandler : MonoBehaviour {

	private SpiderController firstSpider;

	private SpiderController secondSpider;

	private SpiderController thridSpider;

	private SpiderController fourthSpider;

	private SpiderController fifthSpider;
	
	// Use this for initialization
	void Start () {
		firstSpider = SpiderPositioner.spiders [0].GetComponent<SpiderController>();
		secondSpider = SpiderPositioner.spiders [1].GetComponent<SpiderController>();
		thridSpider = SpiderPositioner.spiders [2].GetComponent<SpiderController>();
		fourthSpider = SpiderPositioner.spiders [3].GetComponent<SpiderController>();
		fifthSpider = SpiderPositioner.spiders [4].GetComponent<SpiderController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
			firstSpider.moveSpider();
		if (Input.GetKeyDown (KeyCode.S))
			secondSpider.moveSpider();
		if (Input.GetKeyDown (KeyCode.D))
			thridSpider.moveSpider();
		if (Input.GetKeyDown (KeyCode.F))
			fourthSpider.moveSpider();
		if (Input.GetKeyDown (KeyCode.Space))
			fifthSpider.moveSpider();
	}

}
