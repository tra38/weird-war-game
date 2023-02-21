// See https://aka.ms/new-console-template for more information
using HybridWar;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;

Console.WriteLine("Hello, World!");

var turnCounter = 1;

//stats
var technology = 10;
var social_cohesion = 10; //your HP, if it goes to ze0o, you lose
var cultural_soft_power = 10;
var military_hard_power = 10;

var nuclearWar = false;

var terranIdeology = GovernmentGenerator.GetRandomValue<Ideology>();
var terranStructure = GovernmentGenerator.GetRandomValue<Structure>();

var alienSpecies = GovernmentGenerator.GetRandomValue<Alien>();

var govPrefix = "";
var govType = "";

var alienName = "";
void UpdatePlayerStats()
{
    switch (terranIdeology)
    {
        case Ideology.Pious:
            Console.WriteLine("Traditional religions have unified humanity for millennia, so it is natural that humans would turn to it in times of");
            Console.WriteLine("peril. Pious ideology emphasizes religion and moral values over other traits, and may");
            Console.WriteLine("prioritize military hard power to defend its religious beliefs.");
            Console.WriteLine("A side that adopts a theocratic ideology could see a boost in military hard power and");
            Console.WriteLine("cultural soft power, but may struggle with technology and social cohesion due to a focus on religious orthodoxy.");
            military_hard_power += 1;
            cultural_soft_power += 1;
            social_cohesion -= 1;
            technology -= 1;
            govPrefix = "Theocratic";
            break;
        case Ideology.Environmentalist:
            Console.WriteLine("An environmentalist ideology prioritizes cultural soft power and environmental sustainability");
            Console.WriteLine("over other traits, and may de-emphasize military hard power. A side that adopts an environmentalist");
            Console.WriteLine("ideology might see a boost in cultural soft power, but could struggle with military hard power due to a lack of emphasis on defense.");
            military_hard_power -= 2;
            cultural_soft_power += 2;
            govPrefix = "Ecologist";
            break;
        case Ideology.Socialist:
            Console.WriteLine("Socialist ideology prioritizes social cohesion and equality over other traits, and may downplay the");
            Console.WriteLine("importance of military hard power. A side that adopts a socialist ideology could see a boost in social cohesion,");
            Console.WriteLine("but may struggle with technology and military hard power due to a lack of emphasis on individual innovation");
            Console.WriteLine("and competition.");
            social_cohesion += 2;
            technology -= 1;
            military_hard_power -= 1;
            govPrefix = "Workers'";
            break;
        case Ideology.Technocratic:
            Console.WriteLine("Technocrats believe that the best way to achieve progress and solve societal problems is through the use of advanced technology,");
            Console.WriteLine("and they view technical expertise as the most important qualification for leadership positions. A side that adopts a technocratic");
            Console.WriteLine("ideology might see a boost in technology, but will downplay the importance of social cohesion and cultural soft power.");
            technology += 2;
            social_cohesion -= 1;
            cultural_soft_power -= 1;
            govPrefix = "Technocratic";
            break;
        case Ideology.Free_Market:
            Console.WriteLine("A free market ideology believe that the free market should be allowed to operate with minimal government intervention");
            Console.WriteLine("and regulation, and view entrepreneurship and business acumen as the most important qualifications for leadership positions.");
            Console.WriteLine("Their investments in technology is legendary, but they also suffer from low social cohesion, as citizens who feel that they are");
            Console.WriteLine("being left behind by the pursuit of wealth and economic growth at the expense");
            Console.WriteLine("of other values and priorities.");
            technology += 2;
            social_cohesion -= 2;
            govPrefix = "Libertarian";
            break;
        case Ideology.Humanist:
            Console.WriteLine("Humanism emphasizes the unity and solidarity of all humans");
            Console.WriteLine("under a single a shared identity and culture, and view those seeking to disrupt this shared identity and culture");
            Console.WriteLine("as a threat to the unity of Terra. They emphasize a strong military over other traits. While their military hard");
            Console.WriteLine("power is admirable, they suffer in other areas like social cohesion and cultural soft power due to an emphasis on");
            Console.WriteLine("a narrow definition of species unity.");
            military_hard_power += 2;
            cultural_soft_power -= 1;
            social_cohesion -= 1;
            govPrefix = "Humanist";
            break;
        default:
            throw new Exception();
    }

    switch (terranStructure)
    {
        case Structure.Utopia:
            Console.WriteLine("It is easy for humans to experience infinite bliss and a high standard of living -");
            Console.WriteLine("provide them with an endless supply of drugs and VR simulations. Thus, a utopia is");
            Console.WriteLine("formed without any meaningful sacrifices on the part of the ruling class.");
            Console.WriteLine("Utopias invest heavily in cultural soft power, to expand their power and territory to 'unenlightened lands'.");
            cultural_soft_power += 1;
            govType = "Utopia";
            break;
        case Structure.Federation:
            Console.WriteLine("A federation is a government made up of several smaller states or regions, each with a certain degree of autonomy.");
            Console.WriteLine("They prioritize social cohesion, as they emphasize cooperation and diplomacy between member states.");
            social_cohesion += 1;
            govType = "Federation";
            break;
        case Structure.Hivemind:
            Console.WriteLine("A hivemind is a government in which all individuals are connected and controlled by a 'social network'. Moderator AIs");
            Console.WriteLine("use echo chambers and demagoguery to manufacture social consensus on key issues. The AIs in charge of society prioritize");
            Console.WriteLine("technological research, as it helps promote efficiency and conformity.");
            technology += 1;
            govType = "Hive";
            break;
        case Structure.Junta:
            Console.WriteLine("Meaningful participation in the government is limited to individuals who successfully");
            Console.WriteLine("complete two years of military service. The society venerates the military, and the");
            Console.WriteLine("motto 'Service equals citizenship' is often used to justify investments in military hard power.");
            military_hard_power += 1;
            govType = "Junta";
            break;
        case Structure.Republic:
            Console.WriteLine("The government allows all its people to participate in governance, allowing them to engage in");
            Console.WriteLine("endless debates to decide on the best course of action. Though the debates leads to a lack of social");
            Console.WriteLine("cohesion, it also encourages technological innovation.");
            social_cohesion -= 1;
            technology += 2;
            govType = "Republic";
            break;
        case Structure.Empire:
            Console.WriteLine("An empire is a government where power is centralized into the hands of a single ruling family");
            Console.WriteLine("who relies on military hard power and cultural soft power. They often use military conquest");
            Console.WriteLine("and cultural influence to expand their power and territory. Empires, however, are dependent on social control");
            Console.WriteLine("and thus restricts research into 'disruptive' technologies.");
            military_hard_power += 1;
            cultural_soft_power += 1;
            technology -= 1;
            govType = "Empire";
            break;
    }

    Console.WriteLine($"Final GovType: {govPrefix} {govType}");

    Console.ReadLine();

    Console.Clear();
}

void GenerateAlienDescriptions()
{
    switch (alienSpecies)
    {
        case Alien.Transcendents:
            Console.WriteLine("Transcendents");
            Console.WriteLine("An advanced, alturistic alien civilization that has achieved a higher level of consciousness or understanding of the universe.");
            Console.WriteLine("The aliens describe themselves as the custodians of the universe, tasked with promoting progress and understanding wherever they can.");
            Console.WriteLine("They see humanity as a primitive species that is need of guidance and enlightenment. While guidance and enlightenment may be");
            Console.WriteLine("nice in theory, we do not know the values of these Transcendents, or the nature of their knowledge. They may have");
            Console.WriteLine("ulterior motives for their actions, destabilize the existing power structure, threaten our way of life, and ");
            Console.WriteLine("");
            Console.WriteLine("If we want to be enlightened, we must pursue it on our own.");
            Console.WriteLine("We are a species that do not trust gods.");
            alienName = "Transcendents";
            break;
        case Alien.Coalition:
            Console.WriteLine("Coalition");
            Console.WriteLine("This is a group of alien races that are connected by a vast interstellar network of trade and cultural exchange.");
            Console.WriteLine("They have a relentless focus on commerce and cultural exchange, while retaining deep respect of tradition and history of its");
            Console.WriteLine("member species. They are wary of humanity and may see them as a potential threat to their own power and security.");
            Console.WriteLine("Humanity must be deterred to ensure the survival of the Coalition.");
            alienName = "Coalition";
            break;
        case Alien.Pioneers:
            Console.WriteLine("Pioneers");
            Console.WriteLine("This is a federation of several alien species that prioritize exploration and the acquisition of knowledge.");
            Console.WriteLine("They are driven by a sense of adventure and discovery, and value individual freedom and innovation.");
            Console.WriteLine("They are welcoming to other civilizations and value individual freedom, but also have a strong sense of national pride and identity");
            Console.WriteLine("They view humans as a potential resource to be assimilated or destroyed.");
            alienName = "Pioneers";
            break;
    }
}


//Game Cycle
//1. Both sides attack.
//2. The other two traits go up by 1 because of cooperation.

//3. A crisis occurs which affects DEFCON.
//DEFCON indicates the probablity of a nuclear war erupting, ending the game.
//The goal is to get your opponent's Cohesion to zero WITHOUT provoking a nuclear war.
//  (If you provoke a nuclear war, you lose. If you could convince your enemy into provoking a nuclear war, you win.)
//  (Need to provide a reasont to attack anything OTHER than Cohesion)
//Alternativley:
//A crisis can occur, you can either let the random event happen, or object, thereby causing a crisis that can lead to nuclear war.
//As you escalate, you start sacrificing some of your stats in the process to indicate your Resolve and force the other side
//to concede.

//Some ideas

//ChatGPT: Deciding how the "hybrid war" ends in your game depends on the ultimate goal you have in mind for the players. One option is to have the game continue
//until one side reaches a predetermined level of superiority in all four traits, resulting in a victory for that side. Another option is to have the game
//continue until one side reaches a predetermined level of power in three out of the four traits, which would also result in a victory for that side.

//If you want to add more complexity and variation to the game, you can introduce additional win conditions that could result in a stalemate, a tie, or
//a mutually assured destruction scenario where both sides lose. For instance, you could set up a situation where a crisis occurs that neither side is
//equipped to handle, leading to a collapse in both sides' power, or a scenario where both sides' military hard power reaches a critical threshold that
//triggers a mutually assured destruction outcome.

//Ultimately, it's up to you to decide how the game should end based on your desired level of complexity and the types of outcomes you want players to
//experience. You may also want to test the game with a variety of players to get feedback and see how they respond to different outcomes.

//Tariq:
//For now, let's have it that one side wins if they reach a predetermined level of power in three out of the four traits.

//The ideologies of Side A and Side B will be randomized. Using the mechanics we decide, come up with five ideologies and their impact on gameplay.

//ChatGPT:
//Sure, here are five different ideologies that could impact the gameplay of the "hybrid war" game:

//    Nationalism: A nationalist ideology emphasizes the importance of national identity and unity, and may prioritize military hard power over other traits. A side that adopts a
//    nationalist ideology might see a boost in their military hard power, but could suffer in other areas like social cohesion and cultural soft power due to an emphasis on a
//    narrow definition of national identity.

//    Communism: A communist ideology prioritizes social cohesion and equality over other traits, and may downplay the importance of military hard power. A side that adopts a
//    communist ideology could see a boost in social cohesion, but may struggle with technology and military hard power due to a lack of emphasis on individual innovation
//    and competition.

//    Capitalism: A capitalist ideology prioritizes technological innovation and economic growth over other traits, and may prioritize military hard power to protect its
//    economic interests. A side that adopts a capitalist ideology could see a boost in technology and military hard power, but may struggle with social cohesion and
//    cultural soft power due to a focus on individual achievement and competition.

//    Environmentalism: An environmentalist ideology prioritizes cultural soft power and environmental sustainability over other traits, and may de-emphasize military
//    hard power. A side that adopts an environmentalist ideology might see a boost in cultural soft power, but could struggle with military hard power due to a
//    lack of emphasis on defense.

//    Theocracy: A theocratic ideology emphasizes religion and moral values over other traits, and may prioritize military hard power to defend its religious beliefs.
//    A side that adopts a theocratic ideology could see a boost in military hard power and cultural soft power, but may struggle with technology and social
//    cohesion due to a focus on religious orthodoxy.

//Each of these ideologies could affect the gameplay by providing different starting points and goals for each side, and by affecting the balance between the four traits.
//Players would need to carefully consider the strengths and weaknesses of their chosen ideology and make strategic decisions about how to boost certain traits and
//counter the actions of their opponent.

string CurrentScore(int number)
    => $"(current score: {number})";

bool GameEnds()
{
    var list = new List<bool>
    {
        technology >= 12,
        social_cohesion >= 12,
        cultural_soft_power >= 12,
        military_hard_power >= 12
    };

    return list.Count(argument => argument == true) >= 3;
}

string Superiority(int number)
{
    if (number >= 12)
        return " (Superiority)";
    else
        return "";
}

string GetNationFocus()
{
    Console.WriteLine($"Turn {turnCounter} of the {govPrefix} {govType}");
    Console.WriteLine();
    Console.WriteLine("Decide what you want to focus on this turn.");
    Console.WriteLine($"A - Technology {CurrentScore(technology)}{Superiority(technology)}");
    Console.WriteLine($"B - Social Cohesion {CurrentScore(social_cohesion)}{Superiority(social_cohesion)}");
    Console.WriteLine($"C - Cultural Soft Power {CurrentScore(cultural_soft_power)}{Superiority(cultural_soft_power)}");
    Console.WriteLine($"D - Military Hard Power {CurrentScore(military_hard_power)}{Superiority(military_hard_power)}");

    var userInput = Console.ReadLine();

    var validInputs = new List<string> { "A", "B", "C", "D" };
    if (userInput == null || !validInputs.Contains(userInput))
    {
        Console.WriteLine("Invalid solution. Try again.");
        return GetNationFocus();
    }
    else
    {
        return userInput;
    }
}

void UpdateValue(string userInput)
{
    switch (userInput)
    {
        case "A":
            technology += 1;
            break;
        case "B":
            social_cohesion += 1;
            break;
        case "C":
            cultural_soft_power += 1;
            break;
        case "D":
            military_hard_power += 1;
            break;
        default:
            Console.WriteLine("Invalid solution. Try again.");
            GetNationFocus();
            break;
    }
}

List<string> GetPossibleEnemyTargets(string userInput)
{
    var validEnemyTargets = new List<string>();
    validEnemyTargets = userInput switch
    {
        "A" => new List<string> { "social_cohesion", "cultural_soft_power", "military_hard_power" },
        "B" => new List<string> { "technology", "cultural_soft_power", "military_hard_power" },
        "C" => new List<string> { "technology", "social_cohesion", "military_hard_power" },
        "D" => new List<string> { "technology", "social_cohesion", "cultural_soft_power" },
        _ => throw new Exception(),
    };
    return validEnemyTargets;
}

void Attack(string target)
{
    switch (target)
    {
        case "technology":
            Console.WriteLine("The enemy attacks your technology!");
            technology -= 1;
            break;
        case "social_cohesion":
            Console.WriteLine("The enemy attacks your social cohesion!");
            social_cohesion -= 1;
            break;
        case "cultural_soft_power":
            Console.WriteLine("The enemy attacks your cultural soft power!");
            cultural_soft_power -= 1;
            break;
        case "military_hard_power":
            Console.WriteLine("The enemy attacks your military hard power!");
            military_hard_power -= 1;
            break;
    }
}

void AttackRandomTarget(List<string> array)
{
    Random rnd = new Random();
    var index = rnd.Next(array.Count);

    var target = array[index];

    Attack(target);
}

void YouCauseCrisis()
{
    var allPossibleTraits = new List<string> { "technology", "social_cohesion", "cultural_soft_power", "military_hard_power" };
    Dictionary<string, string> dictionary = new Dictionary<string, string>
    {
        { "technology", "A" },
        { "social_cohesion", "B" },
        { "cultural_soft_power", "C" },
        { "military_hard_power", "D" }
    };

    Random rnd = new Random();
    var index = rnd.Next(allPossibleTraits.Count);

    var target = allPossibleTraits[index];

    Console.WriteLine("You now have the right to conduct a crisis. You have a 75% of success.");
    Console.WriteLine($"If you succeed, you gain +1 to {target}");
    Console.WriteLine($"If you fail, the game ends in nuclear war.");
    Console.WriteLine("Do you wish to create a crisis? If so, type YES.");
    var crisisTriggered = Console.ReadLine();

    if (crisisTriggered == "YES")
    {
        //var d100 = rnd.Next(100);
        var d100 = 0;
        if (d100 <= 75)
        {
            Console.WriteLine("The enemy backs down! Horray for brinkmanship!");
            UpdateValue(dictionary[target]);
        }
        else
        {
            Console.WriteLine("Nuclear war triggered. Game ends.");
            nuclearWar = true;
        }
    }
}

void EnemyCauseCrisis()
{
    var allPossibleTraits = new List<string> { "technology", "social_cohesion", "cultural_soft_power", "military_hard_power" };

    Random rnd = new Random();
    var index = rnd.Next(allPossibleTraits.Count);

    var target = allPossibleTraits[index];

    Console.WriteLine($"The enemy has provoked a crisis. You gain -1 to {target}");
    Console.WriteLine("If you fight back, you have a 75% of success.");
    Console.WriteLine($"If you succeed, you stop the loss.");
    Console.WriteLine($"If you fail, the game ends in nuclear war.");
    Console.WriteLine("Do you wish to create a crisis? If so, type YES.");
    var crisisTriggered = Console.ReadLine();

    if (crisisTriggered == "YES")
    {
        //var d100 = rnd.Next(100);
        var d100 = 0;
        if (d100 <= 75)
        {
            Console.WriteLine("The enemy backs down! Horray for brinkmanship!");
        }
        else
        {
            Console.WriteLine("Nuclear war triggered. Game ends.");
            nuclearWar = true;
        }
    }
    else
    {
        Attack(target);
    }
}

UpdatePlayerStats();
Console.Clear();
GenerateAlienDescriptions();

Console.ReadLine();

Console.Clear();

Console.WriteLine($"One day, the {alienName} attacked, with the singular purpose of conquering humanity.");
Console.WriteLine("Will they succeed?");

while (!GameEnds() && !nuclearWar)
{
    var nationFocus = GetNationFocus();
    UpdateValue(nationFocus);
    Console.WriteLine("Now the enemy attacks one property that is left undefended!");
    AttackRandomTarget(GetPossibleEnemyTargets(nationFocus));
    YouCauseCrisis();
    EnemyCauseCrisis();
    turnCounter++;
}

if (GameEnds())
{
    Console.WriteLine("YOU ARE A SUPER PLAYER!");
}
else
{
    Console.WriteLine("The cockroaches speak highly of your trials!");
}

