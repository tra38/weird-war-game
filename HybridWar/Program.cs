// See https://aka.ms/new-console-template for more information

//"Sacred Defense Is Barbaric Aggression"
//https://globalaffairs-ru.translate.goog/articles/ih-varvarskaya-agressiya/?_x_tr_sl=ru&_x_tr_tl=en&_x_tr_hl=en&_x_tr_pto=wapp

using HybridWar;

//https://social.msdn.microsoft.com/Forums/vstudio/en-US/518bd41d-f344-4e00-b530-9fbea5c0b867/quottypewriterquot-like-effect-in-a-c-console-application?forum=csharpgeneral
void TypewriterEffect(string text)
{
    for (int i = 0; i < text.Length; i++)

    {
        Console.Write(text[i]);
        Thread.Sleep(10);
    }
}

TypewriterEffect("'Our sacred defense is their barbaric aggression.'--Zhu Huang, Leader of Terra");
Console.WriteLine();
TypewriterEffect("Fifty years after the unification of Terra under Zhu Huang, the Transcendants arrived.");
Console.WriteLine();
TypewriterEffect("They offer enlightenment. We refuse. We now wage a war against these aliens, for our very survival.");
Console.WriteLine();
TypewriterEffect("Yet, how do we wage such a war? Especially when it could lead to extiniction to both our sides?");
Console.WriteLine();
TypewriterEffect("Fight? Negotiate for a honorable peace that we can live with? Or appease the Transcendants?");
Console.WriteLine();

Console.Clear();

var turnCounter = 1;

//stats
var defaultEconomicBlockade = 10;
var economicBlockade = 10;

var defaultgeneralWeaponsEffectiveness = 10;
var generalWeaponsEffectiveness = 10;
var tacticalWeaponsBonus = 20;
var strategicWeaponsBonus = 40;

var defaultNegotiationOdds = 60;
var negotiationOdds = 60;

var defaultCostToSurrender = 25;
var costToSurrender = 25;

var terranIdeology = GovernmentGenerator.GetRandomValue<Ideology>();
var terranStructure = GovernmentGenerator.GetRandomValue<Structure>();

//var alienSpecies = GovernmentGenerator.GetRandomValue<Alien>();

var alienSpecies = Alien.Transcendents;

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
            Console.ReadLine();
            generalWeaponsEffectiveness += 10;
            negotiationOdds += 10;
            costToSurrender += 5;
            economicBlockade -= 10;
            govPrefix = "Divine";
            break;
        case Ideology.Environmentalist:
            Console.WriteLine("An environmentalist ideology prioritizes cultural soft power and environmental sustainability");
            Console.WriteLine("over other traits, and may de-emphasize military hard power. A side that adopts an environmentalist");
            Console.WriteLine("ideology might see a boost in cultural soft power, but could struggle with military hard power due to a lack of emphasis on defense.");
            generalWeaponsEffectiveness -= 20;
            negotiationOdds += 20;
            govPrefix = "Ecologist";
            break;
        case Ideology.Socialist:
            Console.WriteLine("Socialist ideology prioritizes social cohesion and equality over other traits, and may downplay the");
            Console.WriteLine("importance of military hard power. A side that adopts a socialist ideology could see a boost in social cohesion,");
            Console.WriteLine("but may struggle with technology and military hard power due to a lack of emphasis on individual innovation");
            Console.WriteLine("and competition.");
            costToSurrender -= 10;
            economicBlockade -= 10;
            generalWeaponsEffectiveness -= 10;
            govPrefix = "Workers'";
            break;
        case Ideology.Technocratic:
            Console.WriteLine("Technocrats believe that the best way to achieve progress and solve societal problems is through the use of advanced technology,");
            Console.WriteLine("and they view technical expertise as the most important qualification for leadership positions. A side that adopts a technocratic");
            Console.WriteLine("ideology might see a boost in technology, but will downplay the importance of social cohesion and cultural soft power.");
            economicBlockade += 20;
            costToSurrender += 5;
            negotiationOdds -= 10;
            govPrefix = "Technocratic";
            break;
        case Ideology.Free_Market:
            Console.WriteLine("A free market ideology believe that the free market should be allowed to operate with minimal government intervention");
            Console.WriteLine("and regulation, and view entrepreneurship and business acumen as the most important qualifications for leadership positions.");
            Console.WriteLine("Their investments in technology is legendary, but they also suffer from low social cohesion, as citizens who feel that they are");
            Console.WriteLine("being left behind by the pursuit of wealth and economic growth at the expense");
            Console.WriteLine("of other values and priorities.");
            economicBlockade += 20;
            costToSurrender += 10;
            govPrefix = "Libertarian";
            break;
        case Ideology.EliteLiberal:
            Console.WriteLine("Elite Liberalism, as defined by the Liberal Crime Squad, emphasizes a single metric (Liberalism) that must");
            Console.WriteLine("be optimized by society at all costs. Due to that emphasis, Elite Liberal societies endorse the unity and solidarity");
            Console.WriteLine("of all humans, under a single a shared identity and culture, and view those seeking to disrupt this shared identity");
            Console.WriteLine("and culture as a threat to the unity of Terra. All such deviations are Arch-Conservative rhetoric, threatening humanity's");
            Console.WriteLine("purpose in life. Elite Liberal societies emphasize a strong military over other traits. While their military hard");
            Console.WriteLine("power is admirable, they suffer in other areas like social cohesion and cultural soft power due to an emphasis on");
            Console.WriteLine("a narrow definition of species unity.");
            generalWeaponsEffectiveness += 20;
            costToSurrender += 5;
            negotiationOdds += 10;
            govPrefix = "Elite Liberal";
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
            negotiationOdds += 10;
            govType = "Utopia";
            break;
        case Structure.Federation:
            Console.WriteLine("A federation is a government made up of several smaller states or regions, each with a certain degree of autonomy.");
            Console.WriteLine("They prioritize social cohesion, as they emphasize cooperation and diplomacy between member states.");
            costToSurrender -= 5;
            govType = "Federation";
            break;
        case Structure.Hivemind:
            Console.WriteLine("A hivemind is a government in which all individuals are connected and controlled by a 'social network'. Moderator AIs");
            Console.WriteLine("use echo chambers and demagoguery to manufacture social consensus on key issues. The AIs in charge of society prioritize");
            Console.WriteLine("technological research, as it helps promote efficiency and conformity.");
            economicBlockade += 10;
            govType = "Hive";
            break;
        case Structure.Junta:
            Console.WriteLine("Meaningful participation in the government is limited to individuals who successfully");
            Console.WriteLine("complete two years of military service. The society venerates the military, and the");
            Console.WriteLine("motto 'Service equals citizenship' is often used to justify investments in military hard power.");
            generalWeaponsEffectiveness += 10;
            govType = "Junta";
            break;
        case Structure.Republic:
            Console.WriteLine("The government allows all its people to participate in governance, allowing them to engage in");
            Console.WriteLine("endless debates to decide on the best course of action. Though the debates leads to a lack of social");
            Console.WriteLine("cohesion, it also encourages technological innovation.");
            economicBlockade += 20;
            costToSurrender += 5;
            govType = "Republic";
            break;
        case Structure.Empire:
            Console.WriteLine("An empire is a government where power is centralized into the hands of a single ruling family");
            Console.WriteLine("who relies on military hard power and cultural soft power. They often use military conquest");
            Console.WriteLine("and cultural influence to expand their power and territory. Empires, however, are dependent on social control");
            Console.WriteLine("and thus restricts research into 'disruptive' technologies.");
            negotiationOdds += 10;
            generalWeaponsEffectiveness += 10;
            economicBlockade -= 10;
            govType = "Empire";
            break;
    }

    Console.WriteLine($"Final GovType: {govPrefix} {govType}");

    Console.ReadLine();

    Console.Clear();
}

void GenerateAlienDescriptions()
{
    Console.WriteLine("One day, we encountered self-replicating spacecraft, remenants of an ancient alien civilization that had destroyed themselves.");
    Console.WriteLine("We established contact with these self-replicating spacecraft - and this is what we learnt about them.");
    Console.WriteLine();
    switch (alienSpecies)
    {
        case Alien.Transcendents:
            Console.WriteLine("Transcendents");
            Console.WriteLine("An advanced, alturistic alien civilization that has achieved a higher level of consciousness or understanding of the universe.");
            Console.WriteLine("The aliens describe themselves as the custodians of the universe, tasked with promoting progress and understanding wherever they can.");
            Console.WriteLine("They see humanity as a primitive species that is need of guidance and enlightenment. While guidance and enlightenment may be");
            Console.WriteLine("nice in theory, we do not know the values of these Transcendents, or the nature of their knowledge. They may have");
            Console.WriteLine("ulterior motives for their actions, destabilize the existing power structure, threaten our way of life.");
            Console.WriteLine("");
            Console.WriteLine("For all we know, they merely want to turn us into paperclips.");
            Console.ReadLine();
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

void GenerateStatInfo(string fluff, string actualStatName, int defaultValue, int currentValue)
{
    if (defaultValue < currentValue)
    {
        Console.WriteLine($"Due to your superior {fluff}, you are able to increase your {actualStatName} from {defaultValue} to {currentValue}!");
    }
    else if (defaultValue > currentValue)
    {
        Console.WriteLine($"Due to your inferior {fluff}, your {actualStatName} is reduced from {defaultValue} to {currentValue}.");
    }
    else
    {
        Console.WriteLine($"Your {fluff} is average, so your {actualStatName} stays at {defaultEconomicBlockade}.");
    }
}

void GenerateSurrenderCostReduction(int defaultValue, int currentValue)
{
    if (defaultValue > currentValue)
    {
        Console.WriteLine($"Due to your superior social cohesion, your society is able to handle all situations gracefully - even losses. You are able to reduce the cost of surrender from {defaultValue} to {currentValue}!");
    }
    else if (defaultValue < currentValue)
    {
        Console.WriteLine($"Due to your inferior social cohesion, your society is very brittle and will likely collapse at the first sign of defat. Therefore, the cost of surrender has increased from {defaultValue} to {currentValue}.");
    }
    else
    {
        Console.WriteLine($"Your socail cohesion is average, so your cost of surrender stays at {defaultValue}.");
    }
}

UpdatePlayerStats();
Console.Clear();
GenerateAlienDescriptions();

Console.ReadLine();

Console.Clear();

Console.WriteLine($"One day, the {alienName} attacked, with the singular purpose of conquering humanity.");
GenerateStatInfo("technology", "economic blockade strength", defaultEconomicBlockade, economicBlockade);
GenerateStatInfo("military hard power", "weapons effectiveness", defaultgeneralWeaponsEffectiveness, generalWeaponsEffectiveness);
GenerateStatInfo("cultural soft power", "diplomatic odds", defaultNegotiationOdds, negotiationOdds);
GenerateSurrenderCostReduction(defaultCostToSurrender, costToSurrender);

Console.ReadLine();

var randomGenerator = new Random();

// Generates a random number within a range.      
static int RandomNumber(int min, int max, Random random)
{
    return random.Next(min, max);
}

// See https://aka.ms/new-console-template for more information

var totalPoints = 0;

bool youSurrendered = false;
bool enemySurrendered = false;

var victoryVPs = 0; //relative power indicates that if you don't get to surrender, you still win overall.

var hardlinerProbablity = RandomNumber(50, 70, randomGenerator);

int currentProbablity = 0;

static bool WillEnemySurrender(int hardlinerProbablity, int currentProbablity, Random random)
{
    //introducing error makes it hard to debug, but might be useful as a way to guard against 'hardliner probablity'
    //var hardlinerInfluence = RandomNumber(1, 10, random);
    //var resistanceTotal = hardlinerProbablity += hardlinerInfluence;

    var resistanceTotal = hardlinerProbablity + 1;

    if (resistanceTotal <= currentProbablity && hardlinerProbablity > currentProbablity)
        Console.WriteLine("There is factionalism within the organization. Some doves are terrified of the threat and try to push for peace. Hardliners, however, denounce all suggestions of compromise as appeasement.");
    else if (hardlinerProbablity > currentProbablity)
        Console.WriteLine("The organization is resolute in fighting against you; both doves and hardliners view your current threat as not credible.");
    else
        Console.WriteLine("You inflicted severe pain on the organizations. Doves silence the hardliners and push for peace.");

    return resistanceTotal <= currentProbablity;
}

static bool CrisisContinues(bool youSurrendered, bool enemySurrendered)
{
    return !youSurrendered && !enemySurrendered;
}

static bool WillSuckerPunchTrigger(int suckerPunchActivation, Random random)
{
    var roll = RandomNumber(1, 100, random);

    Console.WriteLine(roll);

    return roll <= suckerPunchActivation;
}

static bool WillEnemyNegotiate(int negotiationOdds, Random random)
{
    var roll = RandomNumber(1, 100, random);

    Console.WriteLine(roll);

    return roll <= negotiationOdds;
}

static int EnemyEscalates(Random random)
{
    return RandomNumber(1, 25, random);
}

while (CrisisContinues(enemySurrendered, youSurrendered))
{
    if (WillEnemySurrender(hardlinerProbablity, currentProbablity, randomGenerator))
    {
        Console.WriteLine("The enemy finally gives up! The percentage chance of nuclear war is too high!");
        enemySurrendered = true;
    }
    else
    {
        Console.WriteLine($"Enemy Tolerance: {hardlinerProbablity}%");

        Console.WriteLine();

        Console.WriteLine($"Current VPs: {totalPoints}");
        Console.WriteLine($"Turn #{turnCounter}");
        Console.WriteLine($"Chances of Nuclear War {currentProbablity}%");
        Console.WriteLine();
        Console.WriteLine($"Options for the {govPrefix} {govType} of Terra:");
        Console.WriteLine($"(A) Unconditional Surrender: War ends and you lose {costToSurrender} points.");
        Console.WriteLine($"(B) Offer A Conditional Surrender (Success: {negotiationOdds}%. If the enemy accepts your offer, war ends and you'll lose {costToSurrender-5} points instead.)");
        Console.WriteLine($"(C) Unconventional Warfare (Chance of Immediate Enemy Surrender: {(economicBlockade / 4)}%. Increases probablity of nuclear war by {economicBlockade}%. No VP loss)");
        Console.WriteLine($"(D) Tactical Nuclear Weapons (Chance of Immediate Enemy Surrender: {(tacticalWeaponsBonus / 2)}%. Increases probablity of nuclear war by {tacticalWeaponsBonus}%, lose 5 VP)");
        Console.WriteLine($"(E) Strategic Nuclear Weapons (Chance of Immediate Enemy Surrender: {strategicWeaponsBonus / 2}%. Increases probablity of nuclear war by {strategicWeaponsBonus}%, lose 10 VP)");
        Console.WriteLine($"(F) Appeasement (reduce enemy tolerance by {negotiationOdds / 4}%, lose {costToSurrender/5} VP)");
        Console.WriteLine($"(G) Conventional Warfare (Success: {economicBlockade}%. Reduces enemy tolerance by {economicBlockade / 4}%, and temporarily blocks Transcendant escalation.)");

        var data = Console.ReadLine();

        if (data == "A")
        {
            Console.WriteLine($"The war is over! You have abdicated and allowed the {alienName} to take power.");
            totalPoints -= costToSurrender;
            youSurrendered = true;

            turnCounter += 1;
        }
        else if (data == "B")
        {
            if (costToSurrender <= 5)
            {
                Console.WriteLine("You send a message to the enemy, but the enemy does not respond");
            }
            else
            {
                Console.WriteLine("Diplomats conduct franctic negotiations to try to end the fighting.");
                var negotiationSuccess = WillEnemyNegotiate(negotiationOdds, randomGenerator);

                if (negotiationSuccess)
                {
                    Console.WriteLine("Enemy is willing to compromise on key points, providing you a face-saving measure. Victory with honor.");
                    costToSurrender -= 5;
                    totalPoints -= costToSurrender;
                    youSurrendered = true;
                }

                else
                {
                    Console.WriteLine("But talks deadlock and nothing happens.");

                    var enemyEscalates = EnemyEscalates(randomGenerator);

                    currentProbablity += enemyEscalates;

                    Console.WriteLine("Enemy engages in aggressive actions to 'persuade' you to accept peace on their terms.");
                    Console.WriteLine($"Enemy chooses to escalate by {enemyEscalates}%.");

                    if (WillSuckerPunchTrigger(currentProbablity, randomGenerator))
                    {
                        Console.WriteLine("Sucker Punch accidentially triggered! Game ends.");
                        enemySurrendered = true;
                        youSurrendered = true;
                    }
                }
            }

            turnCounter += 1;
        }
        else if (data == "C")
        {
            Console.WriteLine("You attempt to hurt their economy through conventional means and economic might.");

            var buckle = WillEnemySurrender(hardlinerProbablity, economicBlockade / 4, randomGenerator);

            if (buckle)
            {
                Console.WriteLine("It works! The enemy surrenders!");
            }
            else
            {
                Console.WriteLine("It didn't work. The enemy shrugged off your actions.");
            }

            currentProbablity += economicBlockade;
            var success = WillEnemySurrender(hardlinerProbablity, currentProbablity, randomGenerator);

            if (success)
            {
                Console.WriteLine("The enemy buckles under pressure and disbands.");
                totalPoints += victoryVPs;
                enemySurrendered = true;
            }
            else
            {
                Console.WriteLine("The enemy steels itself for what is to come.");

                var enemyEscalates = EnemyEscalates(randomGenerator);

                currentProbablity += enemyEscalates;

                Console.WriteLine($"Enemy chooses to escalate by {enemyEscalates}%.");

                if (WillSuckerPunchTrigger(currentProbablity, randomGenerator))
                {
                    Console.WriteLine("Sucker Punch accidentially triggered! Game ends.");
                    enemySurrendered = true;
                    youSurrendered = true;
                }
            }

            turnCounter += 1;
        }
        else if (data == "D")
        {
            Console.WriteLine("Tactical nuclear weapons are deployed. Billions are terminated.");
            Console.WriteLine("Historians will denounce your actions as a war crime (lose 5 points).");
            Console.WriteLine("But sometimes, you must take desperate measures to ensure victory.");
            totalPoints -= 5;


            var buckle = WillEnemySurrender(hardlinerProbablity, tacticalWeaponsBonus / 2, randomGenerator);

            if (buckle)
            {
                Console.WriteLine("It works! The enemy surrenders!");
            }
            else
            {
                Console.WriteLine("It didn't work. The enemy shrugged off your actions.");
            }


            currentProbablity += tacticalWeaponsBonus;

            var success = WillEnemySurrender(hardlinerProbablity, currentProbablity, randomGenerator);

            if (success)
            {
                Console.WriteLine("The enemy buckles under pressure and disbands.");
                totalPoints += victoryVPs;
                enemySurrendered = true;
            }
            else
            {
                Console.WriteLine("The enemy steels itself for what is to come.");

                var enemyEscalates = EnemyEscalates(randomGenerator);

                currentProbablity += enemyEscalates;

                Console.WriteLine($"Enemy chooses to escalate by {enemyEscalates}%.");

                if (WillSuckerPunchTrigger(currentProbablity, randomGenerator))
                {
                    Console.WriteLine("Sucker Punch accidentially triggered! Game ends.");
                    enemySurrendered = true;
                    youSurrendered = true;
                }
            }

            turnCounter += 1;
        }

        else if (data == "E")
        {
            Console.WriteLine("Strategic nuclear weapons are deployed. Trillions are terminated.");
            Console.WriteLine("Historians will denounce your actions as a war crime (lose 10 points).");
            Console.WriteLine("But sometimes, you must take desperate measures to ensure victory.");
            totalPoints -= 10;

            var buckle = WillEnemySurrender(hardlinerProbablity, strategicWeaponsBonus / 2, randomGenerator);

            if (buckle)
            {
                Console.WriteLine("It works! The enemy surrenders!");
            }
            else
            {
                Console.WriteLine("It didn't work. The enemy shrugged off your actions.");
            }


            currentProbablity += strategicWeaponsBonus;

            var success = WillEnemySurrender(hardlinerProbablity, currentProbablity, randomGenerator);

            if (success)
            {
                Console.WriteLine("The enemy buckles under pressure and disbands.");
                totalPoints += victoryVPs;
                enemySurrendered = true;
            }
            else
            {
                Console.WriteLine("The enemy steels itself for what is to come.");

                var enemyEscalates = EnemyEscalates(randomGenerator);

                currentProbablity += enemyEscalates;

                Console.WriteLine($"Enemy chooses to escalate by #{enemyEscalates}%.");

                if (WillSuckerPunchTrigger(currentProbablity, randomGenerator))
                {
                    Console.WriteLine("Sucker Punch accidentially triggered! Game ends.");
                    enemySurrendered = true;
                    youSurrendered = true;
                }
            }

            turnCounter += 1;
        }

        else if (data == "F")
        {
            var appeasementCost = costToSurrender / 5;
            Console.WriteLine($"The enemy is appeased by your 'gift'. But the masses are upset (lose {appeasementCost} points).");
            Console.WriteLine("But sometimes, you must take desperate measures to ensure victory.");
            totalPoints -= appeasementCost;
            hardlinerProbablity -= (negotiationOdds / 4);

            var success = WillEnemySurrender(hardlinerProbablity, currentProbablity, randomGenerator);

            if (success)
            {
                Console.WriteLine("The enemy buckles under pressure and disbands.");
                totalPoints += victoryVPs;
                enemySurrendered = true;
            }
            else
            {
                Console.WriteLine("The enemy steels itself for what is to come.");

                var enemyEscalates = EnemyEscalates(randomGenerator);

                currentProbablity += enemyEscalates;

                Console.WriteLine($"Enemy chooses to escalate by {enemyEscalates}%.");

                if (WillSuckerPunchTrigger(currentProbablity, randomGenerator))
                {
                    Console.WriteLine("Sucker Punch accidentially triggered! Game ends.");
                    enemySurrendered = true;
                    youSurrendered = true;
                }
            }

            turnCounter += 1;
        }
        else if (data == "G")
        {

            Console.WriteLine("You conduct a conventional war campaign against the enemy.");
            var negotiationSuccess = WillEnemyNegotiate(economicBlockade, randomGenerator);

            if (negotiationSuccess)
            {
                Console.WriteLine("The skrimishes has gone in your favor.");
                Console.WriteLine("The enemy regroups. The call from doves to negotiate grows louder.");
                hardlinerProbablity -= economicBlockade/4;
            }
            else
            {
                Console.WriteLine("The skrimishes has failed to go in your favor - the enemy pushes its advantage.");

                var enemyEscalates = EnemyEscalates(randomGenerator);

                currentProbablity += enemyEscalates;

                Console.WriteLine($"Enemy chooses to escalate by {enemyEscalates}%.");

                if (WillSuckerPunchTrigger(currentProbablity, randomGenerator))
                {
                    Console.WriteLine("Sucker Punch accidentially triggered! Game ends.");
                    enemySurrendered = true;
                    youSurrendered = true;
                }
            }

            turnCounter += 1;
        }
        else
        {
            Console.WriteLine("Invalid entry!");
        }
    }
}


if (enemySurrendered && youSurrendered)
{
    Console.WriteLine("...And silence reigns over all.");
    Console.WriteLine("Your Final Legacy: Dustbin of History.");
}
else
{
    Console.WriteLine($"Your Final Legacy: {totalPoints} Points");
}


Console.WriteLine("");
Console.WriteLine($"Final Probablity of Nuclear War: {currentProbablity}%");
Console.WriteLine($"Enemy Threshold For Nuclear War: {hardlinerProbablity}%");

Console.ReadLine();