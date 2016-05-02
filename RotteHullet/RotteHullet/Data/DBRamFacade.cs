using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using RotteHullet.Domain.BusinessLogic;

namespace RotteHullet.Data
{
    class DBRamFacade : IDBFacade
    {
        private static DBRamFacade _dbRamFacade;
        private List<Bog> _bogListe;
        private List<Brætspil> _brætspilsListe;
        private List<Udstyr> _udstyrsListe;
        private List<Lokale> _lokaleListe;
        private List<Medlem> _medlemListe = new List<Medlem>();
        private Random random = new Random();

        #region Constructor
        public DBRamFacade()
        {
            _bogListe = new List<Bog>();
            _brætspilsListe = new List<Brætspil>();
            _udstyrsListe = new List<Udstyr>();
            _lokaleListe = new List<Lokale>();
        }
        #endregion

        /// <summary>
        /// Statisk metode som returner den instans af facaden. Laver en ny, hvis den ikke eksisterer.
        /// </summary>
        /// <returns></returns>
        public static DBRamFacade HentDbRamFacade()
        {
            if (_dbRamFacade == null)
            {
                _dbRamFacade = new DBRamFacade();
                _dbRamFacade.dataListe();
            }
            return _dbRamFacade;
        }

        #region Brætspil
        public bool GemBrætSpil(Brætspil bs)
        {
            _brætspilsListe.Add(bs);
            return true;
        }
        public bool ÆndreBrætSpil(int gammeltID, Brætspil bs)
        {
            for (int i = 0; i < _brætspilsListe.Count; i++)
            {
                if (_brætspilsListe[i].Id == gammeltID)
                {
                    _brætspilsListe[i] = bs;
                    return true;
                }
            }
            return false;
        }

        public Brætspil HentBrætSpil(int id)
        {
            for (int i = 0; i < _brætspilsListe.Count; i++)
            {
                if (_brætspilsListe[i].Id == id)
                {
                    return _brætspilsListe[i];
                }
            }
            return null;
        }

        public List<Brætspil> HentAlleBrætSpil()
        {
            return _brætspilsListe;
        }

        public bool SletBrætSpil(int id)
        {
            for (int i = 0; i < _brætspilsListe.Count; i++)
            {
                if (_brætspilsListe[i].Id == id)
                {
                    _brætspilsListe.Remove(_brætspilsListe[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Bog
        public bool GemBog(Bog bog)
        {
            _bogListe.Add(bog);
            return true;
        }

        public bool ÆndreBog(int gammeltID, Bog bog)
        {
            for (int i = 0; i < _bogListe.Count; i++)
            {
                if (_bogListe[i].Id == gammeltID)
                {
                    _bogListe[i] = bog;
                    return true;
                }
            }
            return false;
        }

        public Bog HentBog(int id)
        {
            for (int i = 0; i < _bogListe.Count; i++)
            {
                if (_bogListe[i].Id == id)
                {
                    return _bogListe[i];
                }
            }
            return null;
        }

        public List<Bog> HentAlleBøger()
        {
            return _bogListe;
        }

        public bool SletBog(int id)
        {
            for (int i = 0; i < _bogListe.Count; i++)
            {
                if (_bogListe[i].Id == id)
                {
                    _bogListe.Remove(_bogListe[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Udstyr
        public bool GemUdstyr(Udstyr udstyr)
        {
            _udstyrsListe.Add(udstyr);
            return true;
        }

        public bool ÆndreUdstyr(int gammeltID, Udstyr udstyr)
        {
            for (int i = 0; i < _udstyrsListe.Count; i++)
            {
                if (_udstyrsListe[i].Id == gammeltID)
                {
                    _udstyrsListe[i] = udstyr;
                    return true;
                }
            }
            return false;
        }

        public Udstyr HentUdstyr(int id)
        {
            for (int i = 0; i < _udstyrsListe.Count; i++)
            {
                if (_udstyrsListe[i].Id == id)
                {
                    return _udstyrsListe[i];
                }
            }
            return null;
        }

        public List<Udstyr> HentAlleUdstyr()
        {
            return _udstyrsListe;
        }

        public bool SletUdstyr(int id)
        {
            for (int i = 0; i < _udstyrsListe.Count; i++)
            {
                if (_udstyrsListe[i].Id == id)
                {
                    _udstyrsListe.Remove(_udstyrsListe[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Lokale
        public bool GemLokale(Lokale lokale)
        {
            _lokaleListe.Add(lokale);
            return true;
        }

        public bool ÆndreLokale(int gammeltID, Lokale lokale)
        {
            for (int i = 0; i < _lokaleListe.Count; i++)
            {
                if (_lokaleListe[i].Id == gammeltID)
                {
                    _lokaleListe[i] = lokale;
                    return true;
                }
            }
            return false;
        }

        public Lokale HentLokale(int id)
        {
            for (int i = 0; i < _lokaleListe.Count; i++)
            {
                if (_lokaleListe[i].Id == id)
                {
                    return _lokaleListe[i];
                }
            }
            return null;
        }

        public List<Lokale> HentAlleLokaler()
        {
            return _lokaleListe;
        }

        public bool SletLokale(int id)
        {
            for (int i = 0; i < _lokaleListe.Count; i++)
            {
                if (_lokaleListe[i].Id == id)
                {
                    _lokaleListe.Remove(_lokaleListe[i]);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Medlem

        public Medlem HentMedlem(string brugernavn)
        {
            return _medlemListe.Find(x => x.Brugernavn == brugernavn);
        }
        /// <summary>
        /// Hent medlem med password validering
        /// </summary>
        /// <param name="brugernavn"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Medlem HentMedlem(string brugernavn, string password)
        {
            return _medlemListe.Find(x => x.Brugernavn == brugernavn && x.Password == password);
        }
        public List<Medlem> HentAlleMedlem()
        {
            return _medlemListe;
        }

        #endregion

        #region Selv definerer data
        private void dataListe()
        {
            testBruger();
            randomBøger();
            randomBrætspil();
            randomUdstyr();
            randomLokale();
        }
        private void randomBøger()
        {
            #region Fornavn
            List<string> fornavn = new List<string> {
                "Sofia",
                "Willia",
                "Alma",
                "Luca",
                "Freja",
                "Malth",
                "Anna",
                "Noa",
                "Ella",
                "Emi",
                "Emma",
                "Victo",
                "Laura",
                "Osca",
                "Clara",
                "Alfre",
                "Maja",
                "Olive",
                "Alberte",
                "Frederi",
                "Ida",
                "Car",
                "Agnes",
                "Elia",
                "Liva",
                "Villad",
                "Isabella",
                "Magnu",
                "Josefine",
                "Anto",
                "Karla",
                "Christia",
                "Mathilde",
                "Alexande",
                "Emilie",
                "Augus",
                "Victoria",
                "Mikke",
                "Olivia",
                "Lia",
                "Caroline",
                "Valdema",
                "Lærke",
                "Noh",
                "Sofie",
                "Feli",
                "Frida",
                "Mad",
                "Sara",
                "Akse",
                "Emily",
                "Joha",
                "Lily",
                "Stor",
                "Mille",
                "Alber",
                "Ellen",
                "Benjami",
                "Marie",
                "Theodo",
                "Astrid",
                "Ada",
                "Naja",
                "Mathia",
                "Esther",
                "Arthu",
                "Luna",
                "Marcu",
                "Nora",
                "Tobia",
                "Aya",
                "Phili",
                "Rosa",
                "Vigg",
                "Lea",
                "Jaco",
                "Johanne",
                "The",
                "Asta",
                "Ellio",
                "Vigga",
                "Sebastia",
                "Liv",
                "Mariu",
                "Nanna",
                "Tho",
                "Celina",
                "Laug",
                "Merle",
                "Sande",
                "Vilma",
                "Laurit",
                "Silje",
                "Villu",
                "Filippa",
                "Jona",
                "Julie",
                "Ott",
                "Signe",
                "Silas"
            };
            #endregion

            #region Genre
            List<string> genre = new List<string> { "Action", "Eventyr", "Fantasi", "RPG", "Gyser"};
            #endregion

            #region Titel
            List<string> titel = new List<string> {
                "d20 Modern by Wizards of the Coast",
                "Feng Shui - based on Hong Kong martial arts movies",
                "Fiasco - a GM-less game about petty criminals and cruel twists of fate",
                "GUMSHOE System",
                "Inner City by Inner City Games",
                "James Bond 007 by Victory Games - based on the James Bond books and films",
                "Mercenaries, Spies and Private Eyes",
                "Ninjas & Superspies (1987) - Created by Erick Wujcik, published by Palladium Books",
                "Night of the Ninja",
                "Over the Edge",
                "Revised RECON (1986) - Created by Erick Wujcik, published by Palladium Books; based on the original Recon (1981) by Joe F. Martin",
                "Spycraft by Alderac Entertainment Group - espionage adventure",
                "Top Secret by TSR - espionage adventure",
                "Twilight 2000",
                "Leverage",
                "Fantasy",
                "Agone (French) - based on novels by award-winning fantasy writer Mathieu Gaborit.",
                "Alshard (Japanese) - fantasy with mecha like Final Fantasy",
                "Alshard Gaia (Japanese) - a contemporary fantasy with Alshard system",
                "Amber Diceless Roleplaying - based on the works of Roger Zelazny",
                "Anima: Beyond Fantasy",
                "Arcanis - Origins Award winning Fantasy RPG system by Paradigm Concepts, Inc. Unlike many RPG systems, focuses on a more Roman-era aesthetic and morally gray decisions.",
                "Archaeron",
                "Arduin - written by David A. Hargrave",
                "Aria",
                "Arianrhod RPG (Japanese) - MMORPG-like",
                "Ars Magica",
                "Basic Fantasy RPG",
                "BattleDragons - Play as dragons in a fantasy world by Spartacus Publishing.",
                "Bifrost",
                "The Black Company - Campaign Setting based on the The Black Company book series by Glen Cook, using the d20 system.",
                "Blue Rose by Green Ronin Publishing",
                "The Burning Wheel - High fantasy",
                "By the Gods",
                "Castles and Crusades - OGL System fantasy RPG published by Troll Lord Games",
                "Castle Falkenstein - steampunk fantasy",
                "Chivalry & Sorcery",
                "Les Chroniques d'Erdor, an unusual French RPG of oneiric fantasy using a 54 card game, edited by Boite a Polpette.",
                "Chronicles of Ramlar",
                "Conan supplements, Conan Unchained! and Conan Against Darkness!, both published in 1984 by TSR",
                "Conan Role-Playing Game, using the so-called ZeFRS (Zeb's Fantasy Roleplaying System), and published in 1985 by TSR",
                "GURPS Conan, using the GURPS system and published as of 1989 by Steve Jackson Games",
                "Conan: The Roleplaying Game, the OGL System version published from 2004 to 2010 by Mongoose Publishing",
                "Cursed Empire (formerly Crimson Empire, changed its name for trademark reasons)",
                "Dangerous Journeys - created by E. Gary Gygax",
                "The Dark Eye - Germany's most popular RPG, known in Germany as Das Schwarze Auge",
                "Deliria: Faerie Tales for the New Millennium - by Phil Brucato. Published by Laughing Pan Productions",
                "Demon's Lair - Created by Lasalion Games",
                "Dinky Dungeons",
                "Donjon - by Clinton R. Nixon",
                "Dragon Age",
                "Dragonlance: Fifth Age - by TSR",
                "DragonQuest",
                "DragonRaid - a Christian RPG, created by Dick Wulf in 1984",
                "Dragonroar",
                "Dragon Warriors - An easy-to-use RPG published in paperback format.",
                "Drakar och Demoner (Dragons and Demons) - Swedish language game originally published by Target Games, later versions by Riotminds",
                "Dungeons & Dragons - created by Dave Arneson and E. Gary Gygax, further editions by TSR, Inc. and Wizards of the Coast",
                "Dungeon World - a fantasy game Powered by the Apocalypse created by Sage Latorra and Adam Koebel",
                "Earthdawn",
                "Element Masters",
                "Elemental Axes by Crosstime Games of British Columbia",
                "Elfquest by Chaosium - based on the works of Richard Pini and Wendy Pini",
                "Elric!, by Chaosium, based on Michael Moorcock's Elric of Melniboné stories",
                "Empire of the Petal Throne - set in M. A. R. Barker's world of Tekumel",
                "Eon",
                "Everquest - pencil & paper version of the popular MMORPG, published by White Wolf Publishing",
                "Everway",
                "Exalted",
                "Fantasy Craft by Crafty Games",
                "Fantasy Hero by Hero Games",
                "Fantasy Imperium",
                "The Fantasy Trip",
                "Fireborn by Fantasy Flight Games",
                "Furry Pirates",
                "Fate of the Norns",
                "A Game of Thrones - based on the eponymous fantasy novel",
                "Grimm - based in a twisted, morbid fairytale world, published by Fantasy Flight Games.",
                "HackMaster",
                "HârnMaster/Hârn",
                "High Adventure Role Playing by Iron Crown Enterprises",
                "Hawkmoon - an addendum to the Stormbringer RPG (aka Elric!)",
                "Hero Kids - An introductory RPG for Kids",
                "HeroQuest/Hero Wars",
                "Hidden Kingdom'",
                "Hunter's Dark' created by Matthew C in early 2015",
                "In Nomine - Based on the In Nomine Satanis / Magna Veritas French roleplaying game",
                "Ironclaw - by Sanguine Productions Ltd",
                "Legend of the Five Rings Role-Playing Game - Asian-themed RPG, published by Alderac Entertainment Group",
                "Lejendary Adventure, created by Gary Gygax and published by Hekaforge Productions",
                "Lone Wolf",
                "Lord of the Rings Roleplaying Game - based on the fantasy works of J. R. R. Tolkien",
                "Maelstrom",
                "Man, Myth & Magic by Yaquinto - RPG drawing on 4000 B.C. to 1000 A.D. Earth legends.",
                "Mechanical Dream by SteamLogic",
                "MEGA Role-Playing System",
                "Middle Earth Role Play - based on the fantasy works of J. R. R. Tolkien",
                "Midgard - the oldest German fantasy RPG",
                "Mistborn Adventure Game - based on the Mistborn book series by Brandon Sanderson",
                "Monastyr (Polish), Monastery by Portal",
                "Mouse Guard - based on comic book series of the same name by David Petersen where all characters are mice and monsters are other animals.",
                "Multiverser by E.R. Jones and M. Joseph Young",
                "MYFAROG (Mythic Fantasy Roleplaying Game)",
                "Mystos: The Roleplaying Game",
                "Mythworld",
                "Night Wizard! (Japanese) - wizards in contemporary",
                "Nobilis by R. Sean Borgstrom",
                "OSRIC",
                "Palladium Fantasy Role-Playing Game (1983, 1996) - Created by Kevin Siembieda, published by Palladium Books",
                "Pathfinder Roleplaying Game by Paizo Publishing",
                "Phantasy Conclave",
                "Powers and Perils - by Avalon Hill",
                "Rêve: the Dream Ouroboros by Denis Gerfaud (french, Rêve de Dragon)",
                "The Riddle of Steel by Driftwood Publishing",
                "RMFRP (Rolemaster Fantasy Role Playing) by Iron Crown Enterprises - fully expandable and customizable rules system",
                "RuneQuest originally by Chaosium, later by Avalon Hill and currently by Mongoose Publishing",
                "Scion by White Wolf Publishing",
                "Sengoku: Chanbara Roleplaying in Feudal Japan by Gold Rush Games",
                "Seventh Sea Swashbuckling Adventure and sorcery by Alderac Entertainment Company",
                "The Shadow of Yesterday by Clinton R. Nixon",
                "Shard RPG (anthropomorphic heroic fantasy) by Shard Studios",
                "Skyrealms of Jorune (or just \"Jorune\")",
                "The Slayers d20 by Guardians of Order",
                "Sphinx",
                "Stormbringer by Chaosium, based on Michael Moorcock's Elric of Melniboné stories",
                "Swordbearer by Heritage Games and Fantasy Games Unlimited",
                "Sword World RPG (Japanese)",
                "Talislanta by Bard Games",
                "Tormenta Brazilian RPG by Marcelo Cassaro, J.M. Trevisan, Saladino",
                "Tribe 8 by Dream Pod 9",
                "Tunnels and Trolls by Flying Buffalo",
                "Trollbabe a game by Ron Edwards (game designer)",
                "Warcraft: The Roleplaying Game by White Wolf Publishing—a roleplaying game book based on the popular computer game by Blizzard Entertainment",
                "Warhammer Fantasy Roleplay by Games Workshop",
                "Weapons of the Gods by Eos Press - a wuxia-style game based on the manhua comic of the same name.",
                "What Price Glory?!",
                "The Wheel of Time Roleplaying Game - based on The Wheel of Time novel series by author Robert Jordan",
                "Wiedźmin (Polish) by MAG (game)",
                "Wizards' Realm",
                "World Tree—roleplaying in a high-magic, highly civilized world populated by many sentient species, none of them human.",
                "Historical/period adventure[edit]",
                "Aces & Eights - Kenzer & Company - Wild West alternate history RPG",
                "Adventure! - Pulp adventure by White Wolf Publishing",
                "The Adventures of Indiana Jones Role-Playing Game by TSR - based on the Indiana Jones films",
                "Boot Hill - TSR - Wild West adventure",
                "Bushido - samurai RPG",
                "d20 Past by Wizards of the Coast",
                "Daredevils - Pulp adventure",
                "Dark Ages (World of Darkness)",
                "Deadlands: The Weird West",
                "Dogs in the Vineyard - loosely based on the Mormon State of Deseret in pre-statehood Utah by Lumpley Games",
                "Draug - Norwegian RPG set during the Napoleonic wars. Themes: the early national movement and folklore and superstition, based on the FUDGE engine.",
                "Dzikie Pola (Wild Fields), a set in 17th century Polish-Lithuanian Commonwealth",
                "En Garde! - Duellists from 17th century France published by Game Designers' Workshop and SFC Press.",
                "Fantasy Imperium - An Interactive Storytelling Game of Historical Fantasy by Shadowstar Games, Inc.",
                "Forgotten Futures",
                "Gangbusters by TSR - 1930s urban crime adventure",
                "Hollow Earth Expedition by Exile Games Studio - Pulp adventures in the Hollow Earth",
                "Justice, Inc. by Hero Games - 1930s Pulp fiction oriented adventure",
                "Pendragon (or King Arthur Pendragon) Arthurian legend",
                "Sine Requie - Italian horror role-playing game.",
                "Space 1889 by Game Designers' Workshop - Victorian Era Sci-Fi",
                "Spirit of the Century - Pulp adventure",
                "Tibet -Historical fantasy set in Tibet circa 1959 during the Chinese invasion. Vajra Enterprises.",
                "Twilight 2000 by GDW(1984)",
                "Two Fisted Tales\" by Precis Intermedia Games -1930s Pulp fiction oriented adventure",
                "Valley of the Pharaohs (1983) - Created by Matthew Balent, published by Palladium Books",
                "Vampire: The Dark Ages",
                "Victorian Age: Vampire",
                "Victoriana By Cubicle 7. Alternate history, magic, and fantasy races.",
                "Werewolf: The Wild West",
                "The World of Indiana Jones by West End Games",
                "Yarr! Pirate RPG By BD Games. Historical Fantasy set in the age of Piracy. A rules-light game for children, beginners, and veteran players alike.",
                "Horror[edit]",
                "All Flesh Must Be Eaten - Zombie survival horror game by Eden Studios, Inc.",
                "Attack of the Humans",
                "Beyond the Supernatural (1987, 2005) - Created by Randy McCall and Kevin Siembieda, published by Palladium Books",
                "Buffy the Vampire Slayer - based on the Buffy the Vampire Slayer TV show by Eden Studios",
                "Bureau 13: Stalking the Night Fantastic by Tri Tac Games",
                "Call of Cthulhu - based on the works of H. P. Lovecraft",
                "Chaos Realms: Created by Johnathan Nicolosi, published by Chaotic Productions LLC",
                "Chill",
                "Dark Conspiracy",
                "Deadlands: The Weird West",
                "Dead Inside (game) - A small-press RPG where the characters attempt to rebuild their lost souls through selfless and noble actions (and get superhuman powers along the way)",
                "Dead Reign—The Zombie Apocalypse (2008) - Created by Josh Hilden and Joshua Sanford, published by Palladium Books",
                "Dread - A small-press RPG from The Impossible Dream that uses a tower of stacked blocks for action resolution.",
                "Dread: The First Book of Pandemonium",
                "The Everlasting (role-playing game) by Visionary Entertainment Studios Inc",
                "Kult - A Swedish game of Kabbalistic and gnostic origins; The tag line is \"Death is only the beginning\", and the game is widely perceived as one of the darkest RPGs ever created.",
                "Little Fears - The Roleplaying Game of Childhood Terror",
                "Malefices - A French game of historical horror and suspense set during the Belle Époque (1870-1914).",
                "My Life with Master An independently-published comic horror game.",
                "Necroscope Published by West End Games based on Brian Lumleys' world of the Necroscope books.",
                "Nephilim by Chaosium",
                "Nightbane (1995) - Created by C. J. Carella, published by Palladium Books",
                "Noctum",
                "Over the Edge",
                "Sine Requie - Italian horror role-playing game.",
                "Sorcerer (role-playing game) by Ron Edwards",
                "Trail of Cthulhu by Pelgrane Press",
                "Unknown Armies",
                "The Whispering Vault - an RPG about god-hunting",
                "WitchCraft RPG by Eden Studios",
                "World of Darkness product line by White Wolf Publishing",
                "Vampire: The Masquerade",
                "Werewolf: The Apocalypse",
                "Mage: The Ascension",
                "Wraith: The Oblivion",
                "Changeling: The Dreaming",
                "Demon: The Fallen",
                "Mummy: The Resurrection",
                "Vampire: Kindred of the East",
                "Hunter: The Reckoning",
                "Victorian Age: Vampire",
                "Werewolf: The Wild West",
                "Mage: The Sorcerer's Crusade",
                "Wraith: The Great War",
                "Vampire: The Dark Ages",
                "Dark Ages (World of Darkness)",
                "Orpheus (role-playing game)",
                "World of Darkness (new) new product line by White Wolf Publishing",
                "Vampire: The Requiem",
                "Werewolf: The Forsaken",
                "Mage: The Awakening",
                "Promethean: The Created",
                "Changeling: The Lost",
                "Hunter: The Vigil",
                "Geist: The Sin-Eaters",
                "Humor and satire[edit]",
                "Bunnies and Burrows",
                "Diana: Warrior Princess",
                "Fanhunter Spanish game based on the series of comics of the same name",
                "Ghostbusters RPG based on the Ghostbusters film series.",
                "HackMaster",
                "Human Occupied Landfill",
                "In Nomine Satanis / Magna Veritas (french) by Croc (Siroz) (satirical gang and spy wars involving angels and demons in the contemporary world)",
                "kill puppies for satan",
                "Kobolds Ate My Baby",
                "Macho Women with Guns",
                "Monsters and Other Childish Things",
                "Munchkin",
                "Murphy's World",
                "Ninja Burger",
                "Pandemonium",
                "Paranoia",
                "Risus",
                "Tales from the Floating Vagabond",
                "Teenagers from Outer Space, an anime based RPG.",
                "Toon - Cartoon adventure inspired by the classic cartoon series from Warner Brothers and MGM",
                "TWERPS",
                "Underground",
                "Science fiction[edit]",
                "2300 AD - hard science fiction",
                "9th Generation",
                "After the Bomb - mutant animals in post-apocalyptic setting",
                "Aftermath! - post-apocalyptic",
                "Albedo - based on the furry comic book stories by Steve Gallacci",
                "Alternity",
                "Battlelords of the 23rd Century - space opera",
                "Blackwatch",
                "Blue Planet - environmentally themed; set in a water planet",
                "Buck Rogers XXVC",
                "The Confederate Rangers",
                "Conspiracy X - aliens, UFOs, and government coverups",
                "C°ntinuum - time travel adventure",
                "Cthulhutech - Cthulhu Mythos with mecha, horror, magic and futuristic action",
                "Cybergeneration - follow-up to Cyberpunk 2020",
                "Cyberpunk 2020 - based on the Mirrorshades authors",
                "Cyberspace - cyberpunk adaptation of Space Master",
                "D6 Space",
                "d20 Future - accessory for d20 Modern game",
                "Darwin's World - post-apocalyptic",
                "Diaspora",
                "The Doctor Who Role Playing Game",
                "Deadlands: Hell on Earth - post-apocalyptic western",
                "Eclipse Phase - hard science fiction",
                "Etherscope - steampunk",
                "Ex Machina - cyberpunk",
                "Fading Suns - space opera",
                "Faith: the Sci-Fi RPG - hard science fiction",
                "Fringeworthy - alternate history adventure",
                "FTL:2448",
                "Gamma World - post-apocalyptic fantasy, 2nd game from the makers of Metamorphosis Alpha",
                "GURPS Cyberpunk",
                "GURPS Space",
                "Halcyon - cyberpunk",
                "Heavy Gear - mecha",
                "Incursion",
                "Interface Zero 2.0 - cyberpunk",
                "Jeremiah: The Roleplaying Game - based on the TV series",
                "Jorune - science fantasy",
                "Jovian Chronicles - mecha and epic space battles",
                "Judge Dredd - based on the future law enforcement comic book series",
                "Legionnaire - based on the Renegade Legion space opera strategy boardgames",
                "Living Steel",
                "Macross II - based on the mecha anime film and manga",
                "Mach: The First Colony",
                "The Mechanoid Invasion",
                "MechWarrior - based on the BattleTech mecha wargame",
                "Mekton - inspired by mecha anime",
                "The Metabarons Roleplaying Game - based on the Metabarons space opera comic book series",
                "Metamorphosis Alpha - the first science fiction role-playing game",
                "The Morrow Project - post-apocalyptic",
                "Multiverser",
                "Mutant - post-apocalyptic",
                "Mutant Chronicles - successor to Mutant",
                "Mutazoids",
                "Neuroshima (Polish) - post-apocalyptic",
                "Paranoia - a satire of dystopian futures",
                "Pax Draconis - space opera",
                "Phoenix Command",
                "Prime Directive - set in the Star Trek-derived Star Fleet Universe",
                "Reich Star alternate history; fight Nazis in space",
                "Rifts - post-apocalyptic",
                "Rifts Chaos Earth - spinoff of Rifts",
                "Ringworld - based on Larry Niven's novels",
                "The Robotic Age - futuristic cyberpunk by True In One[1]",
                "Robotech - based on the Robotech mecha anime television series",
                "Second Dawn",
                "Serenity - based on the TV series Firefly and the film Serenity",
                "Shatterzone - space opera",
                "Shock: Social Science Fiction",
                "Skyrealms of Jorune - science fantasy",
                "SLA Industries",
                "Space 1889 - steampunk",
                "Space Infantry",
                "Space Master - adaptation of Rolemaster",
                "Space Opera",
                "Spaceship Zero",
                "Splicers",
                "Star Frontiers",
                "Stargate SG-1",
                "Star Hero - adaptation of the Hero System",
                "Starship Troopers - based on the novel Starship Troopers and related movies and cartoon series",
                "Star Trek: The Role Playing Game (FASA)",
                "Star Trek Roleplaying Game (Decipher)",
                "Star Trek: The Next Generation Role-playing Game",
                "Star Wars: The Roleplaying Game (West End Games)",
                "Star Wars Roleplaying Game (Wizards of the Coast)",
                "Star Wars Roleplaying Game (Fantasy Flight Games)",
                "Star Wreck Roleplaying Game - comedy; based on the Star Wreck fan film series",
                "Systems Failure - post-apocalyptic",
                "Tales from the Floating Vagabond - comedy",
                "Time Lord - a Doctor Who game",
                "Tokyo NOVA (Japanese) - cyberpunk",
                "Transhuman Space - hard science fiction",
                "Traveller",
                "Traveller: 2300 - hard science fiction",
                "Trinity",
                "Twilight 2000 - survivors in the aftermath of World War III",
                "Uncharted Worlds - a space opera pen-and-paper roleplaying game",
                "Underground - future satire featuring renegade superheroes",
                "Universe",
                "Warhammer 40,000 Roleplay - space fantasy based on the Warhammer 40,000 wargame",
                "Wraeththu - based on the science fantasy novels of Storm Constantine",
                "World of Synnibarr",
                "Worlds of Rage - science fiction with a gothic horror influence",
                "Superhero[edit]",
                "Aberrant by White Wolf Publishing",
                "Big Bang Comics",
                "Blood of Heroes",
                "Brave New World",
                "Capes",
                "Cartoon Action Hour by Spectrum Games",
                "Challengers",
                "Champions by Hero Games",
                "City of Heroes Roleplaying Game",
                "DC Heroes by Mayfair Games",
                "DC Universe Roleplaying Game by West End Games",
                "Double Cross",
                "Enforcers",
                "Golden Heroes by Games Workshop",
                "GURPS Supers by Steve Jackson Games",
                "Heroes Unlimited (1984, 1998) - Created by Kevin Siembieda, published by Palladium Books",
                "Marvel Heroic Roleplaying by Margaret Weis Productions",
                "Marvel Universe Roleplaying Game by Marvel Publishing Group",
                "Marvel Super Heroes Adventure Game by TSR",
                "Marvel Super Heroes Role-Playing Game by TSR",
                "Mutants & Masterminds by Green Ronin Publishing",
                "Omlevex",
                "Silver Age Sentinels by Guardians of Order",
                "Superworld by Chaosium",
                "Teenage Mutant Ninja Turtles & Other Strangeness (1985) - Created by Erick Wujcik, published by Palladium Books under license from Mirage Studios; based on the original comic book series by Kevin Eastman and Peter Laird",
                "Trinity",
                "Truth and Justice by Atomic Sock Monkey Press",
                "Underground by Mayfair Games",
                "Villains and Vigilantes by Fantasy Games Unlimited",
                "Wild Talents",
                "With Great Power...",
                "Multi-genre and cross-genre[edit]",
                "CthulhuTech by Wildfire - H.P. Lovecraft's horror with Mecha and Anime influences",
                "DragonMech (steampunk/fantasy)",
                "Dragonstar (science fiction/fantasy)",
                "Godlike (superhero/alternate history)",
                "Immortal: The Invisible War - Created by Ron Valerhon. Immortal mixes modern fantasy, horror, science fiction and world mythology.",
                "Iron Kingdoms - Based on the Warmachine and Hordes universe by Privateer Press (steampunk/fantasy)",
                "Lords of Creation (1983) by Avalon Hill Inc.",
                "Numenera (2013) by Monte Cook Games (science fantasy)",
                "Rifts (1990) - Created by Kevin Siembieda, published by Palladium Books",
                "Sanctum Polis - Rest Eternal Memory Caxton must travel inside of dreams to discover who is responsible for the serial murders taking place at Solaris Notre University.",
                "Shadowrun (cyberpunk fantasy)",
                "Terra the Gunslinger (Japanese) - western and steampunk, use playing cards instead of dice",
                "TORG - published by West End Games",
                "Worlds of Wonder by Chaosium",
                "Zen and the Art of Mayhem",
                "Other genres[edit]",
                "Big Eyes, Small Mouth by Guardians of Order - anime based RPG",
                "Omega Connection by Mark McClane",
                "Pitfalls and Penguins by Team Snow Day",
                "Primetime Adventures by Dog-eared Design",
                "Universal role-playing systems[edit]",
                "Active Exploits",
                "Amazing Engine",
                "Basic Role-Playing by Chaosium",
                "Budding Heroes[2] by Cloak Gaming",
                "CORPS by Blacksburg Tactical Research Center",
                "Cortex System Roleplaying Game",
                "d6 System - West End Games' in-house system, based on the Star Wars RPG",
                "d20 System - based on Dungeons & Dragons 3rd Edition rules",
                "EABA by Blacksburg Tactical Research Center",
                "FATE - Fantastic Adventures in Tabletop Entertainment based on the FUDGE engine",
                "FUDGE - Free, Universal, Do-it-Yourself Gaming Engine by Steffan O'Sullivan",
                "Fuzion",
                "GURPS - Generic Universal Role Playing System by Steve Jackson (US)",
                "Hero System by Hero Games",
                "Insight RPG System by NEVR",
                "Masterbook by West End Games",
                "OGL System by Mongoose Publishing",
                "Risus",
                "Roleplayer",
                "SAGA System - published by TSR",
                "Savage Worlds",
                "Storyteller System - published by White Wolf Publishing uses D10 only. System used in both World of Darkness and the Trinity Universe",
                "Tri-Stat dX - universal system used in Big Eyes, Small Mouth",
                "True20 - Published by Green Ronin Publishing",
                "TWERPS",
                "Unisystem by Eden Studios, Inc.",
                "Universalis by Ramshead Publishing"
            };
            #endregion

            int count = 1;
            foreach(string navn in titel)
            {
                Bog bog = AktivFactory.HentAktivFactory().SkabNyBog(count, navn, hentFornavn() + " " + hentFornavn() + "sen", genre.ElementAt(random.Next(0, genre.Count - 1)), "Subkategori", "RPG X", "Data");
                _bogListe.Add(bog);
                count++;
            }
        }
        private void randomBrætspil()
        {
            for (int i = 0; i < 100; i++)
            {
                Brætspil aktiv = AktivFactory.HentAktivFactory().SkabNyBrætspil(i + 1, hentFornavn(i), "Menneske", null);
                _brætspilsListe.Add(aktiv);
            }
        }
        private void randomUdstyr()
        {
            for (int i = 0; i < 100; i++)
            {
                Udstyr udstyr = AktivFactory.HentAktivFactory().SkabNytUdstyr(i + 1, hentFornavn(i), "Menneske", null);
                _udstyrsListe.Add(udstyr);
            }
        }
        private void randomLokale()
        {
            for (int i = 0; i < 100; i++)
            {
                Lokale aktiv = AktivFactory.HentAktivFactory().SkabNytLokale(i + 1, hentFornavn(i), hentFornavn(i) + "vej", null, null);
                _lokaleListe.Add(aktiv);
            }
        }

        private void testBruger()
        {
            Medlem admin = new Medlem(1, "Admin", "Adminsen", "admin", "admin", "admin@admin.com", Medlem.MedlemType.Bestyrelse);
            Medlem bruger = new Medlem(2, "Medlem", "Medlemsen", "medlem", "medlem", "medlem@medlem.dk", Medlem.MedlemType.Bruger);

            _medlemListe.Add(admin);
            _medlemListe.Add(bruger);
        }

        private string hentFornavn(int index = -1)
        {
            List<string> navn = new List<string> {
                "Sofia",
                "Willia",
                "Alma",
                "Luca",
                "Freja",
                "Malth",
                "Anna",
                "Noa",
                "Ella",
                "Emi",
                "Emma",
                "Victo",
                "Laura",
                "Osca",
                "Clara",
                "Alfre",
                "Maja",
                "Olive",
                "Alberte",
                "Frederi",
                "Ida",
                "Car",
                "Agnes",
                "Elia",
                "Liva",
                "Villad",
                "Isabella",
                "Magnu",
                "Josefine",
                "Anto",
                "Karla",
                "Christia",
                "Mathilde",
                "Alexande",
                "Emilie",
                "Augus",
                "Victoria",
                "Mikke",
                "Olivia",
                "Lia",
                "Caroline",
                "Valdema",
                "Lærke",
                "Noh",
                "Sofie",
                "Feli",
                "Frida",
                "Mad",
                "Sara",
                "Akse",
                "Emily",
                "Joha",
                "Lily",
                "Stor",
                "Mille",
                "Alber",
                "Ellen",
                "Benjami",
                "Marie",
                "Theodo",
                "Astrid",
                "Ada",
                "Naja",
                "Mathia",
                "Esther",
                "Arthu",
                "Luna",
                "Marcu",
                "Nora",
                "Tobia",
                "Aya",
                "Phili",
                "Rosa",
                "Vigg",
                "Lea",
                "Jaco",
                "Johanne",
                "The",
                "Asta",
                "Ellio",
                "Vigga",
                "Sebastia",
                "Liv",
                "Mariu",
                "Nanna",
                "Tho",
                "Celina",
                "Laug",
                "Merle",
                "Sande",
                "Vilma",
                "Laurit",
                "Silje",
                "Villu",
                "Filippa",
                "Jona",
                "Julie",
                "Ott",
                "Signe",
                "Silas"
            };

            return index > -1 ? navn[index] : navn[random.Next(0, navn.Count - 1)];
        }
        #endregion
        public void checkLister()
        {
            
        }
    }//Klasse
}//Namespace
