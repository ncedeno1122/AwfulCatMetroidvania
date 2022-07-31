I'm continuing on work from [[July 23rd]]. I've been thinking about where to put my time, especially as the tracks begin to shift (in a month) over to school mode, where I'd like to also have a part time job. The main thing is securing income, but I'd like to have it in a job that I practice my career skills in. Getting any easy part time job is fun but might not be engaging, and *I want to care* which is the problem. Perhaps I'm over-owning. In any case, this project may see a decrease in work next month as I settle things. It *may*, but that has yet to be seen. In the meantime, I want to continue to work things out and figure stuff out, and that HAS to be abilities!

I think it would be productive to target two or three hours of work every day on this project at least so I can get a playable demo out sometime! I'm having deja vu writing this for the first time in forever, perhaps this was meant to be!

---

At least, abilities are the most intuitive way forward I see. The main thing is, I've never made anything like that so far. So I have to get one type of ability down, then reassess, refactor, and repurpose my work.

So what even *is* an Ability? Well, I should make the distinction between passive abilities and skills.  The difference between a passive and a skill is that a skill needs input for its effect to activate, unlike a passive whose skill is always executed (hence, passively). I suppose that a skill qualifies as both a Movement and Technique ability, so I should think more in terms of what each skill actually does...

Generally, there's a time when a skilll is active, and a time when it's not. The effect of the ability is what happens in between. This actually could be neat to figure out, lol............. because if I was to make enough UnityEvents that call functions like StartSkill() for different Skill scripts, for different situations the player runs into, I could really get this system off the ground so far.

Again, I think that might be my solution thus far, or at least an early one. The next question is more about housekeeping - what about the state machine that controls the player controls? I'll have to define custom states for the skills that are meant to accommodate for them and all that stuff.

There's a couple of things that I've learned that I might need to do. For instance, create a method called AdvanceStateFromAnimation that I use for that exact purpose LOL. That way we can have our custom SkillState take as long as it needs to before we advance it from the animation or something like that.
If I'm swinging a Collider around or something like that it might be important to make sure EVERYTHING is in order as I Enter() and Exit() the state.

**SO just to review for later, since I feel like I don't want to R&D too hard tonight (tomorrow morning though), here's what I've decided:
* Create a custom state that is just for Skills that use animation
* For the Skills animations, do the animation that I need (maybe move colliders, fun stuff), but `AdvanceStateFromAnimation()` function is good too.

I'll keep this in mind as I do my work tomorrow. Here's to then!

---

