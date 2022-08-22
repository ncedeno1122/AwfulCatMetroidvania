Ahhh, what a fruitful vacation. I do believe I left on [[August 14th]] and came back earlier today. I feel so rejuvenated after exploring a bit of Canada and looking away from my projects for a bit. What's more though, I've just been... really happy with my learning lately? I've been taking care of business in terms of organizing my duties so that I'm spending a lot of time around code in a productive way. It's been helping me learn so much, I feel accomplished somewhat.

Tonight, I might not do super significant work, but I do want to ponder more on last note's abilities chart and things like that. It would be best to move that to some separate section / folder so I can simply refer to it in the same place and all that stuff, outside of a daily devlog.

---

When the time comes to start designing my maps and areas and things like that, I need to have my abilities worked out before I make any official map. I really have to pay attention with all the things I *want* to be able to do in this game world. If I know how I want to interact with the world, I'll be fine. Currently though, I don't know how I want to do this in sufficient detail, so it's still too early for me to know what I want to do and all that.

I'm feeling a BIG planning document coming along involving the variety of ways I want to work with the world and all that. By the way, I've been thinking... Are my current Tile dimensions too big, I wonder?
Sometimes I feel like it, but then I remember that I can be spriting things in the 32x32 size but not making FULL use of the space. The colliders I have on the PhysEnviro tile are flexible in their sizing and all that. When the time comes to do a lot of art and drawing tiles, I'll have to remember this.

In any case, let me try some reorganizing. I'll link the note that I work more in here.

---

So I'm working on the [[Achik]] file and MAN, there's some interesting stuff resurfacing. DO I use some sort of consumable / resource-based limitation on Achik's resources?
	For Kowi, something like this makes sense. If you use a blowgun, you'll consume a dart. If you have no darts when you try to fire the blowgun, you can't do it; you have to find an enemy who'll drop a dart item which'll give you some darts or something.
But for Achik, I think a resource meter makes more sense. The reason I thought of a magic resource meter at ALL was to place an easy and understandable limit on Achik's spells WITHOUT writing a million conditions to pinpoint the controlled circumstance in which you can do something. In normal people speak, I don't want Achik to be a highly technical character because magic is supposed to make his life easier and supplement his physicality. That doesn't mean he SUCKS, it just means that he relies on magic to do things efficiently.

The main constraint with a resource meter is calculating the skill costs first and foremost, but secondly finding out how the meter will regenerate (and what costs magic).

Here's a thought: **What if Achik's current Blessing move regenerated mana as a STATE?** What if even shooting the basic projectiles requires a certain amount of mana?

Ahhhh, I'm beginning to like this. I think that this makes sense!!

So here's what I'm thinking. EVERYTHING Achik does that is magical in nature should consume the magic resource. As such, just about everything he can do that's not physical will consume mana.

***THIS GIVES A PURPOSE TO THE KNIFE AS A MELEE WEAPON*** that Achik can use because he's a priest. It'll be his basic attack instead of what is currently his solar projectile. THAT will consume magic eventually.

[FYI I'm working in both this and the Achik file in The World> Characters> Achik, they're both best understood together]

#### What Will Restore Attiniy?
Attiniy should be restored ONLY while in the Praying state (adapted from the blessing state), and a slight amount refreshing after vanquishing an enemy.
To Pray, we MUST be grounded. I'm declaring this so that we can't pray mid-air and infinitely Spirit Form or use other abilities in a less-fair context. HOWEVER, I shouldn't sweat that TOO MUCH unless it's gamebreaking. **After all, this would promote nonlinear design and exploration, which would make sense.**
How about this?

Attiniy is restored primarily through the Prayer ability, but slightly *by damaging foes*. This might create for some more fun and dynamic fights / rooms. Achik's platforming might not be nearly as fun as I think Kowi's will be, but we can supplement that lack of technical challenge by making it so you can hit enemies enough (precisely enough) to EARN new areas in the game and all that (at least to explore insofar as the player can at that point UwU).

---

DUDE Attiniy is the future... I really like this idea. Like I'd said, it makes sense but I just hadn't realized how MUCH sense yet. As it turns out, this could be a really crucial part of Achik's kit that seems to make sense and promotes different ways to play him.

As well, I need to think about how I want to handle inputs again. Currently I have different inputs for my main things, but Metroid uses only one button to do things. It makes sense for such a scheme to exist here, potentially. But maybe not.

It WOULD make sense were I to make some sort of menu to select what mode you would be using (Spells vs Physical, Weapons vs Physical and all that).

My main thing about THAT would be not making good enough use of the rest of the buttons on the controller (potentially)... As well as that that seems somehow redundant.
Perhaps the distinction between Skills and Basic attacks should remain so in my project so far.

---

In any case, Attiniy seems to be a good system so far. I can map out its limitations and design rooms with it in mind. For Kowi, it'd be fun to give her platforming-heavy rooms and things like that, but Achik might not benefit as much from those. In the event he needs to, I can design and map out a room where he can platform too. I can also MEASURE how much Attiniy abilities consume and use that to create my rooms as well.

#### Throwing Primary Weapons?
What if I had an ability where I could THROW Achik's knife in a direction (costing no Attiniy), but pull it back with Attiniy? And otherwise, I'd have to go pick it up? It might be fun, but it doesn't sound like something Achik might do compared to Kowi.

---

In any case, I'll iterate on these ideas again soon, likely tomorrow. I'm excited, this Attiniy resource really helps me limit my scope and work around the idea.

So from some of my work in [[Achik]], I've decided that **there are two move inputs, one for Basic attacks and the other for Skills**, and I've decided on the limited moveset that Achik will have with such an action. I think I want to have Achik able to toss his knife to add more relevance to it as a real tool of Achik's and not JUST his fallback. It's important to his duties! Other spells can be more generic bomb-like detonation things, projectiles, blasts, hitscan abilities, and other fun stuff. But not so much weapons outside of his knife.

I've decided on making the Knife Throw and Pull Back Knife skills real and all for Achik, which should be fun. It may be physical, but I can't shy away from *enhancing Achik's physicality through his magic/Attiniy*, which I had said earlier. This ability seems to do this well and in an understated manner.

I might make the downwards stab move as well.

Y'know I hadn't considered that this knife throw mechanic, which I intend to be free-aim, would put my current firing system in jeopardy. However, since I planned to "uproot" it anyways, this is a good thing.
	First things first it would be useful to make a component that helps specify a direction based on the stick input of where exactly we're going to aim and provide a Vector2 of that angle (and draw a graphic for the specified direction).
	Secondly, I'd need to create states for the free-aiming mode and find a way to choose what I want to shoot. Could I do it as a SingleTap versus DoubleTap input? Sure! Would it be more friendly to have that on a shoulder button (right for energy ball, left for knife)? Maybe also!

OKAY, so I think I figured out a decent scheme for things for now. I'd moved the Bless and Spirit Form skills to an Up input since I didn't use that MUCH so far. I instead have the Horizontal / Any skills like the Knife Throw and Energy Ball separated by different inputs currently (Single versus Double) **WHILE a FreeAim mode is active.**

Honestly  I think this is the way going forwards, and what I'm really looking forwards to implementing next.

---

I'm thinking of fun stuff to do before I head to bed. Maybe evaporating water? Growing crops? Setting things on fire? Blinding enemies?

I still also need more abilities for the Up/Down directions potentially, introducing the FreeAiming system kinda messed with that so far. I have to think more about what other abilities I might want to introduce that's in line with Achik's character. I want to think about, again, how to interact with the environment and I have some neat abilities already that could do things.
For instance, I could copy right out of God of War's book with the knife throwing abilities and all that. What's more, I could destroy blocks that could melt or burn wtih the Solar Beam ability I just wrote up.

#### Abilities That Depend On the Knife's State?
**I could make abilities DEPENDENT on Achik's knife as well!!** That'd be really cool if he used it as a catalyst for things. If the knife was OUT, he couldn't use certain abilities and what not. Certainly food for thought. 

