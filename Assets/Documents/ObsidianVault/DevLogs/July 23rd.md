I'm ***BACK*** (from [[July 19th]]) and I'm trying to work some more.  I'd been thinking so much about abilities and things like that, but I was still so weirdly worried about implementing them. Now, I think I just want to go for it and see what sticks. It's courage time, baby! Let's see what we've got.

---

First things first, my workflow will be a little different for the next week or so, I've been housesitting by myself with my dog, working around his schedule mostly. It's been fun and has offered me some great focus time, but some of my work time has been cut out by my need to make food and take care of Max. He's pretty awesome!

In any case though, I have to see how I would implement something like my abilities. Specifically, I wanted to make a system for my different characters and things like that. Preferably, I'd have a \_\_\_-controller for each character from which I can call other component-like scripts and all that stuff...  But I don't know...

My main thing right now is some movement abilities I'd like to implement. The problem is, they would VERY LIKELY conflict with the PlayerController script that I already have, you know? Like, I can't have two scripts moving my GameObject (obviously), but I'm unsurprisingly trying to find the best way I'm aware of forwards.

That way that I see is possibly by implementing a State pattern for my PlayerController depending on the movement abilities. Essentially, I'd have my PlayerController class which would be my context, holding my input and the current state we're in. The current physics-based state that I've made in PlayerController (which needed revisiting and rewriting ANYWAY) would be implemented in the State and all that stuff.

For Achik, I have this ability in mind, a Spirit Form, where you can transform into a floating orb of spirit energy and can fly for a certain few seconds or for a certain distance. Time might work better for that. **The main thing though** is that this will control differently than the normal player, we won't obey gravity and will generally control uniquely. This seems to shout to me for a state-focused approach.

There's more utility in states for me though. I want to make sure it's performant and actually good, and I worry... But I ALWAYS worry, so I should proceed if I'm just going to worry about it either way. Let's do some refactoring then, shall we?

---

Looking at my PlayerController class, it certainly DOES control the player LOL. It comes off to me as one of those early monoliths in the making. I ask myself now, is this necessary? Could I just decouple some of the functions from this class as a Component (as I did elsewhere with my Interactable and Breakable tile classes)?

To that I proudly say yes. It may cost more data-wise, potentially, but I think the approach is worth it.