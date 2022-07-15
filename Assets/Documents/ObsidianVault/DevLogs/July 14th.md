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

Let's try and work on the first class for these fellas. In my InteractableTile class, I've added an OnValidate and OnTransformParentChanged so that they align to the Tilemap when the scripts are reloaded.

Now, let's take a look at how I want to implement the actual events side of all this mess.

My prior problem before was that I wanted to use C# events for my InteractableTile's way of messaging its listeners, but I didn't have any way of knowing information about who actually SENT that event without predefining who we're talking about.

Now that I have the ability to use UnityEvents and customize who I'm even making a listener, it's really tempting to use this approach. But, I still have to see how I'd use something like this.

There *is* what I recall of the Observer Pattern, where we have a maintained list of listeners whom we have being some sort of listener with an On-whatever method we can invoke.
At present, this seems to be the best approach, as I STILL would like to have some decency with how I handle these events. Yes, I COULD just have a UnityEvent defined in the scene with some references and behavior we hook up. But is that serializable? I don't know. Is that something that we can change and hook up at runtime, is that really reliable? I don't know! But what I do know is, this synchronous Observer Pattern might be a good idea here.

The point is, I want to avoid this problem of not knowing who published the event and therefore not having a way to verify and approve the event. I'm going to do this in a list of Observers that I maintain from the InteractableTile. SHOULD be EZ.

So that worked so far, but it seems like something that could be expanded upon.

---

Specifically, I need to get my Nontoggle/Toggle Listeners working. I'll have to see how I do this. I might just have to pull the OnNotify methods and Observer Lists down into a NontoggleListener and ToggleListener and all that.

I'll try that, I don't know. Why not? When I'm refactoring and I see a redundancy, I'll get rid of it. Let's try it!

I have to see if eventually I will make a distinction / union between my toggle and nontoggle interactable tiles via an interface or something...

I'm stuck in a weird funny world where I... am an idiot. I know what's wrong. Loll....

I DON'T need to send the toggle status in the OnNotify method that I'll use for both Nontoggle and ToggleObservers, I'll just pull that from the sender object I send as an argument.

RIGHT, I'm good now I think. Let's test for some toggle and nontoggle listeners and all that fun stuff.

Aw NOOOO, I forgot about how I can't display a list of interface fields in the  editor, rrrRRARgh. This disappoints me. Well, I'll just make it an abstract class. Shame though, I'd love for that to have worked.

---

