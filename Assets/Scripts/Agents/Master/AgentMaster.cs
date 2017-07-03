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

}
