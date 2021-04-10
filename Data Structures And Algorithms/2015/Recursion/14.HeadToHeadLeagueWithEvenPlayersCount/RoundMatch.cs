namespace _14.HeadToHeadLeagueWithEvenPlayersCount
{
    public class RoundMatch
    {
        public RoundMatch(int homeTeam, int awayTeam, int round)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Round = round;
        }

        public int Round { get; set; }

        public int HomeTeam { get; set; }

        public int AwayTeam { get; set; }
        
        public override string ToString()
        {
            return string.Format("Round {2} -> H({0}) - A({1})\n", this.HomeTeam, this.AwayTeam, this.Round);
        }
    }
}
