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
}
