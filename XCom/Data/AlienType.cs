using System.Collections.Generic;
using XCom.Content.Overlays;

namespace XCom.Data
{
	public enum AlienType
	{
		Sectoid,
		SectoidAutopsy,
		Snakeman,
		SnakemanAutopsy,
		Muton,
		MutonAutopsy,
		Floater,
		FloaterAutopsy,
		Ethereal,
		EtherealAutopsy,
		Celatid,
		CelatidAutopsy,
		Silacoid,
		SilacoidAutopsy,
		Chryssalid,
		ChryssalidAutopsy,
		Reaper,
		ReaperAutopsy,
		Cyberdisc,
		CyberdiscAutopsy,
		Sectopod,
		SectopodAutopsy
	}

	public static class AlienTypeExtensions
	{
		public static AlienMetadata Metadata(this AlienType alienType) => metadata[alienType];

		private static readonly AlienMetadata sectoid = new AlienMetadata
		{
			Name = "Sectoid",
			RequiredResearch = ResearchType.Sectoid,
			Overlay = Overlays.Sectoid,
			DescriptionLines = new[]
			{
				"The Sectoid Hierarchy ranges",
				"from soldiers to leaders with",
				"powerful psionic abilities. These",
				"psionic powers can be used to",
				"demoralize soldiers in combat, or",
				"even take control of their",
				"minds. They tend to indulge in",
				"human abductions and cattle",
				"mutilation.  The adbuction is",
				"used to extract genetic",
				"material for cross breeding and",
				"developing clones for infiltrating",
				"human society.  The cattle",
				"provide both nutrition and",
				"genetic material.  This race",
				"appears to want to develop",
				"superior genetic hybrids to",
				"increase the efficiency of their",
				"hive-like society."
			}
		};

		private static readonly AlienMetadata sectoidAutopsy = new AlienMetadata
		{
			Name = "Sectoid autopsy",
			RequiredResearch = ResearchType.SectoidCorpse,
			Overlay = Overlays.SectoidAutopsy,
			DescriptionLines = new[]
			{
				"The autopsy reveals vestigal",
				"digestive organs and a simple",
				"structure. The brain and eyes",
				"are very well developed.  The",
				"structure suggests genetic",
				"alteration or mutation.  The",
				"small mouth and nose appear to",
				"have little function.  The",
				"webbing between the fingers,",
				"and the flat feet suggest",
				"aquatic origins.  There are no",
				"reproductive organs, and no",
				"clues as to how this species can",
				"reproduce.  They are most",
				"probably a genetically engineered",
				"species."
			}
		};

		private static readonly AlienMetadata snakeman = new AlienMetadata
		{
			Name = "Snakeman",
			RequiredResearch = ResearchType.Snakeman,
			Overlay = Overlays.Snakeman,
			DescriptionLines = new[]
			{
				"This race developed in an",
				"extremely hostile environment.",
				"They are extremely tough and",
				"can resist extreme temperature",
				"variations. Their mobility",
				"depends on a snake-like giant",
				"'foot' which protects all the",
				"vital organs.  Their objectives",
				"appear to be purely predatory",
				"and they appear to be under",
				"the command of some other",
				"Intelligence which directs their",
				"military-style incursions on",
				"earth."
			}
		};

		private static readonly AlienMetadata snakemanAutopsy = new AlienMetadata
		{
			Name = "Snakeman autopsy",
			RequiredResearch = ResearchType.SnakemanCorpse,
			Overlay = Overlays.SnakemanAutopsy,
			DescriptionLines = new[]
			{
				"The skin is extremely tough and",
				"heat resistant.  The",
				"cardio-vascular system is part",
				"of the muscular system which",
				"uses the hydraulic principle to",
				"create motion.  The only true",
				"muscle is the 'heart'.  The",
				"reproductive system appears to",
				"be very efficient.  Reproduction",
				"is asexual, with each snakeman",
				"carrying up to fifty eggs inside",
				"its body at any one time.  Left",
				"to its own devices this species",
				"would be a severe threat to",
				"life on earth."
			}
		};

		private static readonly AlienMetadata muton = new AlienMetadata
		{
			Name = "Muton",
			RequiredResearch = ResearchType.Muton,
			Overlay = Overlays.Muton,
			DescriptionLines = new[]
			{
				"This humanoid creature is",
				"physically powerful and",
				"intelligent.  They have a",
				"particular appetite for",
				"consuming raw flesh of any kind,",
				"which they need to sustenance",
				"like earth based carnivores.",
				"They appear to rely on",
				"telepathic commands from a race",
				"known as 'Ethereals'.  Once",
				"separated from this telepathic",
				"link their mental system",
				"appears to break down and",
				"they die. They cybernetic",
				"implants are used to enhance",
				"their combat performance.  They",
				"are clearly the foot soldiers",
				"for a higher intelligence."
			}
		};

		private static readonly AlienMetadata mutonAutopsy = new AlienMetadata
		{
			Name = "Muton autopsy",
			RequiredResearch = ResearchType.MutonCorpse,
			Overlay = Overlays.MutonAutopsy,
			DescriptionLines = new[]
			{
				"The 'skin' of this creature",
				"appears to be an organically",
				"created protective armor which",
				"is grafted onto the body.",
				"There are numerous cybernetic",
				"implants which are used to",
				"enhance the cardio-vascular",
				"system and the senses.  The",
				"reproductive organs appear to",
				"have been surgically removed.",
				"Evidently these unfortunate",
				"creatures are limited to a life",
				"of warfare and conquest.",
				"Armor piercing ammunition is",
				"not very effective against",
				"their toughened skin."
			}
		};

		private static readonly AlienMetadata floater = new AlienMetadata
		{
			Name = "Floater",
			RequiredResearch = ResearchType.Floater,
			Overlay = Overlays.Floater,
			DescriptionLines = new[]
			{
				"The Floaters are primarily",
				"soldiers and terror agents.",
				"They are naturally predatory",
				"beasts, genetically engineered",
				"and cybernetically enhanced to",
				"make formidable warriors. The",
				"lower half of the body and most",
				"internal organs are surgically",
				"removed, and a life support",
				"system is installed. This implant",
				"contains an anti-grav unit which",
				"enabled the creature to float,",
				"albeit unsteadily, through the",
				"air."
			}
		};

		private static readonly AlienMetadata floaterAutopsy = new AlienMetadata
		{
			Name = "Floater autopsy",
			RequiredResearch = ResearchType.FloaterCorpse,
			Overlay = Overlays.FloaterAutopsy,
			DescriptionLines = new[]
			{
				"The creature has been",
				"drastically altered by surgery.",
				"The device which seems to form",
				"the core of the body is a life",
				"support system, taking over",
				"the function of heart, lungs and",
				"digestive system.  This would",
				"enable the creature to survive",
				"in extremely hostile",
				"environments.  The brain is",
				"smaller than ours, but the",
				"sensory organs are well",
				"developed."
			}
		};

		private static readonly AlienMetadata ethereal = new AlienMetadata
		{
			Name = "Ethereal",
			RequiredResearch = ResearchType.Ethereal,
			Overlay = Overlays.Ethereal,
			DescriptionLines = new[]
			{
				"This being has awesome mental",
				"powers which allow for telepathic",
				"communication and telekinetic",
				"abilities.  The apparently weak",
				"physical abilities of this creature",
				"are sustained by its mental",
				"powers.  We do not understand",
				"how these telekinetic powers",
				"work, since they seem to defy",
				"the laws of physics as we know",
				"them.  They are extremely",
				"dangerous in any combat",
				"situation, where they rely on",
				"their mental powers for combat.",
				"They rarely appear on earth",
				"since they seem to rely on other",
				"races to pursue their objectives."
			}
		};

		private static readonly AlienMetadata etherealAutopsy = new AlienMetadata
		{
			Name = "Ethereal autopsy",
			RequiredResearch = ResearchType.EtherealCorpse,
			Overlay = Overlays.EtherealAutopsy,
			DescriptionLines = new[]
			{
				"This being is physically retarded",
				"and seems incapable of sustaining",
				"any life functions.  The muscles",
				"are severely atrophied and the",
				"internal organs appear to be",
				"under-developed.  The sensory",
				"organs, including the eyes, do",
				"not appear to function at all.",
				"The brain, however, is well",
				"developed and draws on a high",
				"proportion of the body's blood",
				"supply.  It is a mystery as to",
				"how this creature can sustain",
				"itself without external support."
			}
		};

		private static readonly AlienMetadata celatid = new AlienMetadata
		{
			Name = "Celatid",
			RequiredResearch = ResearchType.Celatid,
			Overlay = Overlays.Celatid,
			DescriptionLines = new[]
			{
				"This life-form has the",
				"mysterious natural ability to",
				"float through the air.  It",
				"appears to detect human brain",
				"waves and will move towards a",
				"human target even if well",
				"hidden.  Once a target is",
				"detected the Celatid lands and",
				"fires small globules of extremely",
				"corrosive venom.  The creature",
				"has the ability to clone itself",
				"at an alarming rate. It",
				"accompanies the Muton race in",
				"its wonderings."
			}
		};

		private static readonly AlienMetadata celatidAutopsy = new AlienMetadata
		{
			Name = "Celatid autopsy",
			RequiredResearch = ResearchType.CelatidCorpse,
			Overlay = Overlays.CelatidAutopsy,
			DescriptionLines = new[]
			{
				"The core contains a small",
				"bio-mechanical device which",
				"appears to be a naturally",
				"evolved anti-gravity propulsion",
				"system.  The sac of venom is",
				"the largest organ and there",
				"does not appear to be a",
				"separate brain structure. There",
				"is no discernible digestive or",
				"reproductive system. A small",
				"organ contains embryos which",
				"can grow rapidly into a new",
				"being."
			}
		};

		private static readonly AlienMetadata silacoid = new AlienMetadata
		{
			Name = "Silacoid",
			RequiredResearch = ResearchType.Silacoid,
			Overlay = Overlays.Silacoid,
			DescriptionLines = new[]
			{
				"This silicon based life form",
				"generates an enormous amount",
				"of heat.  It has the strength",
				"to crush rocks which can then",
				"be ingested by the hot core.",
				"It has a primitive intelligence",
				"and can be controlled by",
				"implants or telepathic beings. It",
				"works with the Muton alien",
				"race."
			}
		};

		private static readonly AlienMetadata silacoidAutopsy = new AlienMetadata
		{
			Name = "Silacoid autopsy",
			RequiredResearch = ResearchType.SilacoidCorpse,
			Overlay = Overlays.SilacoidAutopsy,
			DescriptionLines = new[]
			{
				"The core of the creature is",
				"extremely hot, and seems to be",
				"the basis for a digestive",
				"system.  Its unique muscle",
				"system has tremendous power",
				"and speed. Its rock like skin is",
				"not harmed by fire or",
				"incendiary ammunition."
			}
		};

		private static readonly AlienMetadata chryssalid = new AlienMetadata
		{
			Name = "Chryssalid",
			RequiredResearch = ResearchType.Chrysalid,
			Overlay = Overlays.Chryssalid,
			DescriptionLines = new[]
			{
				"The crab like claws of this",
				"creature are a powerful weapon",
				"in close combat. The high",
				"metabolism and strength of this",
				"creature give it speed and",
				"dexterity. Instead of killing its",
				"victim it impregnates it with an",
				"egg and injects a venom which",
				"turns it into a walking zombie.",
				"A new Chryssalid will burst from",
				"the victim shortly after",
				"impregnation.  Chryssalids are",
				"associated with the Snakeman",
				"race."
			}
		};

		private static readonly AlienMetadata chryssalidAutopsy = new AlienMetadata
		{
			Name = "Chryssalid autopsy",
			RequiredResearch = ResearchType.ChryssalidCorpse,
			Overlay = Overlays.ChryssalidAutopsy,
			DescriptionLines = new[]
			{
				"The exo-skeleton of this",
				"creature is extremely tough,",
				"but surprisingly vulnerable to",
				"explosive ammunition.  The brain",
				"is well developed, and its cell",
				"growth rate very fast.  The",
				"creature carries twenty eggs",
				"which are laid inside other",
				"organisms.  This creature is a",
				"very effective terror weapon."
			}
		};

		private static readonly AlienMetadata reaper = new AlienMetadata
		{
			Name = "Reaper",
			RequiredResearch = ResearchType.Reaper,
			Overlay = Overlays.Reaper,
			DescriptionLines = new[]
			{
				"This bipedal carnivore has",
				"powerful jaws and a voracious",
				"appetite. It has a number of",
				"brain implants which are used to",
				"control its activity. the",
				"primitive predatory instincts of",
				"this creature are of little use",
				"except to terrorize and",
				"destroy. Reapers are commonly",
				"associated with Floaters."
			}
		};

		private static readonly AlienMetadata reaperAutopsy = new AlienMetadata
		{
			Name = "Reaper autopsy",
			RequiredResearch = ResearchType.ReaperCorpse,
			Overlay = Overlays.ReaperAutopsy,
			DescriptionLines = new[]
			{
				"The Reaper contains two 'brains'",
				"and two 'hearts' which allow it",
				"to function even when heavily",
				"wounded.  However its furry",
				"skin is highly flammable, making",
				"the creature vulnerable to",
				"incendiary weapons."
			}
		};

		private static readonly AlienMetadata cyberdisc = new AlienMetadata
		{
			Name = "Cyberdisc",
			RequiredResearch = ResearchType.Cyberdisc,
			Overlay = Overlays.Cyberdisc,
			DescriptionLines = new[]
			{
				"This miniature flying saucer is",
				"an automated terror weapon",
				"armed with a powerful plasma",
				"beam. The anti-grav propulsion",
				"gives it a big advantage in",
				"difficult terrain. Its primary",
				"function is destruction and",
				"terror in the service of the",
				"Sectoid race."
			}
		};

		private static readonly AlienMetadata cyberdiscAutopsy = new AlienMetadata
		{
			Name = "Cyberdisc autopsy",
			RequiredResearch = ResearchType.CyberdiscCorpse,
			Overlay = Overlays.CyberdiscAutopsy,
			DescriptionLines = new[]
			{
				"The Cyberdisc is well shielded",
				"and is particularly good at",
				"withstanding explosive",
				"ammunition. The primary",
				"anti-gravity system is too",
				"badly damaged to gain any",
				"understanding of its functioning."
			}
		};

		private static readonly AlienMetadata sectopod = new AlienMetadata
		{
			Name = "Sectopod",
			RequiredResearch = ResearchType.Sectopod,
			Overlay = Overlays.Sectopod,
			DescriptionLines = new[]
			{
				"Sectopods are robot creatures",
				"with a powerful plasma beam",
				"weapon. The control if these",
				"mechanical beasts is via a",
				"telepathic link to their",
				"controllers, the Ethereals.",
				"Sectopods are the most powerful",
				"terror weapon available to the",
				"alien forces."
			}
		};

		private static readonly AlienMetadata sectopodAutopsy = new AlienMetadata
		{
			Name = "Sectopod autopsy",
			RequiredResearch = ResearchType.SectopodCorpse,
			Overlay = Overlays.SectopodAutopsy,
			DescriptionLines = new[]
			{
				"The robot is sturdily constructed",
				"with powered armor capable of",
				"resisting most forms of attack,",
				"in particular plasma weapons.",
				"However, the sensing circuitry",
				"seems particularly vulnerable to",
				"laser weapons."
			}
		};

		private static readonly Dictionary<AlienType, AlienMetadata> metadata = new Dictionary<AlienType, AlienMetadata>
		{
			{ AlienType.Sectoid, sectoid },
			{ AlienType.SectoidAutopsy, sectoidAutopsy },
			{ AlienType.Snakeman, snakeman },
			{ AlienType.SnakemanAutopsy, snakemanAutopsy },
			{ AlienType.Muton, muton },
			{ AlienType.MutonAutopsy, mutonAutopsy },
			{ AlienType.Floater, floater },
			{ AlienType.FloaterAutopsy, floaterAutopsy },
			{ AlienType.Ethereal, ethereal },
			{ AlienType.EtherealAutopsy, etherealAutopsy },
			{ AlienType.Celatid, celatid },
			{ AlienType.CelatidAutopsy, celatidAutopsy },
			{ AlienType.Silacoid, silacoid },
			{ AlienType.SilacoidAutopsy, silacoidAutopsy },
			{ AlienType.Chryssalid, chryssalid },
			{ AlienType.ChryssalidAutopsy, chryssalidAutopsy },
			{ AlienType.Reaper, reaper },
			{ AlienType.ReaperAutopsy, reaperAutopsy },
			{ AlienType.Cyberdisc, cyberdisc },
			{ AlienType.CyberdiscAutopsy, cyberdiscAutopsy },
			{ AlienType.Sectopod, sectopod },
			{ AlienType.SectopodAutopsy, sectopodAutopsy }
		};
	}
}
