namespace Assets.Scripts.Model
{
    public class Clock
    {
        public int hours { get; private set; } = 0;
        public int minutes { get; private set; } = 0;

        public void CountMinutes()
        {
            minutes++;
            if (minutes == 60)
            {
                minutes = 0;
                hours = (hours + 1) % 24;
            }
        }
    }
}
