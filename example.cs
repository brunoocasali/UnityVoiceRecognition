using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testingscript : MonoBehaviour {

    private VoiceRec.VoiceClass obj;
    private string word;

    void Start () {
        obj = new VoiceRec.VoiceClass();
        //set of commands : replace with set of commands to be recognized
        string[] str = { "left", "right", "down", "up" };
        obj.initRecog(str);
	}
	
	void Update () {
        word = obj.getWord();
        if (word != null && word != "")
        {
            switch (word)
            {
                case "left":
                    print("Voice input : left");
                    break;
                case "right":
                    print("Voice input : right");
                    break;
                case "down":
                    print("Voice input : down");
                    break;
                case "up":
                    print("Voice input : up");
                    break;
            }
        }
	}
}
