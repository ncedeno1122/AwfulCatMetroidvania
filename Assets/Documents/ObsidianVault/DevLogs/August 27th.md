Continuing from [[August 26th]]! Ahhh, that was a great dev session yesterday. And I plan to do a little teensy weensy bit more today.

I left off last note having restructured a lot of the Skill input system. I may end up doing something like this for the basic attacks, but we'll see... It's not *exactly* the same thing as a Skill component which can be decoupled from the character. The basic attacks in principle *could* be this way, but I think it's just something that'd make use of some Animation state that has a function that advances the state from within the animation and all that goodness.

Before that, last time I had left off without making a few neat changes about how the Skill States will work with the Components. I need two things.
	First, I need to make a boolean about whether or not the skill component is complete or not (whether or not it's okay to switch to another state).
	Secondly, I *should* pass in the script of the component in the constructor for the skill state that makes use of it.

At least that's just what I think initially. I would love for there to be some way for me to directly message a state that it's okay to advance to another one, but I *guess* I could do something like this from within the Skill Component script like I am now...

I'm getting it now. I think I could make an interface that provides a specific type describing Skill States that has some method or boolean property that describes whether the current Component is finished with its things yet. Essentially, I'll have it so that the Skill Component script will lock whether or not the Skill State can be transitioned from or not.
The only issue I'm having is abstract classes or interfaces... I think because I want to have a fun constructor, I can inherit one from a superclass to more closely relate these Skill States.

All in all, it looks like I'll make a SkillState abstract class that has a constructor taking in a Skill/ISkill type. Then I'll have an override for this in the actual concrete Skill states where I take in a more specific type.

---

Okay, at present, I just got this... Skill State Conditional Transitioning working! Currently, the states cannot be interrupted until THEY say they're done (which they know by getting whether the actual COMPONENT is done via the IsComplete script :D).

Is this the best approach? Probably not. Irrespective of that, ***RRAAAAAAAA***, I rock at this sometimes (and not always). I'm glad that's worked out. If I think I need to revisit or cut this in the future, I know I can figure out that too.

I also said I wanted to work on some music today or for now. I'll commit this work for now and then work on some music.