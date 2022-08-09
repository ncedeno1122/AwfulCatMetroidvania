Ahhh, August... :D (Continuing from [[July 31st]]). I can't wait for the weather to get colder soon, I miss the chill.
In any case, I woke up so excited to get some work done today, and I'm very eager to try today.

---

Right off the bat, I stare into my project and realize the most SILLY, lower-priority refactoring I can muster, lol. But I was thinking, I use so many properties from within my PlayerStates that I have right now with my AchikStates. I'm constantly accessing the Animator and running all this and all that. Would it be better to simply create a function that wraps this functionality (like m_Context.Animator.SetBool(..., ...))? It'd be faster I think? Faster to write, anyways. I have to do more research into code optimization.

In any case, I wanted to pick up where I left off. A decent bit of this was retuning a bit of my physics and detecting when I'm grounded and all that. I'm so concerned with performance but I can't preoptimize, in the words of too many Stack Overflow gurus. In any case, I don't care UNLESS I make some sort of wall jump script or something like that. Any addition or ability should be done in a separate script as a component. This is the way.

What's more, I want to make the Achik Spirit Form ability today. Here's the work I need to do because I just learned how to do this:
- [x] Make Sprite for Achik's spirit form
- [x] Make GameObject or Component for his Spirit Form?
- [x] Get it working

There's just some things I need to organize first. Like, I need to keep the main Player GameObject active as I switch the state and all that stuff. Perhaps I only need to override the SpriteRenderer's sprite temporarily. I'll need to do something with the Animator so I don't have any changing sprites or something...

There's a bit of a compromise that I have to make in choosing how I want things to be. I can handle a lot more front-end, flexible stuff UNRELATED to the states by having a Component script. This is better, in my opinion, I like this. I was feeling weird about having another script change the state of my state machine.

As I prepare this Component script first, I realize that an interface for this might be nice? I'll try to get this working first, then pull features up like that though.
My next debacle is, for timing the time we spend in the state - Coroutines or Update Loop? I'll try a Coroutine for this.

GEEZ just forgot too that I'll need to change the size of my collider I believe... Hmm, perhaps there might be a better way to do that? I can do it in realtime, but I worry about the physics interactions that result from that... But until it's a major problem, I'll proceed!

DUDE I'm so interested in making more generic / general-use systems. Like my PlayerController, I just want to be able to set the right states but still have sufficient abstraction to succeed. In this vein, I might try to use a UnityEvent, kind of in the place of a delegate that I can use in the Editor. It's cool that the PlayerController needs only to mind its own business LOL. Eventually, I can just hook up the proper behavior through UnityEvents with different components, or BETTER, through a delegate or something a little faster based on ScriptableObject data?. It's something anyone can use easily, which makes it attractive to me. In any case,  UnityEvent it is.

#### Factory Pattern for proper State Initialization w/ ScriptableObjects?
One thing I can do for this is to use the Factory pattern to get states from strings, that way when I create data for each character in a ScriptableObject, I can start them out on the right state while using a more abstract PlayerController according to their data.

Talking about building things from ScriptableObjects, I could use the Factory Pattern to initialize data pertaining to different abilities that each character has and all that, JUST like I do to initialize their proper state.

---

Right, so I've gotten the state working programmatically. Now to hook it up in the Animator.

Notes rq: Offset = 0, 0 |  Size =  0.3, 0.35 for spirit form.

There are already some collision bugs happening. Firstly, on any colliding surface, if I hold down as we EXIT the spirit form state, we clip through the ground. We DONT do this for ceilings though. I think this might be because of the gravity force being applied, the collider resizing from the top down (which might not make sense), or a combination of the two

I could hotfix this by raycasting downwards to see if before we deactivate if we can place ourselves properly. To ensure proper behavior on ramps, I should raycast downwards from both edges (at the x position of the x variables).
I could ALSO try lerping the values to reduce some of these errors instead of SNAPPING from one size to another.

The raycast approach seems like the right option, but let me post this commit first.

--- 

And my math worked! It's functional, but it could use some touchups and likely some more debugging down the pipeline as I make more. In any case, MISSION ACCOMPLISHED for now!

Could it use polish? Absolutely. Specifically, some particle effects, maybe a trail renderer with a neat material and a light or something. The transition could absolutely use something FAR BETTER than instantaneously doing it. Some visual feedback would be nice but not too much for too long. 

There's another bug I noticed with the breakable blocks, which is when I break one and it respawns over me when I'm still in spirit form, and then I need to try to position myself about.

If this happens and I can't compute a solution, I want to try and just return the player to the position they started the spirit form in. That'd be the simplest choice for sure. But detecting this would be more difficult. It'd involve something like doing an OverlapBox or something like that for the size and shape of our collider, and then deciding what we do based on that. There should be some target height that we can accomodate in in-game units.

This check could help determine our collision and the appropriate response for it and everything like that. OR I could make it so that if we CAN'T respawn validly, we start to lose heallth or something like that? But that's for later when I actually implement health, not to mention that I still will have to detect collision more thoroughly.

In the meantime, I have some coaching to do, but I've done good work today. If I don't get back to this today, I will tomorrow. What a great day I've had, I feel blessed!