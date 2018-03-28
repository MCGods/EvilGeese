using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour {
	GameObject slotPanel;
	List<GameObject>[] slotObjects;

	const float offsetY = 80f;
	const float offsetX = 150f;

	float[] currentPos = {0f,0f,0f};
	float[] startSpeeds = { 6.8f, 6.9f, 7f };
	float[] spinSpeeds;
	public int[] stopAt;
	public int stopping = 0; // which wheel is stopping (valid values are 0,1 and 2)
	public float freeSpins = 1f; //how many times to spin before starting to slow down
	public float distanceToStop;
	bool canStop = false;

	// Use this for initialization
	void Start () {
		slotPanel = this.transform.Find ("SlotPanel").gameObject;
		spinSpeeds = new float[3];
		slotObjects = new List<GameObject>[3];
		stopAt = new int[3];
		for (int m = 0; m <= 2; m++) {
			spinSpeeds [m] = startSpeeds [m];
			slotObjects [m] = new List<GameObject> ();
			for (int i = 0; i < 20+m; i++) {
				GameObject g = Instantiate (slotPanel, this.transform);
				slotObjects [m].Add (g);
				g.SetActive (true);
				g.transform.position += new Vector3 (offsetX, 0f) * (m - 1);
				g.transform.Find ("Text").gameObject.GetComponent<UnityEngine.UI.Text> ().text = i.ToString ();
			}
			stopAt [m] = Random.Range (0, slotObjects [m].Count - 1);
			setSlotsScale (slotObjects [m], currentPos [m]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i <=2; i++){
			currentPos [i] += spinSpeeds [i] * Time.deltaTime;
			currentPos [i] %= slotObjects [i].Count;
			setSlotsScale (slotObjects [i], currentPos [i]);

			if (i == stopping) {
				freeSpins = Mathf.Max (0f, freeSpins - ((spinSpeeds [i] * Time.deltaTime) / slotObjects [i].Count));
				distanceToStop = Mathf.Repeat (stopAt [i] - currentPos [i], slotObjects [i].Count);
				if (freeSpins == 0f && distanceToStop > slotObjects[i].Count - 1) {
					canStop = true;
				}
			} 
			if (i == stopping && canStop) {
				spinSpeeds [i] = Mathf.Clamp(distanceToStop/slotObjects[i].Count*startSpeeds[i], 0.5f, startSpeeds[i]);
				if (distanceToStop < 0.1f) {
					spinSpeeds [i] = 0f;
					currentPos [i] = stopAt [i];
					stopping++;
					if (stopping <= 2){
						freeSpins = 2f + Mathf.Repeat (stopAt [stopping] - currentPos [stopping], slotObjects [stopping].Count)/slotObjects[stopping].Count;
						canStop = false;
					}
				}
			}
		}
	}

	void setSlotsScale(List<GameObject> slots, float pos){
		int c = slots.Count;
		for (int i = 0; i < c; i++){
			pos += 2;
			pos = Mathf.Repeat (pos, c);
			pos -= 2;
			if (Mathf.Clamp (pos, -2f, 2f) == pos) {
				Vector3 prev = slots [i].transform.position;
				slots [i].transform.position = new Vector3 (prev.x, -Mathf.Sin (pos/4 * Mathf.PI) * 2 * offsetY + slotPanel.transform.position.y);
				slots [i].transform.localScale = new Vector3 (1f, Mathf.Cos (pos/4 * Mathf.PI));
			} else {
				slots [i].transform.localScale = new Vector3 (1f, 0f);
			}
			pos -= 1f;
		}
	}
}
