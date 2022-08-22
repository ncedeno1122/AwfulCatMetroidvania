Oh boy, today's the day! Continuing from [[August 21st]], I got some good work done last night. I'm so EXCITED! I have so much cool stuff to make and test. I just have to think about how I want to implement it so far. There'll always be room for refactoring, as I'll soon learn as I detach basic attacks from Achik's current fire projectile scripts and all that.

---

First things first, I want to specify what it is I'm going to do today. Firstly, I want to get the Attiniy meter and UI up today. That'd be great.
	To do this, I need to think about how I want my resource. In the name of component-based fun times, why not make a component for it so I can decouple it from the PlayerController script?
	By the way, I KNEW I'd have to make some sort of AchikController. It's something only he needs. As such, I'd have a reference to it there.

In any case, I need some sort of component to actually store the Attiniy resource. Might it be a lot of scripts? Sure! But are they useful component scripts? Ohhh, you'd better BELIEVE it.

---

I've started with the AttiniyController script, and I want it to have a Slider. BUT, this violates the SRP to some degree in working with UI, so I'll make a seperate little script to reference for the actual Slider and UI.
Born is the  AttiniyUIController.

Aaaaand we're done, that was quick and fairly painless. What's better, I can actually try and decrease the cost of things now!
