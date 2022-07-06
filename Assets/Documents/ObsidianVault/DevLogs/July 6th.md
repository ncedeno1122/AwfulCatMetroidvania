Oh boy, I wonder what kind of cool special LevelTile I'll work on now :D.

I'm satisfied as it stands so far with the breakable blocks, I'm a fan. But what's next? Perhaps we can try for the fall-through blocks today. This should be a fairly simple implementation, let's give it a try.

But NOT before I reread my code from yesterday. I want to get into that habit for small things that I 'complete' so I can look for refactoring. I should ALWAYS do this for most of my code, and I do, but I haven't yet figured out a scheduling system to refactor that works for me yet.

Right now, I'm thinking about if the TypeObject pattern might be something that works for my LevelTiles... I'm not sure at the moment. The scripts I have right now, the abstract `LevelTileGOScript` and the concrete `BreakableTile`  are fairly useful. The concrete subclasses of `LevelTileGOScript` inherit events and some abstract TriggerTileEffect() method.

I wonder this sort of thing because there's going to be some duplication with my BreakableTile and my FallThroughTile. It's essentially that my BreakableTile breaks for Projectile-tagged objects (currently) and my FallThroughTile will break for Player-tagged objects. Their behavior is, as far as I see now, identical in that sense.

But I'm not sure that I want to introduce ANOTHER level of inheritance if I don't *have* to...

It's unfortunately clear that I've not thought too much about the design that goes into the current LevelTile architecture that I'm pursuing. I don't want to HAVE to do this, but I will... If I must...

Let's look at this, though. The entire functionality of the tile is the same, except for the fact that the tags it listens for differs...

---
### On having images / animations for the LevelTiles
I might want to do this, except for the fact that the animations are very simple and I may not want to use the Animator for EVERY single tile that I do. That said, I might have to do it the old fashioned way.

I could use a ScriptableObject to store an Array of sprites for the tile, and manually animate the tile's animation in a coroutine. This has a flyweight sort of feel about it that's pretty relevant, so I should remember this.

---

The QUESTION is, what behavior will ALL LevelTiles have? What behavior will go into `LevelTileGOScript`? Not a lot, but rather some generic behavior that we can all share, like TriggerTileEffect and inheriting events and fun stuff like that. That means I *shouldn't* pull up my Breakable Tile functions into the `LevelTileGOScript`. Would this sort of Breakable Tile functionality work as a superclass? Yes! The issue is, I want to avoid duplication like the plague. There *has* to be a better way, right (COPIUM)?

Ahhh, but wait! As it is right now, I don't listen for trigger collision to start my events within my BreakableTile script, it happens in my Projectile... I was deliberating over whether this was the right move when I made that decision too.
If I were to change that, then that aligns with my idea of the script right now.

ATTENTION, ATTENTION! A VIOLATION OF THE SINGLE RESPONSIBILITY PRINCIPLE HAS BEEN SPOTTED! ***neutralize the threat.***

---

Thinking as well about my `LevelTileGOScript`, it's really more of a class that could be static if it wanted to... The events are static, which is cool with ensuring there are only ONE of them that ever exist...

But other Tiles that might be cool to have are like switches and things that we can Interact with..