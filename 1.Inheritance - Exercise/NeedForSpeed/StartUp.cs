namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(10, 50);
            raceMotorcycle.Drive(5.1);
        }
    }
}
