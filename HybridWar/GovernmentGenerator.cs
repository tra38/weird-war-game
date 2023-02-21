namespace HybridWar
{
    public enum Ideology
    {
        Free_Market,
        Socialist,
        Environmentalist,
        Technocratic,
        Pious,
        Humanist
    }

    public enum Structure
    {
        Hivemind,
        Federation,
        Empire,
        Junta,
        Utopia,
        Republic,
    }

    public enum Electorate
    {
        All_Humans,
        Limited_To_Military,
        One_Person,
        None,
        Singleton
    }

    public static class GovernmentGenerator
    {
        public static T GetRandomValue<T>()
            where T : Enum
        {
            return (T)Enum.GetValues(typeof(T)).OfType<Enum>().OrderBy(_ => Guid.NewGuid()).First();
        }
    }
}
