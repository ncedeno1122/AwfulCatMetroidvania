Continuing STRONG from [[July 13th]]

BOOM so I'm just DYING to continue today. I have to see about what I'm going to do.
So there are really two schools of thought here in my mind. I either have **GameObjects that live directly on/within the Tilemap as RuleTile prefabs** OR have **GameObjects that live "OFF" the tilemap but maintain a valid Tilemap position**. The latter approach is more flexible, but irks me because it's happening outside of the Tilemap system... It just freaks me out.

I was thinking about other things as well. What about a system where I only load / maintain an active room? That'd be really cool, but I watched a video that went over the shortcomings of Unity's Tile System and the object pooling I would LOVE to implement for that approach sort of goes out the window. *sigh*.
With the active room system, it'd be cool to create a tool where I can draw the map for an area and properly load certain rooms, spawn locations, and other things. That'd be really nice to have a data model from which to load areas and things like that, I have to admit. This is a scalable, cool solution.

---

By the way, I think I'm going to try and go with GameObjects that live off the Tilemap for my Interactable Tiles and things that go with them (like doors, stuff like that. Having more editor control over them is really nice, and I can eventually serialize their connections and things like that which would be awesome).

SO that's the direction I'm going with, and I'll try not to look back too hard, lol. I feel like I'm giving up, but I don't know a very workflow-friendly way to do what I was trying before.
	Thinking about it, I was banking on pre-defined data in some aspect about what triggers what, what listens to what, all that stuff. If I were to maintain a list of listeners for specific events published from Tiles at certain positions, I'd be fine to proceed with these "anonymous" InteractableTiles. But, I must concede for now.

In any case, I was really already doing this when I think about it. In making instanced prefabs on RuleTiles, they were already living on top of the Tilemap but not really on it... I guess I shouldn't feel too bad about the fact that I can't place them on it. Oh well.

---

Let's try and work on the first class for these fellas. I think I might still be able to 