﻿using UnityEngine;
using System;
using System.Collections;
using Matcha.Game.Tweens;


public class PickupEntity : Entity
{
	public enum EntityType { none, prize, weapon };
	public EntityType entityType;
	public Light glow;

	void Start()
	{
		glow = gameObject.GetComponent<Light>() as Light;

		if (entityType == EntityType.prize) { AutoAlign(); }
	}

	public override void ReactToCollision()
	{
		switch (entityType)
		{
			case EntityType.none:
				break;

			case EntityType.prize:
				MTween.PickupPrize(gameObject);
				MTween.ExtinguishLight(glow, 0, .1f);
				break;

			case EntityType.weapon:
				MTween.PickupWeapon(gameObject);
				break;
		}
	}
}
