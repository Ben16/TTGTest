Ben Fickes - Tic Toc Games Test Submission

Implementation Approach:

I started with movement. I first got the player moving with no regards to camera direction, then reworked it to be the current implementation: forward vs. side to side.
I added jumping next. Most of the work here was checking if the player was grounded or not.

I then moved on to coins. I knew the player would have to pick up both coins and the gun on the platform, so I made a shared parent class Collectible.
Since I wanted to make sure that anything hitting the coins wouldn't destroy them (i.e. projectiles, or a hypothetical wandering NPC), I added the function CanInteractWith, which allows Collectibles to define who can pick them up.
I added a UI element for coins. I wanted to make sure not to store coin data in the UI element itself, so I made an Inventory for the player. The UI element watches that Inventory for changes, but it theoreticlaly could be hooked up to any other Inventory.

Next, I made the weapon equipping logic. I made ScriptableObject weapons that can have their stats and appearance set up. The WeaponPickup simply has a Weapon that it equips to whomever picks it up.

For the actual firing logic, I made each Weapon have a Projectile it uses. When the player fires the Weapon, if they have one, it will spawn the projectile with various stats from the Weapon.
I then made Damageables (which I made Target a child class of). At first, all I had was an OnDamaged function, but I later refactored this to have more functionality, such as a notion of health (and gave Weapons damage values).

Lastly, I implemented aiming funcitonality and restricted firing to being while in 1p. I simply traced from the camera for a target, or used a position a certain distance along the camera ray if it wasn't looking at a collidable object.
The Projectile is simply spawned from the weapon toward the aim point.

Assumptions:

I tried to keep my assumptions to a minimum. For example, a player could theoretically shoot another player, enemies could wander through coins without picking them up, and targets coul have more health.

Nevertheless, here were some assumptions I made:
* Hit FX should be configured by Damageable, not by Projectile. This was mostly for the purposes of making Targets unique in having hit FX. But it's very possible a designer would want the FX to vary by projectile.
* The player inventory should not persist on (hypothetical) player death: The Character object has the Inventory, meaning that if it were destroyed, so would the Inventory. For persistence, the Inventory would need to be moved or saved pre-death and restored.
* ^same as above, but with weapons.
* Different weapons can use the same projectile but deal different damage etc. If designers want projectiles to be consistent in the damage they do (and/or other factors, like speed) across weapons, then the relevant config should be moved from Weapon to Projectile