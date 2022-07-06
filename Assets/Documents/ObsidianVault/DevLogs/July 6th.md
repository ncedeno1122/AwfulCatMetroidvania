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

But other Tiles that might be cool to have are like switches and things that we can Interact with.. Those tiles might follow a different behavior.

AHA! I think I've gotten it! What we might be missing here are interfaces! What if I wanted to mix and match some of the Tile properties later on? This might not be the BEST idea or something though, so I should probably just not do that...

How's about this though? I can add a field to my `BreakableTile` script that is for the tags we want to break for, and set that elsewhere...  But that's something I'd want to pull up or make abstract for subclasses...

GAH, I'm overthinking this now. I'm just going to copy and paste and do my thing. I'm being foolish. There are solutions, but I can't predict the future. Let's get it in ther and see what needs to be done.

---

What I think could be a good approach is to have this `BreakableTile` class describe some generic behavior that all `BreakableTiles` have, but have some other class actually listen for collision and handle stuff for specific implementations of that stuff. Essentially, having the BreakableTile class as a utility script on the GameObject or a module for handling that common behavior. I'm not quite sure though... There is a LOT of duplication with the "new" FallThroughTile code. All that's really different is the method in which we activate the trigger the whole song and dance with the block disappearing and reappearing.

Ok, I've gotten it working now. Fairly easy, as expected. However, I'm still not over the duplication. They say if it ain't broke don't fix it, but I'm not sure. The problem is that it's all a design-level thing. I don't know exactly how many LevelTiles I want to implement, or their shared properties or anything. Because I've winged it in that aspect, I odn't know how to design my system. It's a decent system as it is, but not an elegant one. I should hash that out next.