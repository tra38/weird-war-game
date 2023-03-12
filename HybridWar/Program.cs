﻿// See https://aka.ms/new-console-template for more information

//"Sacred Defense Is Barbaric Aggression"
//https://globalaffairs-ru.translate.goog/articles/ih-varvarskaya-agressiya/?_x_tr_sl=ru&_x_tr_tl=en&_x_tr_hl=en&_x_tr_pto=wapp

using HybridWar;

Console.WriteLine("Hello, World!");

Console.WriteLine("There is only one decision-maker of Terra. YOU. You contorl the lives of everyone else.");
Console.WriteLine("Everyone follows your orders.");
Console.WriteLine();
Console.WriteLine("I say this because your predecessors fought hard to establish this society.");
Console.WriteLine("They genuinely believed it would be best for the world.");
Console.WriteLine("...that diversity and free thinking would threaten humanity itself.");
Console.WriteLine("That everything must be purged.");

Console.ReadLine();

Console.WriteLine("So don't mess up.");

Console.ReadLine();

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
//var terranIdeology = Ideology.Socialist; ---socialism is overpowered, because it allows you to surrender with little cost! Need to nerf!
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
        //fix the piety issue.
        case Ideology.Pious:
            Console.WriteLine("Traditional religions have unified humanity for millennia, so it is natural that humans would turn to it in times of");
            Console.WriteLine("peril. Pious ideology emphasizes religion and moral values over other traits, and may");
            Console.WriteLine("prioritize military hard power to defend its religious beliefs.");
            Console.WriteLine("A side that adopts a theocratic ideology could see a boost in military hard power and");
            Console.WriteLine("cultural soft power, but may struggle with technology and social cohesion due to a focus on religious orthodoxy.");
            Console.ReadLine();
            Console.WriteLine("");
            generalWeaponsEffectiveness += 10;
            negotiationOdds += 10;
            costToSurrender += 10;
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
            costToSurrender -= 20;
            economicBlockade -= 10;
            generalWeaponsEffectiveness -= 10;
            govPrefix = "Workers'";
            break;
        case Ideology.Technocratic:
            Console.WriteLine("Technocrats believe that the best way to achieve progress and solve societal problems is through the use of advanced technology,");
            Console.WriteLine("and they view technical expertise as the most important qualification for leadership positions. A side that adopts a technocratic");
            Console.WriteLine("ideology might see a boost in technology, but will downplay the importance of social cohesion and cultural soft power.");
            economicBlockade += 20;
            costToSurrender += 10;
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
            costToSurrender += 20;
            govPrefix = "Libertarian";
            break;
        //need a better name (tried Transhumanist, tried Humanist, clearly Paperclip doesn't work. Ugh. AGI, perhaps?)
        //(It needs to be something that empahsizes military hard power over cultural soft power and social cohesion.)
        case Ideology.Paperclip:
            Console.WriteLine("A 'Paperclip' society emphasizes a single metric that must be optimized by society at all costs.");
            Console.WriteLine("Due to that emphasis, Paperclip societies endorse the unity and solidarity of all humans");
            Console.WriteLine("under a single a shared identity and culture, and view those seeking to disrupt this shared identity and culture");
            Console.WriteLine("as a threat to the unity of Terra. After all, any value devaition threaten the primary directive");
            Console.WriteLine("that humanity was designed to do in the first place. They emphasize a strong military over other traits. While their military hard");
            Console.WriteLine("power is admirable, they suffer in other areas like social cohesion and cultural soft power due to an emphasis on");
            Console.WriteLine("a narrow definition of species unity.");
            generalWeaponsEffectiveness += 20;
            costToSurrender += 10;
            negotiationOdds += 10;
            govPrefix = "Paperclip";
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
            costToSurrender -= 10;
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
            costToSurrender += 10;
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

var hardlinerProbablity = RandomNumber(1, 100, randomGenerator);

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
    turnCounter += 1;
    Console.WriteLine($"Enemy Tolerance: {hardlinerProbablity}%");

    Console.WriteLine();

    Console.WriteLine($"Current VPs: {totalPoints}");
    Console.WriteLine($"Turn #{turnCounter}");
    Console.WriteLine($"Chances of Nuclear War {currentProbablity}%");
    Console.WriteLine();
    Console.WriteLine($"Options for the {govPrefix} {govType}:");
    Console.WriteLine($"(A) Surrender: Lose {costToSurrender} points.");
    
    if (costToSurrender <= 5)
    {
        Console.WriteLine($"(The {alienName} no longer wishes to negotiate with you. They have made their demands clear and have compromised their ideals to accomdate your society. Accept or else.)");
    }
    else
    {
        Console.WriteLine($"(B) Negotiate A Favorable Settlement (Escalation Risk: Low, Success: {negotiationOdds}%), reducing the costs to surrender by 5 points.");
    }
    Console.WriteLine($"(C) Economic Embargo (Escalation Risk: Low, +{economicBlockade}% to Sucker Punch).");
    Console.WriteLine($"(D) Tactical Nuclear Weapons (Escalation Risk: Medium, +{tacticalWeaponsBonus}% to Sucker Punch, Lose 5 Points)");
    Console.WriteLine($"(E) Strategic Nuclear Weapons (Escalation Risk: High, +{strategicWeaponsBonus}% to Sucker Punch, Lose 10 Points)");
    Console.WriteLine($"(F) Activate Sterialization Procedures (Escalation Risk: 100%, Lose 20 Points!)");
    Console.WriteLine("(G) Wage Conventional War (60% chance of eroding enemy's will, 40% chance of doing nothing");
    Console.WriteLine("(H) Bribe the enemy (Lose 2 Points, erode enemy's will)");

    var data = Console.ReadLine();

    if (data == "A")
    {
        Console.WriteLine($"The war is over! You have abdicated and allowed the {alienName} to take power.");
        totalPoints -= costToSurrender;
        youSurrendered = true;
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
            }

            else
            {
                Console.WriteLine("But talks deadlock and nothing happens.");
            }
        }


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
    else if (data == "C")
    {
        Console.WriteLine("You attempt to hurt their economy through conventional means and economic might.");
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

            Console.WriteLine($"Enemy chooses to escalate by #{enemyEscalates}%.");

            if (WillSuckerPunchTrigger(currentProbablity, randomGenerator))
            {
                Console.WriteLine("Sucker Punch accidentially triggered! Game ends.");
                enemySurrendered = true;
                youSurrendered = true;
            }
        }
    }
    else if (data == "D")
    {
        Console.WriteLine("Tactical nuclear weapons are deployed. Billions are terminated.");
        Console.WriteLine("Historians will denounce your actions as a war crime (lose 5 points).");
        Console.WriteLine("But sometimes, you must take desperate measures to ensure victory.");
        totalPoints -= 5;
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

            Console.WriteLine($"Enemy chooses to escalate by #{enemyEscalates}%.");

            if (WillSuckerPunchTrigger(currentProbablity, randomGenerator))
            {
                Console.WriteLine("Sucker Punch accidentially triggered! Game ends.");
                enemySurrendered = true;
                youSurrendered = true;
            }
        }
    }

    else if (data == "E")
    {
        Console.WriteLine("Strategic nuclear weapons are deployed. Trillions are terminated.");
        Console.WriteLine("Historians will denounce your actions as a war crime (lose 10 points).");
        Console.WriteLine("But sometimes, you must take desperate measures to ensure victory.");
        totalPoints -= 10;
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
    }
    else if (data == "F")
    {
        var success = WillEnemySurrender(hardlinerProbablity, 100, randomGenerator);
        totalPoints -= 20;
        if (success)
        {
            Console.WriteLine("The enemy buckles under pressure and disbands.");
            totalPoints += victoryVPs;
            enemySurrendered = true;
        }
        else
        {
            Console.WriteLine("...");
            enemySurrendered = true;
            youSurrendered = true;
        }
    }
    else if (data == "G")
    {
        var success = WillEnemyNegotiate(negotiationOdds, randomGenerator);

        if (success)
        {
            Console.WriteLine("Enemy will has been eroded by 5%");
            hardlinerProbablity -= 5;
        }
        else
        {
            Console.WriteLine("Enemy will has not been eroded, sadly");
        }


        var enemyEscalates = EnemyEscalates(randomGenerator);

        currentProbablity += enemyEscalates;

        Console.WriteLine("Enemy engages in aggressive actions to 'persuade' you to accept peace.");
        Console.WriteLine($"Enemy chooses to escalate by {enemyEscalates}%.");
    }
    else if (data == "H")
    {
        hardlinerProbablity -= 5;
        Console.WriteLine("Enemy will has been eroded by 5%");

        var enemyEscalates = EnemyEscalates(randomGenerator);

        currentProbablity += enemyEscalates;

        Console.WriteLine("Enemy engages in aggressive actions to 'persuade' you to accept peace.");
        Console.WriteLine($"Enemy chooses to escalate by {enemyEscalates}%.");
    }
    else
    {
        Console.WriteLine("Invalid entry!");
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