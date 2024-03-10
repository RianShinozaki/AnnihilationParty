using Godot;
using System;

public partial class OfficeSpeaker : Speaker
{
	bool DoIntro = false;
	public static OfficeSpeaker Instance;
	public override void _Ready()
    {
        base._Ready();
		GameController.Instance.BeginIntroSequence += IntroSeq;
		if(DoIntro) {
			GameController.Instance.DoIntro();
		} else {
			BGMPlayer.Instance.BeginPlaying();
		}
		Instance = this;
		//Init();
    }
    public override void _Process(double delta)
    {
		if(!initialized) {
			initialized = true;
		}
    }
	public void IntroSeq() {
		GameController.theSpeaker = this;
		textbox_system.Instance.Initialize(0);
	}

	public void Init() {
		GameController.theSpeaker = this;
		textbox_system.Instance.Initialize(0);
	}

	public void PickupCall() {
		GameController.theSpeaker = this;
		if(lastCalledDay == GameController.currentDay) {
			textbox_system.Instance.Initialize(99);
		}
		lastCalledDay = GameController.currentDay;

		int theDay = GameController.currentDay;
		switch(theDay) {
			case 1:
				textbox_system.Instance.Initialize(100);
				break;
		}
	}
	public int lastCalledDay = 0;

	 public override DialogueSet GetNextDialogue(int id) {
		DialogueSet dialogueSet;
		switch(id){
			
			case 0:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*Four suspects -- Two abberants.",
						"*Abberants... Eldritch entities that have infested the city.",
						"*Beings that hide in the shadow of the psyche...",
						"*Of the four suspects before you, two of them are unknowingly nursing a nightmare virus that hides in the cloak of their own minds.",
						"*The longer they fester, the more power they gain...",
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						4
					}
				);
				break;
			
			case 4:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*You have one month to find them... That is all your briefing said."
					},
					new Godot.Collections.Array{
						
					},
					new Godot.Collections.Array{
						"*Ponder on the idea of Eldritch entities.",
						"Well, this is some bullshit.",
						"Better get to work."
					},
					new Godot.Collections.Array{
						1,
						5,
						6
					}
				);
				break;
			
			case 1:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*Eldritch entities.",
						"*By definition, unknowable and unspeakable horrors.",
						"*...This is not a particularly satisfying definition for your detective mind."
					},
					new Godot.Collections.Array{
						
					},
					new Godot.Collections.Array{
						"They don't really know what it is.",
						"Perchance the true horror is the human mind.",
						"*Give up pondering."
					},
					new Godot.Collections.Array{
						2,
						3,
						4
					}
				);
				break;
			case 7:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"..."
					},
					new Godot.Collections.Array{
						
					},
					new Godot.Collections.Array{
						"They don't really know what it is.",
						"Perchance the true horror is the human mind.",
						"*Give up pondering."
					},
					new Godot.Collections.Array{
						2,
						3,
						4
					}
				);
				break;
			
			case 2:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"...",
						"*Truly, they don't.",
						"*Autopsies coming back with more questions than answers. Lethal blows struck to long-standing theories of physics, psychology, biology...",
						"*It's not simply that they don't know what these horrors are. The existence of these horrors seem to imply we don't know what anything is.",
						"*Cities leveled by these anomalies.",
						"*As if the world needed to be more messed up than it already is."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						7
					}
				);
				break;
			
			case 3:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*Of all the unknowable, theory-defying branches of science...",
						"*None have given a particularly satisfying answer to the question of the human mind.",
						"*So perhaps this is karma for mankind's ignorance.",
						"*...As you consider this idea with your human mind, you begin to feel reality slipping away...",
						"*You should know better, Mr. Detective. These kinds of thoughts aren't good for you."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						7
					}
				);
				break;
			
			case 5:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*And truly, it is.",
						"*Shunted into the far rings of the United Solar System, told your very survival rests on this case...",
						"*Only for the case briefing to spout some Fruedian... bullshit.",
						"*You wish you had a better word. You wish they had better words."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						4
					}
				);
				break;
			
			case 6:
				GameController.SetSplitX(225);
				BGMPlayer.Instance.BeginPlaying();
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*No time to mope about the meaning of abberations and Eldritch beings and whatnot.",
						"*Work calls.",
						"...You've arrived in the office, and the office is still standing, and tentacled multi-eyed horrors are not peeping through the window.",
						"*That much is right with the world so far.",
						"*A previous 'abberation detective,' a fellow sufferer of the Eldritch Bullshit, should be calling you soon...",
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						8
					}
				);
				break;
			case 8:
				Phone.Instance.StartRinging();
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*Ah."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						-1
					}
				);
				break;
			case 99:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*You've already called today."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						-1
					}
				);
				break;
			case 100:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*You pick up the archaic phone.",
						"*...A tired, gravelly voice comes through.",
						"Mornin'. ",
						"This the new blood?"
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						"New blood present.",
						"Chief bullshit detective, reporting for duty.",
						"Good grief. What did this job do to you?"
					},
					new Godot.Collections.Array{
						101,
						102,
						103
					}
				);
				break;
			
			case 101:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"Sound just a bit less chipper for me.",
						"Optimistic energy is bad for my blood pressure. My doc told me to avoid it."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						104
					}
				);
				break;
			case 102:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"Oh, good. I was worried I'd have to warn you that this job was criminally stupid.",
						"Looks like we're skipping that part of the welcome call."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						104
					}
				);
				break;
			case 103:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"The hell? I ain't even said anything yet."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						104
					}
				);
				break;
			case 104:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"So, by now you're settled into the old office and the case briefing is nice and settled in your brain, yeah?",
						"As far as clarification goes on what that case file is talking about, I got nothin' for ya.",
						"But I can tell you how you're gonna do this. So listen up.",
						"I did this gig before you. See, I'm a pretty big shot detective. The last city this happened to, well... the United Solar System actually cared to keep that one.",
						"I think they give just a little more than a super-rat's ass about your city.",
						"So you're good, but you're probably not great. Sorry, champ.",
						"But I still wanna get you through this."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						"I feel I'm worth more than a super-rat's ass.",
						"What's the success rate of this operation?",
						"Alright, give me the details."
					},
					new Godot.Collections.Array{
						106,
						107,
						108
					}
				);
				break;
			case 105:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"..."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						"I feel I'm worth more than a super-rat's ass.",
						"What's the success rate of this operation?",
						"Alright, give me the details."
					},
					new Godot.Collections.Array{
						106,
						107,
						108
					}
				);
				break;
			case 106:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"Said you were.",
						"...Just a little bit.",
						"Frankly, what with the general size of this planet, and that war going on...",
						"I think they see it as more trouble than it's worth.",
						"Easy for them not to give it their all, given half the populace doesn't even believe in... whatever's allegedly going on here. The Abberants.",
						"So if a city gets annhilated, that's one less headache, and more funding for weaponry.",
						"Some people we put our trust in..."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						105
					}
				);
				break;
			case 107:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"We've lost three colonies over it, but I was able to save one of the central planets.",
						"That puts us at... 25%?",
						"It is what it is."
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						108
					}
				);
				break;
			
			case 108:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"Alright, so the details are: You're basically alone out there.",
						"You've gotta find the two abberants by the end of the month or it's hello, annhilation.",
						"Now, you've got a few tools at your disposal. Thanks to WiFi signal reconstruction and digital surveillance, we can essentially tell you what everyone did each day.",
						"That won't be enough, because the Abberant rarely reveals itself when it's alone.",
						"However, the presence of the Abberant can manifest in outbursts of unusual behavior.",
						"Try to get a measure of everyone's daily activities, and look for anything that stands out.",
						"However, where the Abberant really reveals itself is in contact between humans.",
						"You'll need to get close to the suspects.",
						"Befriend them. Throw them off guard. Make them attached to you. Use your information.",
						"Do whatever it takes to get them to open up to you. In doing so, the Abberant may reveal itself in measured amounts.",
						"...It does so in an attempt to infect you as well.",
						"You have until the last two days of the month. Then, you'll have to make your decision.",
						"Get either of the Abberants wrong, and it's over.",
						"Get it right and it's a happy New Year's Day.",
						"Let's recap. Spend time with suspects, and earn their trust. Check their logs and learn their habits.",
						"If you see some strange behavior, try to get them to talk to you about it.",
						"...Listen, that's probably enough for today.",
						"I can tell you more if you call again another time. Just pick up the phone. I'll be here.",
						"Meanwhile, look over those logs and start to get to know the suspects. Your briefing should have told you where to find them.",
						"Rooting for ya.",
						"*The phone clicks off.",
						"*...A stack of logs on my desk, and photos of the suspects on the wall...",
						"*You can call him again for more help. But for now, it could be best to take a look around.",
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
					},
					new Godot.Collections.Array{
						-1
					}
				);
				break;
		
			default:
				dialogueSet = null;
				break;
		}
		return dialogueSet;
	}
}