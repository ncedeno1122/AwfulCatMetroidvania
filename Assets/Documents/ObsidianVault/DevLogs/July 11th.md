Last: [[July 7th]]
I don't know why, but I'm feeling like I'm having trouble deciding what I want to work on after this short "break" I've been on as I recover a bit. There's just so many cool things I want to do!

For example, I really want to try and implement a few things with interactable tiles. I want to get some sort of workflow with them going. For example, I really want to implement a flyweight approach via ScriptableObjects to "animate" my InteractableTile sprites. For my toggle / lever sprite that I made, I'd want to represent the state somehow with that!
I'd want to animate the nontoggle / button sprite that I have!

More over, I want to have the tile EFFECTS work, and hook them up so that the events I implemented roughly actually work. I want there to be SOME way to target certain tiles that's easy to place in the editor. That's a decent constraint, and I'm not sure how I would want to hook something like this up just yet. That's my main endgoal with this interactable tiles system. I must calm my mind though, I have to cross this bridge when I get there.

For now, I have to figure out some editor workflow that works as to how to place interactable tiles of different functionality, that will include what they are and account for different sprites. Maybe buttons look a little different every now and then? With how I have my editor right now, I'd be locked into having a concrete tile texture, but the LevelTileGO on that tile would have no sprite...

---

There's a solution here. I make some tile sprites that CLEARLY indicate what the LevelTiles' types for the RuleTiles in the editor. The LevelTileGO will have the actual sprite I want (maybe given a theme or something?).
The point is for animation and unique sprites to occur in the LevelTileGO rather than the tile.

To continue with this idea, I'm going to draft some sprites, some generic tile images that describe their functionality. Visual communication is key here even though nobody will be able to see this but map editors like me.

...And done, my first batch isn't bad imo.

---

Now, let's continue. I have to have the sprites that I want within some sort of organizational structure (for my sanity...). I'll need to pull these and draw these on the LevelTileGOs so they properly represent this.

This may be where ScriptableObjects come into play... I know that I'll need to keep track of room/map specific things like art and other fun stuff. Buhhhh this is what I get for not designing a GDD for this project so far. I suppose it isn't too late considering I'm working on very surface-level details and mechanics right now, but I'm peering into a hole of technicality like how I want to interact with my map/loading rooms and things like that that I previously hadn't needed to have considered. 