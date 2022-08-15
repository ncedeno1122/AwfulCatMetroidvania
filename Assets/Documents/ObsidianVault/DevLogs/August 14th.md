Continuing from [[August 11th]]. This upcoming week I'll be in Canada on vacation with my family. It'll be very fun and very nice, so I'm excited. As well, I think I aced that job interview and I hear back Tuesday for it. With all that said though, I'll have some time away from this project this week. Even though I don't make a devlog file like this for EVERY little ideation session I have for this game, or for every asset, I still work very constantly on this.
For example, yesterday, I recorded and arranged a little track called "Achpakatambo" which I liked a lot. I made a commit for it and all that. In any case, I probably won't have a lot of time to work on the project today, but I wanted to potentially ideate on some of the ideas I jotted down for abilities and things in the last commit ([[August 11th#^9954bb]]).

I'm really struggling with the markdown tables, I think they suck, and the HTML tables don't draw as prettily as the markdown ones, so I'm going to use some table generator instead of this code:

<table>

	<tr>
		<th>| Directional Input |</th>
		<th> Grounded? |</th>
		<th> InputType |</th>
		<th> Skill Name |</th> 
	</tr>
	
	<tr> <!-- Bless -->
		<td>  Neutral </td>
		<td>  G </td>
		<td>  SingleTap </td>
		<td><em>  Bless </em></td>
	</tr>
	
	<tr> <!-- Spirit Form Ground -->
		<td>  Down </td>
		<td>  G </td>
		<td>  DblTap </td>
		<td><em>  Spirit Form </em></td>
	</tr>
	
	<tr> <!-- Spirit Form Aerial -->
		<td>  Down </td>
		<td>  A </td>
		<td>  DblTap </td>
		<td><em>  Spirit Form </em></td>
	</tr>
</table>

---

## Achik's Abilities Table
Here's what I was thinking for Achik's ability slots so far. As a character, I want Achik to be much floatier, much more magical and priestly than Kowi who'll be all about the physicality and weapons like that. However, there should be some rare melee abilities here and there that are more about precision or something (since an Incan priest irl might not have the full armory on them).

We need moves that use the directions more. Spirit form and Bless are both directionally neutral.

I'll update this table:

| **Directional Input** | **Grounded? (G/A)** | **InputType** | _SkillName_ | **Description** |
|---|---|---|---|---|
| Neutral | G | SingleTap | **_Bless_** | Performs a blessing, triggering interactions in BlessListeners.<br>Reflects projectiles? |
| Down | G | DblTap | **_Spirit Form_** | Enters Spirit Form, unrestricted air movement and smaller hitbox for a few seconds. |
| Down | A | DblTap | **_Spirit Form_** | (Same as Above) |
|  |  |  |  |  |

#### Kowi's Basic Attacks & Skills VS Achik's
When I think of Achik's basic attacks (shooting) and skills, it makes me want to think of Kowi's skills and all that. I feel like, however, they point to a very similar thing. If I'm implementing for Kowi's basic attacks different swings based on directions, like in Smash Bros., that's essentially this directional skill system but just for basic attacks. Kowi can probably have her kit revolve around a diverse set of basic attacks for when she's grounded or in the air, and skills that don't extend TOO far beyond that. ***For Kowi, physicality is key***, and so too will feedback and game feel be as I make her eventually.

Now that I've gotten that down, I can work more around Achik. I want them both to feel different but satisfying to play for each of them. As a part of that though, I need Achik to do things that Kowi can't in some situations.

##### Resource Meter for Skills?
***Here's a question: What about a Mana bar or a resource meter for skills?*** For skills that would actually use the resource, it WOULD make sense to limit them in some way. However, the question then becomes more about replenishing them. This is a neat idea because of what it entails, but it may impose limits I don't want (say you don't have enough Mana to spirit form up to some ledge and Kowi can't reach it either). That is, of course, assuming it doesn't regenerate.

A self-regenerating resource meter, like the mana meter in A Link Between Worlds, might be more appropriate for imposing limits on skills and all that so we can avoid spamming them... And depending on the skills that use them it'd be much easier to test for breakpoints and exploits (if we don't somehow limit spirit form, Achik can literally fly to Mongolia)... I must consider this seriously. 