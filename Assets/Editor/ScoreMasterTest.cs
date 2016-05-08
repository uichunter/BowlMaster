using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class ScoreMasterTest  {


	private List<FrameList> frameList;
	private List<int> guess;
	private List<int> scoreList;

	[SetUp]
	public void Setup ()
	{
		frameList = new List<FrameList>();
		guess = new List<int>();
		scoreList = new List<int>();
	}

	public void AddFrame (int frameId,int rollID,int pinDown)
	{
		frameList.Add(new FrameList{FrameID=frameId,RollID=rollID,PinDown=pinDown});
	}

	[Test]
	public void T01Normal(){
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=1,RollID=2,PinDown=1});

		guess.Add(2);
		Assert.AreEqual(guess,ScoreMaster.GetScoreList(frameList));
	}

	[Test]
	public void T02FewMoreStep(){
		
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=1,RollID=2,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=2,PinDown=1});


		guess.Add(2);
		guess.Add(4);
		Assert.AreEqual(guess,ScoreMaster.GetScoreList(frameList));
	}

	[Test]
	public void T03OneStrike(){
		
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=10});
		//frameList.Add(new FrameList{FrameID=2,RollID=1,PinDown=1});
		//frameList.Add(new FrameList{FrameID=2,RollID=2,PinDown=1});


		//guess.Add(12);
		//guess.Add(14);
		scoreList = ScoreMaster.GetScoreList(frameList);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T04DoubleStrke ()
	{
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=10});
		frameList.Add(new FrameList{FrameID=2,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=2,PinDown=1});
		frameList.Add(new FrameList{FrameID=3,RollID=1,PinDown=10});

		scoreList = ScoreMaster.GetScoreList(frameList);

		guess.Add(12);
		guess.Add(14);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T05ThreeSpare()
	{
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=3});
		frameList.Add(new FrameList{FrameID=1,RollID=2,PinDown=7});
		frameList.Add(new FrameList{FrameID=2,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=2,PinDown=9});
		frameList.Add(new FrameList{FrameID=3,RollID=1,PinDown=5});
		frameList.Add(new FrameList{FrameID=3,RollID=2,PinDown=5});

		scoreList = ScoreMaster.GetScoreList(frameList);

		guess.Add(11);
		guess.Add(26);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T06AllOneBeforeFrame10 ()
	{
		for (int i = 1; i <= 9; i++) {
			for (int j = 1; j <= 2; j++) {
				frameList.Add (new FrameList{ FrameID = i, RollID = j, PinDown = 1});
			}
		}

		scoreList = ScoreMaster.GetScoreList (frameList);

		int sum =0;
		for (int i = 1; i <= 9; i++) {
			sum += 2;
			guess.Add(sum);
		}
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T07FullOneHit()
	{
		for (int i = 1; i <= 9; i++) {
			for (int j = 1; j <= 2; j++) {
				frameList.Add (new FrameList{ FrameID = i, RollID = j, PinDown = 1});
			}
		}
		AddFrame(10,1,1);
		AddFrame(10,2,1);

		scoreList = ScoreMaster.GetScoreList (frameList);

		int sum =0;
		for (int i = 1; i <= 9; i++) {
			sum += 2;
			guess.Add(sum);
		}
		guess.Add(20);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T08LastFrameSituationSpare ()
	{
		for (int i = 1; i <= 9; i++) {
			for (int j = 1; j <= 2; j++) {
				AddFrame(i,j,1);
			}
		}
		AddFrame(10,1,1);
		AddFrame(10,2,9);
		AddFrame(10,3,10);

		scoreList = ScoreMaster.GetScoreList (frameList);

		int sum =0;
		for (int i = 1; i <= 9; i++) {
			sum += 2;
			guess.Add(sum);
		}
		guess.Add(38);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T09LastFrameSituation3Strike ()
	{
		for (int i = 1; i <= 9; i++) {
			for (int j = 1; j <= 2; j++) {
				AddFrame(i,j,1);
			}
		}
		AddFrame(10,1,10);
		AddFrame(10,2,10);
		AddFrame(10,3,10);

		scoreList = ScoreMaster.GetScoreList (frameList);

		int sum =0;
		for (int i = 1; i <= 9; i++) {
			sum += 2;
			guess.Add(sum);
		}
		guess.Add(48);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T10LastFrameSituationOneMissAndSpare ()
	{
		for (int i = 1; i <= 9; i++) {
			for (int j = 1; j <= 2; j++) {
				AddFrame(i,j,1);
			}
		}
		AddFrame(10,1,0);
		AddFrame(10,2,10);
		AddFrame(10,3,10);

		scoreList = ScoreMaster.GetScoreList (frameList);

		int sum =0;
		for (int i = 1; i <= 9; i++) {
			sum += 2;
			guess.Add(sum);
		}
		guess.Add(38);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T11InternetScore ()
	{
		AddFrame(1,1,10);
		AddFrame(2,1,7);
		AddFrame(2,2,3);
		AddFrame(3,1,9);
		AddFrame(3,2,0);
		AddFrame(4,1,10);
		AddFrame(5,1,0);
		AddFrame(5,2,8);
		AddFrame(6,1,8);
		AddFrame(6,2,2);
		AddFrame(7,1,0);
		AddFrame(7,2,6);
		AddFrame(8,1,10);
		AddFrame(9,1,10);
		AddFrame(10,1,10);
		AddFrame(10,2,8);
		AddFrame(10,3,1);

		scoreList = ScoreMaster.GetScoreList (frameList);

		guess.Add(20);guess.Add(39);guess.Add(48);guess.Add(66);
		guess.Add(74);guess.Add(84);guess.Add(90);guess.Add(120);
		guess.Add(148);guess.Add(167);
		Assert.AreEqual(guess,scoreList);
	}
}
