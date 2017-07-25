using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class AgentMaster : MonoBehaviour {

    //decoded seed: name(lenght): nodeCount(1|max = 6)|nodeNr(1)nodeLoactinX(2)nodeLoactinY(2)muscleMinDist(3)muscleMaxDist(3)muscleDamping(1)muscleFeruency(2)muscleContractionRate(1)muscleTimeBetvinePulses(3)muscleTimeDelay(2)muscleTargetNodeNr(1)
    //0|000000000000000000000|000000000000000000000|000000000000000000000|000000000000000000000|000000000000000000000|000000000000000000000|000000000000000000000|
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

    //TODO: Remove
    public void SpawnTestAgent()
    {
        SpawnAgnet(testSeed);
    }

    //TODO: Make this work
    void SpawnAgnet(string seed)
    {

    }

    /// <summary>
    /// Saves the seed of the current agent
    /// </summary>
    public void SaveAgent()
    {
        GameObject goAgent = GameObject.FindGameObjectWithTag("Agent");
        //SortedList<string, GameObject> goMuscles = new SortedList<string, GameObject>();
        SortedList<string, GameObject> goNodes = new SortedList<string, GameObject>();
        GameObject[] tempAr;
        //TODO: Ja izmanto jamain vards no "Muscle (Clone)" uz "Muslce (1)", "Muslce (2)" utt. savadak  so metodi nevar izmantot
        //foreach (GameObject muscle in tempAr)
        //{
        //    goMuscles.Add(muscle.name, muscle);
        //}

        tempAr = GameObject.FindGameObjectsWithTag("Node");
        foreach (GameObject node in tempAr)
        {
            goNodes.Add(node.name, node);
        }

        //Make a blank Seed
        testSeed2 = "";
        //Nodes
        testSeed2 += hexEnDe.EncodeHex(goNodes.Count);

        for (int i = 0; i < 5; i++)
        {
            if (goNodes.Count > i)
            {
                GameObject goNode = goNodes.Values[i];
                //GameObject goMuscle = goMuscles.Values[i];

                Joints joint = goNode.GetComponent<Joints>();

                //TODO: Complite this

                //nodeNr(1)
                testSeed2 += hexEnDe.EncodeHex(i);
                //nodeLoactinX(2)
                testSeed2 += hexEnDe.EncodeHexWithOffset(goNode.transform.position.x, startX);
                //nodeLoactinY(2)
                testSeed2 += hexEnDe.EncodeHexWithOffset(goNode.transform.position.y, startY);
                //muscleMinDist(3)
                testSeed2 += hexEnDe.EncodeHex((int)joint.minDist);
                //muscleMaxDist(3)
                testSeed2 += hexEnDe.EncodeHex((int)joint.maxDist);
                //muscleDamping(1)
                testSeed2 += hexEnDe.EncodeFloatToHex(joint.GetDamping(), 1);
                //muscleFeruency(2)
                testSeed2 += hexEnDe.EncodeFloatToHex(joint.GetFrequency(), 1);
            }
            else
            {
                testSeed2 += "000000000000000000000";
            }
        }

        //Log Seed to Console
        Debug.Log("Temp Seed 2: " + testSeed2);
    }

}
