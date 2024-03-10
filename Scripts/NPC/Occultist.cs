using Godot;
using System;

public partial class Occultist : Speaker
{
	[Export] public Sprite2D NPCSprite;
	[Export] public AnimationPlayer animPlayer;
	[Export] public Item steak;
	public override void _Ready()
    {
        base._Ready();
		GameController.theSpeaker = this;
		if(GameController.currentTime != 1 
			|| GameController.GetDay(GameController.currentDay) == "Tuesday" 
			|| GameController.GetDay(GameController.currentDay) == "Thursday"
			|| GameController.GetDay(GameController.currentDay) == "Friday") {
				textbox_system.Instance.Initialize(-100);
				NPCSprite.Visible = false;
				return;
			}
		if(GameController.occultistMemory[0] == 0) {
			textbox_system.Instance.Initialize(0);
		} else {
			animPlayer.Play("Intro");
		}
    }
    public override void _Process(double delta)
    {
		if(!initialized) {
			initialized = true;
		}
    }

	public void Init() {

		if(GameController.occultistMemory[0] == 0) {

		} else {
			textbox_system.Instance.Initialize(100);
		}
	}

	 public override DialogueSet GetNextDialogue(int id) {
		DialogueSet dialogueSet;
		switch(id){
			case -100:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"...",
						"*The Occultist isn't here.",
						"*Better go back."
					},
					new Godot.Collections.Array{
						"test_1",
						"test_2",
						"test_3"
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						-1
					}
				);
				break;
			case 0:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*You arrive at the park. The air is horribly chilly, and a light mist covers the ground.",
						"*In the center of the park, surrounded by candles, the Occultist sits at a table. She looks bored.",
						"*A sign on the table reads: Tarot readings: $5."
					},
					new Godot.Collections.Array{
						"test_1",
						"test_2",
						"test_3"
					},
					new Godot.Collections.Array{
						"*Time to learn my fortune.",
						"*Actually, let's not."
					},
					new Godot.Collections.Array{
						1,
						-1
					}
				);
				break;
			case 1:
				if(GameController.money > 5) {
					GameController.Instance.ChangeMoney(-5);
					animPlayer.Play("Intro");
					dialogueSet = new DialogueSet(
						new Godot.Collections.Array{
							"*As you approach the table, the sheer number of occult objects on display amazes you. The Occultist snaps out of her funk when she sees you coming.",
							"Evening, mister.",
							"You wanna get your fortune read, don't you?"
						},
						new Godot.Collections.Array{
							"test_1",
							"test_2",
							"test_3"
						},
						new Godot.Collections.Array{
							"Tell me how I'll die.",
							"Tell me if I'll be alone forever.",
							"Chef's choice."
						},
						new Godot.Collections.Array{
							2,
							5, 
							6
						}
					);
				} else {
					dialogueSet = new DialogueSet(
						new Godot.Collections.Array{
							"*You can't afford that...",
							"*You'll have to go home."
						},
						new Godot.Collections.Array{

						},
						new Godot.Collections.Array{
						},
						new Godot.Collections.Array{
							-1
						}
					);
				}
				break;
			
			case 2:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*The occultist gives a bubbly laugh.",
						"You'll be sacrificed at the stake in the middle of a freezing park by an expert on the occult arts.",
						"Your blood will summon the demon god Zulu and end the world as we know it.",
						"What do you think?"
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						"Knife me gently, please.",
						"Knife me hard, please."
					},
					new Godot.Collections.Array{
						3,
						4
					}
				);
				break;
			
			case 3:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"It'll be like a soft caress. Don't you worry.",
						"I'll even sing a little song for you as your soul leaves this plane. How does that sound?",
						"..."
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
			case 4:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"*The Occultist laughs again.",
						"Hey. I'm the sadist here. Don't steal my thunder.",
						"..."
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
						"*The Occultist studies your face closely.",
						"I can give you an answer to that right now, but you might ask for your 5 dollars back.",
						"Prognosis not great. Sorry champ.",
						"...",
						"Kidding, prettyboy. Don't glare like that."
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
			case 6:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"My choice would be to stake you here in the park and sacrifice your blood to the demon god Zulu.",
						"How's that sound?"
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						"Knife me gently, please.",
						"Knife me hard, please."
					},
					new Godot.Collections.Array{
						3,
						4
					}
				);
				break;
			case 7:
				GameController.occultistMemory[0] = 1;
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"Anyway, that's not really how this works.",
						"I'm just gonna start you off with a past, present, and future reading. That's the basics.",
						"Come back another time if you want something deeper.",
						"*The Occultist shuffles cards with blinding speed as she says this, staring you in the eyes.",
						"So, I'll have you pick three cards now...",
						"Alright...",
						"Now flip them over.",
						"*The Occultist studies your reading.",
						"The past -- Judgement. The present -- the Devil. And the future -- Hierophant, upside down.",
						"Well.",
						"You're a troubled individual, that much is clear.",
						"You shame yourself for your past and live the present with reckless abandon.",
						"And whatever lifeline you have, whoever's looking out for you... they'll turn on you in the end, too.",
						"What an attrocious fortune. You must be totally great."
					},
					new Godot.Collections.Array{

					},
					new Godot.Collections.Array{
						"Can I have a new one?",
						"Can't say that was worth the fiver..."
					},
					new Godot.Collections.Array{
						8,
						9
					}
				);
				break;
			
			case 8:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"Nope! Your fortune is forever-standing and utterly annhilating. Nothing you can do.",
						"Notwithstanding world-changing events, such as, for example, the rise of a demon god in this very park.",
						"That's my ultimate goal here, anyway. Your funds are off to a good cause.",
						"I could always use extra hands though.",
						"So if you have any, bring 'em so I can burn them at the altar. Demon god loves good meat.",
						"If you're interested in going out in a blaze of hellish glory instead of slowly withering away, come on back and see me.",
						"...",
						"*You've become acquainted with the Occultist. Time to head back."
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
			case 9:
				dialogueSet = new DialogueSet(
					new Godot.Collections.Array{
						"Too late! Your funds are locked away forever to be used to summon the demon god.",
						"I could always use extra hands though.",
						"So if you have any, bring 'em so I can burn them at the altar. Demon god loves good meat.",
						"If you're interested in going out in a blaze of hellish glory instead of slowly withering away, come on back and see me.",
						"...",
						"*You've become acquainted with the Occultist. Time to head back."
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
						"You say hello to the Occultist. Unfortunately, no more dialogue exists. Go home!"
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