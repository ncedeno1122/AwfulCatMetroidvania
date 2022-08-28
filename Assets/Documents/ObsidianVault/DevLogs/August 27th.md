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

---

## Music Work Today
I guess I keep forgetting that I can be writing these devlogs about music as well. So, I shall! I was experimenting with a little something for Kowi's theme, and I sort of liked it! I have more work to do in terms of researching a good Mayan/Aztec-ish sound and how to implement that in the soundscape, but I like the melody I had so far.

In terms of music work, I've still been ideating with a few tracks I've actually liked. I'm testing out the waters in terms of how synthy I want the sound when I'm working with both virtual instruments AND recording my own playing. It's been interesting, but I'm getting more to the heart of it now. For the concrete world / Kay Pacha (still speaking in terms of Pachas / realms), I want to have concrete / real instruments MORE than synths. In either surrounding over/underworlds, I could use more synths and things.

That SAID, in a lot of Aztec and Mayan mythology, there are many layers to both the heavens/overworld and the underworlds. Depending on the layers (which works well with a Metroidvania format :D), I could have varying sounds and all that.

The tracks I should focus on most are:
- A track for the village that Achik comes from (Achpakatambo right now)
- A track for the temple of the sun in that village (TempleOfSun right now)
- A track for the first dungeon / area you teleport to in the overworld
- A track for the Capitol

The main thing about getting the underworld settled with-

#### Merging Cultures with FishingGame
OOOOH OOH OOH another thing I've been thinking about is STOPPING BEATING AROUND THE BUSH AND ACTUALLY JUST MAKING THIS THE SAME SOCIETIES AS IN MY 3D FISHING GAME. There's not much of a significant difference at this point, they're all cats, and there are two I have in mind taking inspiration from the Inca (Mi'cha) and the Maya (Paal'Ujo).
So now, Achik is a part of the Mi'cha peoples and Kowi is of the Paal'Ujo. Boom baby.
Merging the cultures is more than this though, I also get to merge the WILDLIFE of the areas too! That means, in the underworlds that have Hanan Pacha (earthlike) qualities, I can put water and rivers and MOONLIGHT JELLIES like I have from my fishing game!!! ooga booga me like continuity :)

I was to say, anyway, that I should probably get the pantheon of gods and whatever more settled so I can declare what "levels" of the underworld certain gods rule over or whatever, and what other areas there are in there. Especially, though, **what branches / paths connect them all**. That'll come with level design though. 

---

In any case though, oh BOY am I excited to keep working on this game. It just fills me with so much energy when I have cool concepts that come to light and all that. How fun!!

I want to head the the buffet sometime soon because my stomach is grumbling, but if I come back, I want to try and work on the next Skill of my choice. In my list [[Achik#^8ec086]], I might do something like the Prayer / Bless next with a Hold interaction. That way I can finally discern between the two in ACTUALITY.
