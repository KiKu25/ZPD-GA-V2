using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class AgentMaster : MonoBehaviour {

    //decoded seed: name(lenght): nodeCount(1|max = 6)|nodeNr(1)nodeLoactinX(2)nodeLoactinY(2)muscleMinDist(3)muscleMaxDist(3)muscleDamping(1)muscleFeruency(2)muscleContractionRate(1)muscleTimeBetvinePulses(3)muscleTargetNodeNr(1)
    //0|0000000000000000000|0000000000000000000|0000000000000000000|0000000000000000000|0000000000000000000|0000000000000000000|0000000000000000000|
    //00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
    public string testSeed = "31000022ff00337f7f00000000000000000000";
    public string testSeed2;

    public int startX = -3;
    public int startY = -36;

    List<string> allAgentSeeds;
    List<string> currentAgentSeeds;

    HexEncoderDecoder hexEnDe;

	// Use this for initialization
	void Start () {
        allAgentSeeds = new List<string>();
        currentAgentSeeds = new List<string>();
        hexEnDe = new HexEncoderDecoder();

	}
	
    public void SpawnAgents()
    {
        
    }

    public void SpawnTestAgent()
    {
        SpawnAgnet(testSeed);
    }

    void SpawnAgnet(string seed)
    {

    }

    public void SaveAgent()
    {
        GameObject goAgent = GameObject.FindGameObjectWithTag("Agent");
        SortedList<string, GameObject> goMuscles = new SortedList<string, GameObject>();
        SortedList<string, GameObject> goNodes = new SortedList<string, GameObject>();

        GameObject[] tempAr = GameObject.FindGameObjectsWithTag("Muscle");
        foreach (GameObject muscle in tempAr)
        {
            goMuscles.Add(muscle.name, muscle);
        }

        tempAr = GameObject.FindGameObjectsWithTag("Node");
        foreach (GameObject node in tempAr)
        {
            goNodes.Add(node.name, node);
        }

        //Make a Seed
        testSeed2 = "";
        //Nodes
        testSeed2 += hexEnDe.EncodeHex(goNodes.Count);
        GameObject temp;

        for (int i = 0; i < goNodes.Count; i++)
        {
            temp = goNodes.Values[i];
            //nodeNr(1)
            testSeed2 += hexEnDe.EncodeHex(i);
            //nodeLoactinX(2)
            testSeed2 += hexEnDe.EncodeHexXY(temp.transform.position.x, startX);
            //nodeLoactinY(2)
            testSeed2 += hexEnDe.EncodeHexXY(temp.transform.position.y, startY);

        }

        //Log Seed to Console
        Debug.Log("Temp Seed 2: " + testSeed2);
    }

}
