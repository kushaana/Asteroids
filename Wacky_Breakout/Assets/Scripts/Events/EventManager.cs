using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<PickupBrick> freezeEffectInvokers = new List<PickupBrick>();
    static List<UnityAction<float>> freezeEffectListeners = new List<UnityAction<float>>();
	static List<PickupBrick> speedUpEventInvokers = new List<PickupBrick>();
	static List<UnityAction<float, float>> speedUpEventListeners = new List<UnityAction<float, float>>();
	static List<Brick> addPointsEventInvokers = new List<Brick>();
	static List<UnityAction<float>> addPointsEventListeners = new List<UnityAction<float>>();
	static List<BallSpawner> reduceBallsEventInvokers = new List<BallSpawner>();
	static List<UnityAction> reduceBallsEventListeners = new List<UnityAction>();
	static List<HUD> lastBallLostEventInvokers = new List<HUD>();
	static List<UnityAction> lastBallLostEventListeners = new List<UnityAction>();
	public static void AddFreezeInvoker(PickupBrick invoker)
	{
		freezeEffectInvokers.Add(invoker);
		foreach(UnityAction<float> freezeEffectListener in freezeEffectListeners)
		{
			invoker.AddFreezeEventListener(freezeEffectListener);
		}
	}
	public static void AddFreezeListener(UnityAction<float> freezeEventHandler)
	{
		freezeEffectListeners.Add(freezeEventHandler);
		foreach(PickupBrick freezeInvoker in freezeEffectInvokers)
		{
			freezeInvoker.AddFreezeEventListener(freezeEventHandler);
		}
	}
	public static void AddSpeedUpEventInvoker(PickupBrick invoker)
	{
		speedUpEventInvokers.Add(invoker);
		foreach(UnityAction<float, float> speedUpListener in speedUpEventListeners)
        {
			invoker.AddSpeedUpEventListener(speedUpListener);
        }
	}
	public static void AddSpeedUpEventListener(UnityAction<float, float> speedUpEventHandler)
	{
		speedUpEventListeners.Add(speedUpEventHandler);
		foreach(PickupBrick speedUpInvoker in speedUpEventInvokers)
		{
			speedUpInvoker.AddSpeedUpEventListener(speedUpEventHandler);
		}
	}

	public static void AddPointsEventInvoker(Brick invoker)
	{
		addPointsEventInvokers.Add(invoker);
		foreach (UnityAction<float> addPointsListener in addPointsEventListeners)
		{
			invoker.AddPointsEventListener(addPointsListener);
		}
	}
	public static void AddPointsEventListener(UnityAction<float> addPointsEventHandler)
	{
		addPointsEventListeners.Add(addPointsEventHandler);
		foreach (Brick addPointsInvoker in addPointsEventInvokers)
		{
			addPointsInvoker.AddPointsEventListener(addPointsEventHandler);
		}
	}

	public static void AddReduceBallsEventInvoker(BallSpawner invoker)
	{
		reduceBallsEventInvokers.Add(invoker);
		foreach (UnityAction reduceBallsListener in reduceBallsEventListeners)
		{
			invoker.AddReduceBallsEventListener(reduceBallsListener);
		}
	}
	public static void AddReduceBallsEventListener(UnityAction reduceBallsEventHandler)
	{
		reduceBallsEventListeners.Add(reduceBallsEventHandler);
		foreach (BallSpawner reduceBallsInvoker in reduceBallsEventInvokers)
		{
			reduceBallsInvoker.AddReduceBallsEventListener(reduceBallsEventHandler);
		}
	}

	public static void AddLastBallLostEventInvoker(HUD invoker)
	{
		lastBallLostEventInvokers.Add(invoker);
		foreach (UnityAction lastBallLostListener in lastBallLostEventListeners)
		{
			invoker.AddLastBallLostEventListener(lastBallLostListener);
		}
	}
	public static void AddLastBallLostEventListener(UnityAction lastBallLostEventHandler)
	{
		lastBallLostEventListeners.Add(lastBallLostEventHandler);
		foreach (HUD lastBallLostInvoker in lastBallLostEventInvokers)
		{
			lastBallLostInvoker.AddLastBallLostEventListener(lastBallLostEventHandler);
		}
	}
}
