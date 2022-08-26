Continuing from [[August 23rd]]. I didn't get to finish my thoughts because my days have been busy this week in transition from my vacation to school. In any case, I've just been... so happy with these abilities I've come up with. It's exciting me and motivating me in a million ways, I start to think of a million fun things to add every time I think about it... Ahh, this is nice.

In any case, I have to still get my AchikController all done, but I'm thinking so much about my ScriptableObject `CharacterProfile`. That's where I could do a lot of the tuning for values that make the character feel unique (different running speeds, floatiness, etc.). It excites me, but I have to complete what I started the other day.

---

Last time, I was trying to work out how to store a character's data - their skills, physics, important features, etc. in a decent way. The approach I had in mind was to devise some storage method for skills and some language around that. The only PROBLEM is making a decent little workflow to actually get it done.

The problem I was having was in my ISkill interface not being an abstract base class. Because the interface type isn't serializable, I like being able to use the Inspector and Unity UI to hook things up (if my hangups with UnityEvents wasn't enough).
So then I was thinking, oh nuts I don't even want to do that. What I WANT to be able to do is define WHAT makes a character without hardcoding it in so I could make a structure I could reuse when the time comes to make Kowi. What I might LIKE is some system where I can specify all the Skill components, attach them to the GameObject, and have them hook up to the proper inputs and all that.

You know what, I'll tell you what. I think I figured it out... Maybe in my character PROFILE, I'll define the SPECIFIC data that I need (component scripts) and the specific inputs I'm listening for to activate one of the abilities. The thing is, as a ScriptableObject, I'll only reference scripts that NEED to be on the GameObject already...

It sounds dumb, but I'm in the ballpark I think. What I want at the end of the day is some way to pass inputs into a system that will quickly look up if there's an attached Skill, and then execute its behavior. That's all I really want to do.

To achieve this, I tried to make an enumeration to describe the input type, but I would need TWO to describe cardinal MOTION and the type of input I got (single/double tap, etc), and I would need to **understand that that is simply the type of input that I'd be listening to to start/actuate/activate the Skill** that way I cover my bases in terms of holding an input, which would be handled in the state entered by activating the state with the single input.

---

I think that might be a semantic but potentially necessary layer if I want to KEEP my PlayerController concrete (and the only script of its type). It's essentially an implementation of the TypeObject pattern which I see now. In that VEIN, I could try and create a class to manage this data instead... Hmm.... The class might be better than a ScriptableObject because I'm not really changing the data or references or not, they're non-dynamic. What IS dynamic, however, is the player's progression and when we can use those abilities and all that.

So, in the name of reusability and all that, I think this might be the approach I go with. I still want to keep my interfaces (and probably my Skill abstract class lol) so that I can serialize my reference and all that to certain components. In essence, this component would unite all of my other components in the way that I might've had my AchikController class do, but in a bit more of a decoupled and organized way. This would be the big guy whom I REALLY care about holding data and references and all that stuff in. It would also be the coffee filter that only allows proper skills to be activated depending on certain inputs.

---

